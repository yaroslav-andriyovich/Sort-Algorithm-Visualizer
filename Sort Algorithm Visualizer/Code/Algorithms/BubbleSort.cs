using System;
using System.Drawing;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        private bool _sorted;
        private int[] _data;
        private Graphics _graphics;
        private int _maxGraphicsHeight;
        private SolidBrush _solidBrush = new SolidBrush(Color.White);
        private SolidBrush _solidBrush2 = new SolidBrush(Color.Black);
        
        public void Sort(int[] data, Graphics graphics, int maxGraphicsHeight)
        {
            _data = data;
            _graphics = graphics;
            _maxGraphicsHeight = maxGraphicsHeight;
            
            Console.WriteLine(_data.Length);

            while (!_sorted)
            {
                for (int i = 0; i < _data.Length - 1; i++)
                {
                    if (_data[i] > _data[i + 1])
                        Swap(i, i + 1);
                }
                
                _sorted = IsSorted();
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _data[firstIndex];

            _data[firstIndex] = _data[firstIndex + 1];
            _data[firstIndex + 1] = temp;
            
            _graphics.FillRectangle(_solidBrush2, firstIndex, 0, 1, _maxGraphicsHeight);
            _graphics.FillRectangle(_solidBrush2, secondIndex, 0, 1, _maxGraphicsHeight);
            
            _graphics.FillRectangle(_solidBrush, firstIndex, _maxGraphicsHeight - _data[firstIndex], 1, _maxGraphicsHeight);
            _graphics.FillRectangle(_solidBrush, secondIndex, _maxGraphicsHeight - _data[secondIndex], 1, _maxGraphicsHeight);
        }

        private bool IsSorted()
        {
            for (int i = 0; i < _data.Length - 1; i++)
            {
                if (_data[i] > _data[i + 1])
                    return false;
            }
            
            return true;
        }
    }
}