using CommonDLL;
using System;

namespace SortingAlgorithms
{
    public class SortStrategyFactory
    {
        /// <summary>
        /// Erstellt einen Sortieralgorithmus basierend auf dem Namen
        /// </summary>
        public static ISortStrategy<T> Create<T>(string algorithmName) where T : IComparable<T>
        {
            switch (algorithmName.ToLower())
            {
                case "bubblesort":
                    return new BubbleSortStrategy<T>();

                case "quicksort":
                    return new QuickSortStrategy<T>();

                case "insertionsort":
                    return new InsertionSortStrategy<T>();

                case "bucketsort":
                    return new BucketSortStrategy<T>();

                default:
                    throw new ArgumentException($"Unbekannter Sortieralgorithmus: {algorithmName}");
            }
        }

        /// <summary>
        /// Erstellt den Standard-Sortieralgorithmus (BubbleSort)
        /// </summary>
        public static ISortStrategy<T> CreateDefault<T>() where T : IComparable<T>
        {
            return new BubbleSortStrategy<T>();
        }

        /// <summary>
        /// Alternative: Erstellt einen Sortieralgorithmus basierend auf einem Enum
        /// </summary>
        public static ISortStrategy<T> Create<T>(SortAlgorithmType type) where T : IComparable<T>
        {
            switch (type)
            {
                case SortAlgorithmType.BubbleSort:
                    return new BubbleSortStrategy<T>();

                case SortAlgorithmType.QuickSort:
                    return new QuickSortStrategy<T>();

                case SortAlgorithmType.InsertionSort:
                    return new InsertionSortStrategy<T>();

                case SortAlgorithmType.BucketSort:
                    return new BucketSortStrategy<T>();

                default:
                    throw new ArgumentException($"Unbekannter Sortieralgorithmus: {type}");
            }
        }
    }

    /// <summary>
    /// Enum für die verfügbaren Sortieralgorithmen
    /// </summary>
    public enum SortAlgorithmType
    {
        BubbleSort,
        QuickSort,
        InsertionSort,
        BucketSort
    }
}