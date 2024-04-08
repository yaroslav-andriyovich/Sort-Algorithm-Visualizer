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
            for (int i = 1; i < _data.Length; i++)
            {
                int minNumIndex = i;
                
                while (minNumIndex > 0 && minNumIndex < _data.Length)
                {
                    await MarkOnce(MarkType.Select, minNumIndex, minNumIndex - 1);

                    if (_data[minNumIndex] < _data[minNumIndex - 1])
                    {
                        await SwapElements(minNumIndex, minNumIndex - 1);
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