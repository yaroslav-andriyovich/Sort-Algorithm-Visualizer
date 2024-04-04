using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Algorithms.Base
{
    public interface ISortAlgorithm
    {
        event SelectCallback Select;
        event SwapCallback Swap;
        bool IsSorted();
        Task NextPass();
    }
    
    public delegate void SelectCallback(int firstIndex, int secondIndex);
    
    public delegate void SwapCallback(int firstIndex, int secondIndex);
}