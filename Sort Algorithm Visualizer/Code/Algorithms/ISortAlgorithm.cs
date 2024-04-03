using System.Threading.Tasks;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public interface ISortAlgorithm
    {
        bool IsSorted();
        Task NextPass();
    }
}