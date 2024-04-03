using System.Drawing;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public struct SelectedPoint
    {
        public readonly int index;
        public Color color;

        public SelectedPoint(int index, Color color)
        {
            this.index = index;
            this.color = color;
        }
    }
}