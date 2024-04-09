using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class SelectionSort : SortAlgorithmBase
    {
        public SelectionSort(SortingParameters parameters)
            : base(parameters)
        {
        }

        public override async Task Sort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int minNumIndex = i;

                for (int j = i + 1; j < data.Length; j++)
                {
                    await MarkOnce(MarkType.Select, minNumIndex, j);
                
                    if (data[j] < data[minNumIndex])
                        minNumIndex = j;
                }

                if (minNumIndex != i)
                    await Swap(minNumIndex, i);
                
                MarkPermanentWithoutDelay(MarkType.Pivot, i);
            }
        }
    }
}