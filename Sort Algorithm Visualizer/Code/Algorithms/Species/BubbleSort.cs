using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class BubbleSort : SortAlgorithmBase
    {
        public BubbleSort(SortingParameters parameters) 
            : base(parameters)
        {
        }
        
        public override async Task Sort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int lastHighest = data.Length - i - 1;
                
                for (int j = 0; j < lastHighest; j++)
                {
                    int currentIndex = j;
                    int nextIndex = j + 1;
                    
                    await MarkOnce(MarkType.Select, currentIndex, nextIndex);

                    if (data[currentIndex] > data[nextIndex])
                        await Swap(currentIndex, nextIndex);
                }
                
                MarkPermanentWithoutDelay(MarkType.Pivot, lastHighest);
            }
        }
    }
}