using System.Threading;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public abstract class SortAlgorithmBase : ISortAlgorithm
    {
        public event MarkCallback Mark;
        
        protected readonly NumericData data;
        
        private readonly Delay _delay;
        private readonly CancellationToken _cancellationToken;

        protected SortAlgorithmBase(SortingParameters parameters)
        {
            data = parameters.data;
            _delay = parameters.delay;
            _cancellationToken = parameters.cancellationToken;
        }

        public abstract Task Sort();

        protected async Task Delay() => 
            await Task.Delay(_delay.Value, _cancellationToken);

        protected async Task MarkOnce(MarkType type, params int[] indexes)
        {
            Mark?.Invoke(type, indexes);
            await Delay();
            Mark?.Invoke(MarkType.None, indexes);
        }

        protected void MarkPermanentWithoutDelay(MarkType type, params int[] indexes) => 
            Mark?.Invoke(type, indexes);

        protected async Task SwapElements(int firstIndex, int secondIndex)
        {
            (data[firstIndex], data[secondIndex]) = (data[secondIndex], data[firstIndex]);
            await MarkOnce(MarkType.Swap, firstIndex, secondIndex);
        }
    }
}