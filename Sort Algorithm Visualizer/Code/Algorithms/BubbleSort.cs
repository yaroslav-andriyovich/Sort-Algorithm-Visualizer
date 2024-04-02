using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class BubbleSort : SortAlgorithmBase
    {
        private int LastIndex => _data.Length - 1;
        private int SubPassesNumber => LastIndex - _passNumber;

        private int _passNumber;

        public BubbleSort(int[] data, Delay delay, SwapCallback swapCallback) 
            : base(data, delay, swapCallback)
        {
        }

        public override async Task NextPass()
        {
            for (int i = 0; i < SubPassesNumber; i++)
            {
                int targetNumIndex = i;
                int nextNumIndex = i + 1;
                bool targetNumberIsGreaterThanNext = _data[targetNumIndex] > _data[nextNumIndex];
                
                if (targetNumberIsGreaterThanNext)
                    Swap(targetNumIndex, nextNumIndex);

                await Task.Delay(_delay.Value);
            }

            IncrementPassNumber();
        }

        public override bool IsSorted() => 
            LastIndex < _passNumber;

        private void IncrementPassNumber() => 
            ++_passNumber;
    }
}