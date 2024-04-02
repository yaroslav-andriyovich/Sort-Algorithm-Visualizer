using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class InsertionSort : SortAlgorithmBase
    {
        private int ElementsNumber => _data.Length;
        private int PrevIndex => _targetIndex - 1;
        private int PrevNumber => _data[PrevIndex];

        private int _targetIndex;
        private int _targetNumber;
        private int _passNumber;
    
        public InsertionSort(int[] data, Delay delay, SwapCallback swapCallback) 
            : base(data, delay, swapCallback)
        {
        }

        public override async Task NextPass()
        {
            SetTargetIndex();
            CacheTargetNumber();

            while (TargetNumberIsSmallerThanPrevious())
            {
                Swap(PrevIndex, _targetIndex);
                DecrementTargetIndex();

                await Task.Delay(_delay.Value);
            }

            IncrementPassNumber();
        }

        public override bool IsSorted() => 
            ElementsNumber <= _passNumber;

        private void SetTargetIndex() => 
            _targetIndex = _passNumber;

        private void CacheTargetNumber() => 
            _targetNumber = _data[_targetIndex];

        private bool TargetNumberIsSmallerThanPrevious() => 
            _targetIndex > 0 && _targetNumber < PrevNumber;

        private void DecrementTargetIndex() => 
            _targetIndex--;

        private void IncrementPassNumber() => 
            ++_passNumber;
    }
}