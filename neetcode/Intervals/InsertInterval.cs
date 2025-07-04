using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Intervals;
public class InsertInterval
{
    public static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        for (var i = 0; i < intervals.Length; i++)
        {
            if (newInterval[1] < intervals[i][0])
            {
                result.Add(newInterval);
                result.AddRange(intervals.AsEnumerable().Skip(i));

                return result.ToArray();
            }
            else if (newInterval[0] > intervals[i][1])
            {
                result.Add(intervals[i]);
            }
            else
            {
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            }
        }

        result.Add(newInterval);

        return result.ToArray();
    }
}
