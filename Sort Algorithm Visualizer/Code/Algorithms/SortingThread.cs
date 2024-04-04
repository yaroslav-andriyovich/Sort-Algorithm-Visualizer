using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class SortingThread
    {
        public event Action StopEvent;
        
        public bool IsRunning => _backgroundWorker != null && !_backgroundWorker.CancellationPending;
        
        private readonly Delay _delay;

        private ISortAlgorithm _algorithm;
        private CancellationToken _cancellationToken;
        private BackgroundWorker _backgroundWorker;

        public SortingThread(Delay delay) => 
            _delay = delay;

        public void Run(ISortAlgorithm algorithm, CancellationToken cancellationToken)
        {
            _algorithm = algorithm;
            _cancellationToken = cancellationToken;
            
            CreateWorker();
        }

        public void Stop() => 
            _backgroundWorker.CancelAsync();

        private void CreateWorker()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += ThreadWork;
            _backgroundWorker.RunWorkerAsync();
        }

        private async void ThreadWork(object sender, DoWorkEventArgs e)
        {
            while (!_algorithm.IsSorted() && IsRunning)
            {
                try
                {
                    await _algorithm.NextPass();
                    await Task.Delay(_delay.Value, _cancellationToken);
                }
                catch (Exception exception)
                {
                    if (!(exception is TaskCanceledException))
                        Console.WriteLine(exception);
                }
            }
            
            _backgroundWorker = null;
            
            StopEvent?.Invoke();
        }
    }
}