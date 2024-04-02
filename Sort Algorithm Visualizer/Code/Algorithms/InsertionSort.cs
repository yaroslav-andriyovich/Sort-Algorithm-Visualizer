using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class InsertionSort : ISortAlgorithm
    {
        private readonly int[] _data;
        private readonly Delay _delay;
        private readonly SwapCallback _swapCallback;
        private int ElementsCount => _data.Length;
        private int PrevIndex => _currentIndex - 1;
        private int PrevElement => _data[PrevIndex];

        private int _currentIndex;
        private int _currentElement;
        private int _passNumber;

        public InsertionSort(int[] data, Delay delay, SwapCallback swapCallback)
        {
            _data = data;
            _delay = delay;
            _swapCallback = swapCallback;
        }

        public async Task NextPass()
        {
            MoveToTargetIndex();
            CacheTargetElement();

            while (CanMoveLeft())
            {
                Insert(PrevIndex, _currentIndex);
                DecrementCurrentIndex();
                
                await Task.Delay(_delay.Value);
            }

            InsertElement();
            IncrementPassNumber();
        }

        private bool CanMoveLeft() => 
            _currentIndex > 0 && _currentElement < PrevElement;

        private void MoveToTargetIndex() => 
            _currentIndex = _passNumber;

        private void CacheTargetElement() => 
            _currentElement = _data[_passNumber];

        private void DecrementCurrentIndex() => 
            _currentIndex--;

        private void InsertElement() => 
            _data[_currentIndex] = _currentElement;

        private void IncrementPassNumber() => 
            ++_passNumber;

        public bool IsSorted() => 
            ElementsCount <= _passNumber;

        private void Insert(int targetIndex, int indexToReplace)
        {
            _data[indexToReplace] = _data[targetIndex];
                
            _swapCallback?.Invoke(targetIndex, indexToReplace);
        }
    }
}