using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public interface ISortAlgorithm
    {
        event MarkCallback Mark;
        Task Sort();
    }

    public enum MarkType
    {
        None,
        Select,
        Select2,
        Swap,
        Pivot
    }
    
    public delegate void MarkCallback(MarkType type, params int[] indexes);
}