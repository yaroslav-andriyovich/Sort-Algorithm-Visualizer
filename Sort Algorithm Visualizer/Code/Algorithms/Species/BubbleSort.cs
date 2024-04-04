using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class BubbleSort : SortAlgorithmBase
    {
        private int LastIndex => _data.Length - 1;
        private int SubPassesNumber => LastIndex - _passNumber;

        private int _passNumber;
        
        public BubbleSort(SortingParameters parameters) 
            : base(parameters)
        {
        }

        public override async Task NextPass()
        {
            for (int i = 0; i < SubPassesNumber; i++)
            {
                if (IsCanceled())
                    return;
                
                int targetIndex = i;
                int nextIndex = i + 1;
                bool targetNumberIsGreaterThanNext = _data[targetIndex] > _data[nextIndex];

                await ReportSelected(targetIndex, nextIndex);

                if (targetNumberIsGreaterThanNext)
                    SwapElements(targetIndex, nextIndex);

                await PassDelay();
            }

            IncrementPassNumber();
        }

        public override bool IsSorted() => 
            LastIndex < _passNumber;

        private void IncrementPassNumber() => 
            ++_passNumber;
    }
}