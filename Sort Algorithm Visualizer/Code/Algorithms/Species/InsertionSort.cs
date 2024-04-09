using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class InsertionSort : SortAlgorithmBase
    {
        public InsertionSort(SortingParameters parameters) 
            : base(parameters)
        {
        }

        public override async Task Sort()
        {
            for (int i = 1; i < data.Length; i++)
            {
                int minNumIndex = i;
                
                while (minNumIndex > 0 && minNumIndex < data.Length)
                {
                    await MarkOnce(MarkType.Select, minNumIndex, minNumIndex - 1);

                    if (data[minNumIndex] < data[minNumIndex - 1])
                    {
                        await Swap(minNumIndex, minNumIndex - 1);
                        MarkPermanentWithoutDelay(MarkType.Pivot, i);
                        minNumIndex--;
                    }
                    else
                        break;
                }
            }
        }
    }
}