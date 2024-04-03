using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class InsertionSort : SortAlgorithmBase
    {
        private int ElementsNumber => _data.Length;
        private int PrevIndex => _targetIndex - 1;
        private int PrevNumber => _data[PrevIndex];

        private int _targetIndex;
        private int _targetNumber;
        private int _passNumber;
        
        public InsertionSort(AlgorithmParameters parameters) 
            : base(parameters)
        {
        }

        public override async Task NextPass()
        {
            SetTargetIndex();
            CacheTargetNumber();

            while (TargetIndexInRange())
            {
                if (IsCanceled())
                    return;
                
                await ReportSelected(PrevIndex, _targetIndex);

                if (!TargetNumberIsSmallerThanPrevious())
                    break;

                Swap(PrevIndex, _targetIndex);
                DecrementTargetIndex();

                await PassDelay();
            }

            IncrementPassNumber();
        }

        public override bool IsSorted() => 
            ElementsNumber <= _passNumber;

        private void SetTargetIndex() => 
            _targetIndex = _passNumber;

        private void CacheTargetNumber() => 
            _targetNumber = _data[_targetIndex];

        private bool TargetIndexInRange() => 
            _targetIndex > 0 && _targetIndex < _data.Length;
        
        private bool TargetNumberIsSmallerThanPrevious() => 
            _targetNumber < PrevNumber;

        private void DecrementTargetIndex() => 
            _targetIndex--;

        private void IncrementPassNumber() => 
            ++_passNumber;
    }
}