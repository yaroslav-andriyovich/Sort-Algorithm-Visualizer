using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class AlgorithmFactory
    {
        public ISortAlgorithm CreateBubble(int[] data, Delay delay, SwapCallback swapCallback) => 
            new BubbleSort(data, delay, swapCallback);
        
        public ISortAlgorithm CreateInsertion(int[] data, Delay delay, SwapCallback swapCallback) => 
            new InsertionSort(data, delay, swapCallback);
    }

    public enum SortAlgorithmType
    {
        Bubble,
        Insertion
    }
}