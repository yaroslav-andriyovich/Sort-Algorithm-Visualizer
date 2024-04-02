using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public interface ISortAlgorithm
    {
        Task NextPass();
        bool IsSorted();
    }
}