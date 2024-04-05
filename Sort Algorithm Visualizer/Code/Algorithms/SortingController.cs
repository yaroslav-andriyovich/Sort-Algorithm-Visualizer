using System;
using System.Threading;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class SortingController
    {
        public event MarkCallback Select;
        public event SwapCallback Swap;
        public event Action Finish;
        public bool IsRunning => _thread.IsRunning;

        private readonly Delay _delay;
        private readonly SortingThread _thread;
        private readonly AlgorithmFactory _algorithmFactory;

        private int[] _data;
        private CancellationTokenSource _cancellationTokenSource;
        private ISortAlgorithm _algorithm;

        public SortingController(Delay delay)
        {
            _delay = delay;
            _algorithmFactory = new AlgorithmFactory();
            _thread = new SortingThread();
            _thread.StopEvent += OnAlgorithmStop;
        }

        public void SetData(int[] data) => 
            _data = data;

        public void StartSorting(SortAlgorithmType sortingType)
        {
            if (IsRunning)
                return;
            
            CreateCancellationToken();
            CreateAlgorithm(sortingType, GetSortingParameters());
            _thread.Run(_algorithm);
        }

        public void StopSort()
        {
            if (IsRunning)
            {
                _cancellationTokenSource.Cancel();
                _thread.Stop();
                Finish?.Invoke();
            }
        }

        private void CreateCancellationToken() => 
            _cancellationTokenSource = new CancellationTokenSource();

        private SortingParameters GetSortingParameters()
        {
            return new SortingParameters
            {
                data = _data,
                delay = _delay,
                cancellationToken = _cancellationTokenSource.Token
            };
        }

        private void CreateAlgorithm(SortAlgorithmType sortingType, SortingParameters parameters)
        {
            _algorithm = _algorithmFactory.Create(sortingType, parameters);
            
            _algorithm.Mark += Select;
            _algorithm.Swap += Swap;
        }
        
        private void OnAlgorithmStop()
        {
            DestroyAlgorithm();
            Finish?.Invoke();
        }

        private void DestroyAlgorithm()
        {
            _algorithm.Mark -= Select;
            _algorithm.Swap -= Swap;
            
            _algorithm = null;
        }
    }
}