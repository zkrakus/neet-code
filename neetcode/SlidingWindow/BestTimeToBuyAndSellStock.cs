using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.SlidingWindow;
public static class BestTimeToBuyAndSellStock
{
    public static int MaxProfit(int[] prices)
    {
        if (prices is null || prices.Length < 2)
            return 0;

        int minPricePointer = 0;
        int maxPricePointer = 0;
        int maxProfit = prices[maxPricePointer] - prices[minPricePointer];

        for (int i = 1; i < prices.Length; i++)
        {
            var profit = prices[i] - prices[minPricePointer];
            maxProfit = Math.Max(profit, maxProfit);

            if (prices[i] < prices[minPricePointer])
                minPricePointer = i;
            else if (prices[i] > prices[maxPricePointer])
                maxPricePointer = i;
        }

        return maxProfit;
    }
}
