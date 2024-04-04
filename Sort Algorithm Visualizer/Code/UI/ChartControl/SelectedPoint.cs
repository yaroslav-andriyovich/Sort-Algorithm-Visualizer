using System.Drawing;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public struct SelectedPoint
    {
        public readonly int index;
        public Color originalColor;

        public SelectedPoint(int index, Color originalColor)
        {
            this.index = index;
            this.originalColor = originalColor;
        }
    }
}