using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public abstract class SortAlgorithmBase : ISortAlgorithm
    {
        public event SelectCallback Select;
        public event SwapCallback Swap;

        protected readonly int[] _data;
        protected readonly Delay _delay;
        protected readonly CancellationToken _cancellationToken;

        public SortAlgorithmBase(SortingParameters parameters)
        {
            _data = parameters.data;
            _delay = parameters.delay;
            _cancellationToken = parameters.cancellationToken;
        }

        public abstract Task Sort();

        protected async Task ReportSelectedDelayed(int firstIndex, int secondIndex)
        {
            ReportSelected(firstIndex, secondIndex);
            await PassDelay();
        }
        
        protected void ReportSelected(int firstIndex, int secondIndex) => 
            Select?.Invoke(firstIndex, secondIndex);

        protected async Task PassDelay() => 
            await Task.Delay(_delay.Value, _cancellationToken);

        protected void SwapElements(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[secondIndex];
            _data[secondIndex] = temp;
            
            Swap?.Invoke(firstIndex, secondIndex);
        }
    }
}