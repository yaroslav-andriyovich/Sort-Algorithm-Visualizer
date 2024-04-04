using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class QuickSort : SortAlgorithmBase
    {
        private readonly int _left;
        private readonly int _right;
        
        public QuickSort(SortingParameters parameters)
            : base(parameters)
        {
            _left = 0;
            _right = _data.Length - 1;
        }

        public override async Task Sort() => 
            await Sort(_left, _right);

        private async Task Sort(int left, int right)
        {
            if (left < right)
            {
                int pivot = await Partition(left, right);
                
                await Sort(left, pivot - 1);
                await Sort(pivot + 1, right);
            }
        } 
        
        private async Task<int> Partition(int left, int right)
        {
            int pivot = _data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                await ReportSelectedDelayed(j, right);
                
                if (_data[j] < pivot)
                {
                    i++;

                    if (_data[i] != _data[j])
                        await ReportAndSwap(i, j);
                }
            }

            if (_data[i + 1] != pivot)
                await ReportAndSwap(i + 1, right);

            return i + 1;
        }

        private async Task ReportAndSwap(int i, int j)
        {
            await ReportSelectedDelayed(i, j);
            SwapElements(i, j);
            await PassDelay();
        }
    }
}