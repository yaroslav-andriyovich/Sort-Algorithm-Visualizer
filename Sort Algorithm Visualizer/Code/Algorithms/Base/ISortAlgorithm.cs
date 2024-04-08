using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public interface ISortAlgorithm
    {
        event MarkCallback Mark;
        event SwapCallback Swap;
        Task Sort();
    }

    public enum MarkType
    {
        None,
        Select,
        Swap,
        Pivot
    }
    
    public delegate void MarkCallback(MarkType type, params int[] indexes);
    
    public delegate void SwapCallback(int firstIndex, int secondIndex);
}