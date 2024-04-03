using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class AlgorithmFactory
    {
        public ISortAlgorithm CreateBubble(AlgorithmParameters parameters) => 
            new BubbleSort(parameters);
        
        public ISortAlgorithm CreateInsertion(AlgorithmParameters parameters) => 
            new InsertionSort(parameters);
    }

    public enum SortAlgorithmType
    {
        Bubble,
        Insertion
    }
}