using System;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class MergeSort : SortAlgorithmBase
    {
        private readonly int _low;
        private readonly int _high;
        
        public MergeSort(SortingParameters parameters)
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
                int mid = low + (high - low) / 2;
            
                await Sort(low, mid);
                await Sort(mid + 1, high);
            
                await Merge(low, mid, high);
            }
        }
    
        private async Task Merge(int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(data.array, low, leftArray, 0, n1);
            Array.Copy(data.array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = low;

            MarkPermanentWithoutDelay(MarkType.Pivot, high);
            
            while (i < n1 && j < n2)
            {
                await MarkOnce(MarkType.Select, low + i, mid + 1 + j);
                
                if (leftArray[i] <= rightArray[j])
                {
                    data[k] = leftArray[i];
                    
                    if (k != low + i)
                        await MarkOnce(MarkType.Swap, k);

                    i++;
                }
                else
                {
                    data[k] = rightArray[j];
                    
                    if (k != mid + 1 + j)
                        await MarkOnce(MarkType.Swap, k);

                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                data[k] = leftArray[i];
                
                if (k != low + i)
                    await MarkOnce(MarkType.Swap, k);

                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = rightArray[j];
                
                if (k != mid + 1 + j)
                    await MarkOnce(MarkType.Swap, k);

                j++;
                k++;
            }
        }
    }
}