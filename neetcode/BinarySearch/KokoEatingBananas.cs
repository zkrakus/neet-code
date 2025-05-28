using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.BinarySearch;
public static class KokoEatingBananas
{
    public static int MinEatingSpeed(int[] piles, int h)
    {
        if (piles == null || piles.Length == 0)
            return -1;


        int left = 1;
        int right = piles.Max();
        int result = right;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanEatAll(piles, h, mid))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        bool CanEatAll(int[] piles, int h, int speed)
        {
            int totalHours = 0;
            foreach (var pile in piles)
            {
                totalHours += (pile + speed - 1) / speed; // same as Math.Ceiling((double)pile / speed)
                if (totalHours > h) return false;
            }

            return true;
        }

        return result;
    }
}
