using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Intervals;
internal class MergeIntervals
{
    public static int[][] Merge(int[][] intervals)
    {
        var result = new List<int[]>();
        if (intervals is null || intervals.Length == 0)
            return result.ToArray();
        

        Array.Sort(intervals, (a, b) => {
            int cmp = a[0].CompareTo(b[0]);
            return cmp != 0 ? cmp : a[1].CompareTo(b[1]);
        });


        int[] mergedInterval = intervals[0];
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] current = intervals[i];

            // If current interval overlaps with mergedInterval
            if (current[0] <= mergedInterval[1])
            {
                // Merge by extending the end
                mergedInterval[1] = Math.Max(mergedInterval[1], current[1]);
            }
            else
            {
                // No overlap: push the completed mergedInterval and move to the next
                result.Add(mergedInterval);
                mergedInterval = current;
            }
        }

        // Add the last merged interval
        result.Add(mergedInterval);

        return result.ToArray();
    }
}
