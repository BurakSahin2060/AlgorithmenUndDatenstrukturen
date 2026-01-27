using CommonDLL;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class BucketSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableCollection<T> c)
        {
            int n = c.Count();
            if (n <= 1) return;

            // Erstellen der Buckets (Anzahl = n für Einfachheit)
            List<T>[] buckets = new List<T>[n];
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<T>();
            }

            // Min und Max finden
            T min = c.Get(0);
            T max = c.Get(0);
            for (int i = 1; i < n; i++)
            {
                T val = c.Get(i);
                if (val.CompareTo(min) < 0) min = val;
                if (val.CompareTo(max) > 0) max = val;
            }

            // Annahme: T kann zu double konvertiert werden (z.B. für int, double; funktioniert nicht für komplexe Typen wie Person)
            double minVal = Convert.ToDouble(min);
            double maxVal = Convert.ToDouble(max);
            double range = maxVal - minVal;
            if (range == 0) return; // Alle Werte gleich

            // Elemente in Buckets verteilen
            for (int i = 0; i < n; i++)
            {
                T val = c.Get(i);
                double dval = Convert.ToDouble(val);
                int bucketIndex = (int)(((dval - minVal) / range) * (n - 1));
                buckets[bucketIndex].Add(val);
            }

            // Jeden Bucket sortieren (mit integrierter List.Sort, die CompareTo verwendet)
            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort((a, b) => a.CompareTo(b));
            }

            // Sortierte Liste zusammenfügen
            List<T> sorted = new List<T>();
            for (int i = 0; i < n; i++)
            {
                sorted.AddRange(buckets[i]);
            }

            // Sortierte Werte zurück in die Collection schreiben (über Swaps, um die Reihenfolge anzupassen)
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (c.Get(j).CompareTo(sorted[i]) == 0)
                    {
                        c.Swap(i, j);
                        break;
                    }
                }
            }
        }
    }
}