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

        /*public override async Task Sort()
        {
            await Sort(0, _data.Length - 1);
            Console.WriteLine(string.Join(",", _data));
        }*/
        
        public override async Task Sort()
        {
            await MergeSortHelper(0, _data.Length - 1);
            Console.WriteLine(string.Join(",", _data));
        }

        private async Task MergeSortHelper(int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;
            
                // Рекурсивно сортируем два подмассива
                await MergeSortHelper(low, mid);
                await MergeSortHelper(mid + 1, high);
            
                // Объединяем два отсортированных подмассива
                await Merge(low, mid, high);
            }
        }
    
        private async Task Merge(int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Копируем данные во временные массивы
            Array.Copy(_data.array, low, leftArray, 0, n1);
            Array.Copy(_data.array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = low;

            // Объединяем два подмассива обратно в основной массив
            while (i < n1 && j < n2)
            {
                await MarkOnce(MarkType.Select, low + i, mid + 1 + j);

                if (leftArray[i] <= rightArray[j])
                {
                    _data[k] = leftArray[i];
                    i++;
                }
                else
                {
                    _data[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Копируем оставшиеся элементы из левого подмассива, если они есть
            while (i < n1)
            {
                _data[k] = leftArray[i];
                i++;
                k++;
            }

            // Копируем оставшиеся элементы из правого подмассива, если они есть
            while (j < n2)
            {
                _data[k] = rightArray[j];
                j++;
                k++;
            }

            // Обозначаем точку разделения подмассивов
            MarkPermanentWithoutDelay(MarkType.Pivot, mid);
        }

        /*private async Task Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                
                await Sort(left, middle);
                await Sort(middle + 1, right);
                
                await MergeArray(left, middle, right);
            }
        }

        private async Task MergeArray(int left, int middle, int right)
        {
            int leftArrayLength = middle - left + 1;
            int rightArrayLength = right - middle;
            int[] leftTempArray = new int[leftArrayLength];
            int[] rightTempArray = new int[rightArrayLength];
            int i, j;
            
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = _data[left + i];
            
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = _data[middle + 1 + j];
            
            i = 0;
            j = 0;
            
            int k = left;
            
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    _data[k++] = leftTempArray[i++];
                }
                else
                {
                    _data[k++] = rightTempArray[j++];
                }
            }
            
            while (i < leftArrayLength)
            {
                _data[k++] = leftTempArray[i++];
            }
            
            while (j < rightArrayLength)
            {
                _data[k++] = rightTempArray[j++];
            }
        }*/
        
        
        

        /*private async Task Sort(int low, int high)
        {
            if (low < high)
            {
                int middle = low + (high - low) / 2;
 
                await Sort(low, middle);
                await Sort(middle + 1, high);
 
                await Merge(low, middle, high);
            }
        }*/
        
        /*private async Task Merge(int low, int middle, int high)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = middle - low + 1;
            int n2 = high - middle;
 
            // Create temp arrays
            int[] leftTemp = new int[n1];
            int[] rightTemp = new int[n2];
            int i, j;
 
            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                leftTemp[i] = _data[low + i];
            for (j = 0; j < n2; ++j)
                rightTemp[j] = _data[middle + 1 + j];
 
            // Merge the temp arrays
 
            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;
 
            // Initial index of merged
            // subarray array
            int k = low;
            while (i < n1 && j < n2)
            {
                if (leftTemp[i] <= rightTemp[j])
                {
                    await MarkOnce(MarkType.Select,k, i);
                    _data[k] = leftTemp[i];
                    SwapElements(k, low + i);
                    await Delay();
                    i++;
                }
                else
                {
                    await MarkOnce(MarkType.Select,k, j);
                    _data[k] = rightTemp[j];
                    SwapElements(k, j);
                    await Delay();
                    j++;
                }
                k++;
            }
 
            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                await MarkOnce(MarkType.Select,k, i);
                _data[k] = leftTemp[i];
                SwapElements(k, i);
                await Delay();
                i++;
                k++;
            }
 
            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                await MarkOnce(MarkType.Select,k, j);
                _data[k] = rightTemp[j];
                SwapElements(k, j);
                await Delay();
                j++;
                k++;
            }
        }*/
    }
}