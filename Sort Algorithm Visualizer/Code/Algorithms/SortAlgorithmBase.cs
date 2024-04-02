using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public abstract class SortAlgorithmBase : ISortAlgorithm
    {
        protected readonly int[] _data;
        protected readonly Delay _delay;
        protected readonly SwapCallback _swapCallback;
        
        public SortAlgorithmBase(int[] data, Delay delay, SwapCallback swapCallback)
        {
            _data = data;
            _delay = delay;
            _swapCallback = swapCallback;
        }

        public abstract Task NextPass();

        public abstract bool IsSorted();

        protected void Swap(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[secondIndex];
            _data[secondIndex] = temp;
            
            _swapCallback?.Invoke(firstIndex, secondIndex);
        }
    }
}