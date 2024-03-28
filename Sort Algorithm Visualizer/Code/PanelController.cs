using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.Code
{
    public class PanelController
    {
        private readonly Panel _panel;

        private int[] _array;
        private Graphics _graphics;

        public PanelController(Panel panel)
        {
            _panel = panel;
        }

        public void Reset()
        {
            _graphics = _panel.CreateGraphics();

            int numEntries = _panel.Width;
            int maxVal = _panel.Height;

            _array = new int[numEntries];

            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int x = 0;
            int y = 0;
            
            _graphics.FillRectangle(solidBrush, x, y, numEntries, maxVal);

            Random random = new Random();

            for (int i = 0; i < numEntries; i++)
            {
                _array[i] = random.Next(0, maxVal);
            }
            
            SolidBrush solidBrush2 = new SolidBrush(Color.White);
            
            for (int i = 0; i < numEntries; i++)
            {
                _graphics.FillRectangle(solidBrush2, i, maxVal - _array[i], 1, maxVal);
            }
        }
    }
}