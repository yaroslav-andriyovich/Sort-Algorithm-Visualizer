using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class QuickSort : SortAlgorithmBase
    {
        private readonly int _low;
        private readonly int _high;
        
        public QuickSort(SortingParameters parameters)
            : base(parameters)
        {
            _low = 0;
            _high = data.Length - 1;
        }

        public override async Task Sort() => 
            await Sort(_low, _high);

        private async Task Sort(int low, int high)
        {
            if (low < high)
            {
                int pivot = await Partition(low, high);
                
                await Sort(low, pivot - 1);
                await Sort(pivot + 1, high);
            }
        } 
        
        private async Task<int> Partition(int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                MarkPermanentWithoutDelay(MarkType.Pivot, high);

                if (data[j] < pivot)
                {
                    i++;

                    await MarkOnce(MarkType.Select, i, j);
                    
                    if (data[i] != data[j])
                        await Swap(i, j);
                }
            }
            
            await MarkOnce(MarkType.Select, i + 1, high);
            
            if (data[i + 1] != pivot)
                await Swap(i + 1, high);

            return i + 1;
        }
    }
}