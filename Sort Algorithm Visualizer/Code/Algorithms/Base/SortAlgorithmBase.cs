using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public abstract class SortAlgorithmBase : ISortAlgorithm
    {
        public event MarkCallback Mark;
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

        protected async Task MarkElements(int firstIndex, int secondIndex)
        {
            Mark?.Invoke(firstIndex, secondIndex);
            await Delay();
        }

        protected async Task SwapElements(int firstIndex, int secondIndex)
        {
            (_data[firstIndex], _data[secondIndex]) = (_data[secondIndex], _data[firstIndex]);
            Swap?.Invoke(firstIndex, secondIndex);
            await Delay();
        }

        protected async Task Delay() => 
            await Task.Delay(_delay.Value, _cancellationToken);

        protected async Task MarkAndSwap(int firstIndex, int secondIndex)
        {
            await MarkElements(firstIndex, secondIndex);
            await SwapElements(firstIndex, secondIndex);
        }
    }
}