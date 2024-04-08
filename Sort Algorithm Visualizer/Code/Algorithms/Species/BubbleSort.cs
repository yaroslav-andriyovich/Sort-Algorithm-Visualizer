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
            for (int i = 0; i < _data.Length - 1; i++)
            {
                int lastHighest = _data.Length - i - 1;
                
                for (int j = 0; j < lastHighest; j++)
                {
                    int currentIndex = j;
                    int nextIndex = j + 1;
                    
                    await MarkOnce(MarkType.Select, currentIndex, nextIndex);

                    if (_data[currentIndex] > _data[nextIndex])
                        await SwapElements(currentIndex, nextIndex);
                }
                
                MarkPermanentWithoutDelay(MarkType.Pivot, lastHighest);
            }
        }
    }
}