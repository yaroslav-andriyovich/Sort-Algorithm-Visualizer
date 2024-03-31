using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
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

        public AlgorithmController(AlgorithmFactory algorithmFactory, Delay delay)
        {
            _algorithmFactory = algorithmFactory;
            _delay = delay;
        }

        public void SetData(int[] data) => 
            _data = data;

        public void StartSort(SortAlgorithmType sortingType, SwapCallback swapCallback)
        {
            if (IsRunning)
                return;
            
            ChangeSortType(sortingType, swapCallback);
            RunSortingThread();
            Started?.Invoke();
        }

        public void StopSort()
        {
            if (IsRunning)
            {
                _backgroundWorker.CancelAsync();
                Finished?.Invoke();
            }
        }

        private void ChangeSortType(SortAlgorithmType sortingType, SwapCallback swapCallback)
        {
            switch (sortingType)
            {
                case SortAlgorithmType.BubbleSort:
                    _sortAlgorithm = _algorithmFactory.CreateBubble(_data, _delay, swapCallback);
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
                await _sortAlgorithm.NextStep();
                await Task.Delay(_delay.Value);
            }

            Finished?.Invoke();
            ClearBackgroundWorker();
        }

        private void ClearBackgroundWorker() => 
            _backgroundWorker = null;
    }
    
    public delegate void SwapCallback(int firstIndex, int secondIndex);
}