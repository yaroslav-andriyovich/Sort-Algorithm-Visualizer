using System.Threading.Tasks;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms.Species
{
    public class HeapSort : SortAlgorithmBase
    {
        public HeapSort(SortingParameters parameters) 
            : base(parameters)
        {
        }
        
        public override async Task Sort()
        {
            int N = data.Length;

            for (int i = N / 2 - 1; i >= 0; i--)
                await Heapify(N, i);

            for (int i = N - 1; i > 0; i--)
            {
                await MarkAsSelectAndSwap(0, i);
                await Heapify(i, 0);
                MarkPermanentWithoutDelay(MarkType.Pivot, i);
            }
        }
        
        private async Task Heapify(int N, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            
            if (l < N)
            {
                await MarkOnce(MarkType.Select, l, largest);
                
                if (data[l] > data[largest])
                    largest = l;
            }

            if (r < N)
            {
                await MarkOnce(MarkType.Select, r, largest);
                
                if (data[r] > data[largest])
                    largest = r;
            }

            if (largest != i)
            {
                await MarkAsSelectAndSwap(i, largest);
                await Heapify(N, largest);
            }
        }
    }
}