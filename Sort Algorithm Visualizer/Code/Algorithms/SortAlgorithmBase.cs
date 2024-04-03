using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public abstract class SortAlgorithmBase : ISortAlgorithm
    {
        protected readonly int[] _data;
        protected readonly Delay _delay;
        protected readonly SelectedCallback _selectedCallback;
        protected readonly SwapCallback _swapCallback;
        protected readonly CancellationToken _cancellationToken;
        
        public SortAlgorithmBase(AlgorithmParameters parameters)
        {
            _data = parameters.data;
            _delay = parameters.delay;
            _selectedCallback = parameters.selectedCallback;
            _swapCallback = parameters.swapCallback;
            _cancellationToken = parameters.cancellationToken;
        }

        public abstract bool IsSorted();

        public abstract Task NextPass();

        public bool IsCanceled() => 
            _cancellationToken.IsCancellationRequested;
        
        protected async Task ReportSelected(int firstIndex, int secondIndex)
        {
            _selectedCallback?.Invoke(firstIndex, secondIndex);
            await PassDelay();
        }

        protected async Task PassDelay() => 
            await Task.Delay(_delay.Value / 2, _cancellationToken);

        protected void Swap(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[secondIndex];
            _data[secondIndex] = temp;
            
            _swapCallback?.Invoke(firstIndex, secondIndex);
        }
    }
}