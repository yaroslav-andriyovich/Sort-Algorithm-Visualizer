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
                for (int j = 0; j < _data.Length - i - 1; j++)
                {
                    int currentIndex = j;
                    int nextIndex = j + 1;
                    
                    await ReportSelectedDelayed(currentIndex, nextIndex);
                
                    if (_data[currentIndex] > _data[nextIndex])
                        SwapElements(currentIndex, nextIndex);

                    await PassDelay();
                }
            }
        }
    }
}