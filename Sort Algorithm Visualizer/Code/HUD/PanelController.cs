using System;
using System.Drawing;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code.Algorithms;

namespace Sort_Algorithm_Visualizer.Code.HUD
{
    public class PanelController
    {
        private readonly Panel _panel;
        
        private int[] _data;
        private Graphics _graphics;

        public PanelController(Panel panel) => 
            _panel = panel;

        public void Reset()
        {
            int numEntries = _panel.Width;
            int maxVal = _panel.Height;

            _data = new int[numEntries];

            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int x = 0;
            int y = 0;
            
            _graphics = _panel.CreateGraphics();
            _graphics.FillRectangle(solidBrush, x, y, numEntries, maxVal);
            _graphics.Save();

            Random random = new Random();

            for (int i = 0; i < numEntries; i++)
            {
                _data[i] = random.Next(0, maxVal);
            }
            
            SolidBrush solidBrush2 = new SolidBrush(Color.White);
            
            for (int i = 0; i < numEntries; i++)
            {
                _graphics.FillRectangle(solidBrush2, i, maxVal - _data[i], 1, maxVal);
            }
        }

        public void Start()
        {
            ISortAlgorithm sortAlgorithm = new BubbleSort();
            
            sortAlgorithm.Sort(_data, _graphics, _panel.Height);
        }
    }
}