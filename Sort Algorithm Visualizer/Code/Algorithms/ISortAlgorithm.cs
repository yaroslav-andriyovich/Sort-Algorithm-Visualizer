using System.Drawing;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public interface ISortAlgorithm
    {
        void Sort(int[] data, Graphics graphics, int maxGraphicsHeight);
    }
}