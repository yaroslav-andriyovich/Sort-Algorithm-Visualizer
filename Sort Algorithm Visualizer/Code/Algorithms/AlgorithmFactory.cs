using System;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Algorithms.Species;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.Algorithms
{
    public class AlgorithmFactory
    {
        public ISortAlgorithm Create(SortAlgorithmType sortingType, SortingParameters parameters)
        {
            switch (sortingType)
            {
                case SortAlgorithmType.Bubble:
                    return new BubbleSort(parameters);
                
                case SortAlgorithmType.Insertion:
                    return new InsertionSort(parameters);

                default:
                    throw new InvalidOperationException("Unknown sort algorithm type selected!");
            }
        }
    }

    public enum SortAlgorithmType
    {
        Bubble,
        Insertion
    }
}