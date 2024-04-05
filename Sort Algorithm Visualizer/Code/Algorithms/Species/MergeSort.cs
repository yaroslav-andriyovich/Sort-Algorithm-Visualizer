using System;
using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class MergeSort : SortAlgorithmBase
    {
        public MergeSort(SortingParameters parameters)
            : base(parameters)
        {
        }

        public override async Task Sort() => 
            await Sort(0, _data.Length - 1);

        private async Task Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
 
                await Sort(left, middle);
                await Sort(middle + 1, right);
 
                await Merge(left, middle, right);
            }
        }
        
        private async Task Merge(int left, int middle, int right)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = middle - left + 1;
            int n2 = right - middle;
 
            // Create temp arrays
            int[] leftTemp = new int[n1];
            int[] rightTemp = new int[n2];
            int i, j;
 
            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                leftTemp[i] = _data[left + i];
            for (j = 0; j < n2; ++j)
                rightTemp[j] = _data[middle + 1 + j];
 
            // Merge the temp arrays
 
            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;
 
            // Initial index of merged
            // subarray array
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftTemp[i] <= rightTemp[j])
                {
                    await MarkElements(k, left + i);
                    _data[k] = leftTemp[i];
                    SwapElements(k, left + i);
                    await Delay();
                    i++;
                }
                else
                {
                    await MarkElements(k, middle + 1 + j);
                    _data[k] = rightTemp[j];
                    SwapElements(k, middle + 1 + j);
                    await Delay();
                    j++;
                }
                k++;
            }
 
            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                await MarkElements(k, left + i);
                _data[k] = leftTemp[i];
                SwapElements(k, left + i);
                await Delay();
                i++;
                k++;
            }
 
            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                await MarkElements(k, middle + 1 + j);
                _data[k] = rightTemp[j];
                SwapElements(k, middle + 1 + j);
                await Delay();
                j++;
                k++;
            }
        }
    }
}