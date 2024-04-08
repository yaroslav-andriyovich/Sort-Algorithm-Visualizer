using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class SortingThread
    {
        public event Action StopEvent;
        
        public bool IsRunning => _backgroundWorker != null && !_backgroundWorker.CancellationPending;
        

        private ISortAlgorithm _algorithm;
        private BackgroundWorker _backgroundWorker;

        public void Run(ISortAlgorithm algorithm)
        {
            _algorithm = algorithm;
            
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
            try
            {
                await _algorithm.Sort();
            }
            catch (Exception exception)
            {
                if (!(exception is TaskCanceledException))
                    throw;
            }
            
            _backgroundWorker = null;
            
            StopEvent?.Invoke();
        }
    }
}