using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        private readonly int[] _data;
        private readonly Delay _delay;
        private readonly SwapCallback _swapCallback;
        private int LastIndex => _data.Length - 1;

        private int _passNumber;

        public BubbleSort(int[] data, Delay delay, SwapCallback swapCallback)
        {
            _data = data;
            _delay = delay;
            _swapCallback = swapCallback;
        }

        public async Task NextPass()
        {
            for (int i = 0; i < LastIndex - _passNumber; i++)
            {
                int firstIndex = i;
                int secondIndex = i + 1;
                bool leftNumGreaterThanRight = _data[firstIndex] > _data[secondIndex]; 
                
                if (leftNumGreaterThanRight)
                    Swap(firstIndex, secondIndex);

                await Task.Delay(_delay.Value);
            }

            ++_passNumber;
        }

        public bool IsSorted() => 
            LastIndex < _passNumber;

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[secondIndex];
            _data[secondIndex] = temp;
            
            _swapCallback?.Invoke(firstIndex, secondIndex);
        }
    }
}