using System.Drawing;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public struct MarkedPoint
    {
        public readonly int index;
        public Color originalColor;

        public MarkedPoint(int index, Color originalColor)
        {
            this.index = index;
            this.originalColor = originalColor;
        }
    }
}