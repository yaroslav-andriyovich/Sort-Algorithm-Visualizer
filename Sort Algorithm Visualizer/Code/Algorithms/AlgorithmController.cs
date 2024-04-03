using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class AlgorithmController
    {
        public event Action Started;
        public event Action Finished;
        public bool IsRunning => _backgroundWorker != null && !_backgroundWorker.CancellationPending;

        private readonly AlgorithmFactory _algorithmFactory;
        private readonly Delay _delay;

        private ISortAlgorithm _sortAlgorithm;
        private BackgroundWorker _backgroundWorker;
        private int[] _data;
        private AlgorithmParameters _parameters;
        private CancellationTokenSource _cancellationTokenSource;

        public AlgorithmController(AlgorithmFactory algorithmFactory, Delay delay)
        {
            _algorithmFactory = algorithmFactory;
            _delay = delay;
        }

        public void SetData(int[] data) => 
            _data = data;

        public void StartSort(SortAlgorithmType sortingType, SelectedCallback selectedCallback, SwapCallback swapCallback)
        {
            if (IsRunning)
                return;
            
            ChangeSortType(sortingType, selectedCallback, swapCallback);
            RunSortingThread();
            Started?.Invoke();
        }

        public void StopSort()
        {
            if (IsRunning)
            {
                _cancellationTokenSource.Cancel();
                _backgroundWorker.CancelAsync();
                Finished?.Invoke();
            }
        }

        private void ChangeSortType(SortAlgorithmType sortingType, SelectedCallback selectedCallback, SwapCallback swapCallback)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _parameters = new AlgorithmParameters
            {
                data = _data,
                delay = _delay,
                selectedCallback = selectedCallback,
                swapCallback = swapCallback,
                cancellationToken = _cancellationTokenSource.Token
            };
            
            switch (sortingType)
            {
                case SortAlgorithmType.Bubble:
                    _sortAlgorithm = _algorithmFactory.CreateBubble(_parameters);
                    break;
                
                case SortAlgorithmType.Insertion:
                    _sortAlgorithm = _algorithmFactory.CreateInsertion(_parameters);
                    break;

                default:
                    throw new InvalidOperationException("Unknown sort algorithm type selected!");
            }
        }

        private void RunSortingThread()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += ThreadWork;
            _backgroundWorker.RunWorkerAsync();
        }

        private async void ThreadWork(object sender, DoWorkEventArgs e)
        {
            while (!_sortAlgorithm.IsSorted() && IsRunning)
            {
                try
                {
                    await _sortAlgorithm.NextPass();
                    await Task.Delay(_delay.Value, _cancellationTokenSource.Token);
                }
                catch (Exception exception)
                {
                    if (!(exception is TaskCanceledException))
                        Console.WriteLine(exception);
                }
            }
            
            if (_backgroundWorker != null)
                Finished?.Invoke();
            
            ClearBackgroundWorker();
        }

        private void ClearBackgroundWorker() => 
            _backgroundWorker = null;
    }
    
    public delegate void SelectedCallback(int firstIndex, int secondIndex);
    
    public delegate void SwapCallback(int firstIndex, int secondIndex);
}