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

                case SortAlgorithmType.Selection:
                    return new SelectionSort(parameters);
                
                case SortAlgorithmType.Insertion:
                    return new InsertionSort(parameters);
                
                case SortAlgorithmType.Merge:
                    return new MergeSort(parameters);

                case SortAlgorithmType.Quick:
                    return new QuickSort(parameters);

                default:
                    throw new InvalidOperationException("Selected unknown sort type!");
            }
        }
    }

    public enum SortAlgorithmType
    {
        Bubble,
        Selection,
        Insertion,
        Merge,
        Quick
    }
}