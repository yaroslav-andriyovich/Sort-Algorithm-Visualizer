namespace Sort_Algorithm_Visualizer.Code.Algorithms
{
    public class AlgorithmFactory
    {
        public ISortAlgorithm CreateBubble(int[] data, SwapCallback swapCallback) => 
            new BubbleSort(data, swapCallback);
    }

    public enum SortAlgorithmType
    {
        BubbleSort
    }
}