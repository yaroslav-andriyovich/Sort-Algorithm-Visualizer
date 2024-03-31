using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        private readonly int[] _data;
        private readonly SwapCallback _swapCallback;
        private int LastIndex => _data.Length - 1;

        private int _passCount;

        public BubbleSort(int[] data, SwapCallback swapCallback)
        {
            _data = data;
            _swapCallback = swapCallback;
        }

        public async Task NextStep()
        {
            for (int i = 0; i < LastIndex - _passCount; i++)
            {
                int firstIndex = i;
                int secondIndex = i + 1;
                bool leftNumGreaterThanRight = _data[firstIndex] > _data[secondIndex]; 
                
                if (leftNumGreaterThanRight)
                {
                    Swap(firstIndex, secondIndex);
                    _swapCallback?.Invoke(firstIndex, secondIndex);
                }

                await Task.Delay(Settings.Instance.Delay);
            }

            ++_passCount;
        }

        public bool IsSorted() => 
            LastIndex < _passCount;

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[secondIndex];
            _data[secondIndex] = temp;
        }
    }
}