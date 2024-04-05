using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public interface ISortAlgorithm
    {
        event MarkCallback Mark;
        event SwapCallback Swap;
        Task Sort();
    }
    
    public delegate void MarkCallback(int firstIndex, int secondIndex);
    
    public delegate void SwapCallback(int firstIndex, int secondIndex);
}