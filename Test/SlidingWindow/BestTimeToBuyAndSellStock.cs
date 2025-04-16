using neetcode.SlidingWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SlidingWindow;
public class BestTimeToBuyAndSellStockTests
{
    [Fact]
    public void NullArray_ReturnsZero()
    {
        int[] prices = null;
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(0, result);
    }

    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        int[] prices = new int[] { };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleElement_ReturnsZero()
    {
        int[] prices = { 5 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(0, result);
    }

    [Fact]
    public void NoProfit_DecreasingPrices()
    {
        int[] prices = { 9, 7, 4, 2 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(0, result);
    }

    [Fact]
    public void BestProfit_OneOpportunity()
    {
        int[] prices = { 1, 5 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(4, result);
    }

    [Fact]
    public void BestProfit_MultipleOpportunities()
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(5, result); // Buy at 1, sell at 6
    }

    [Fact]
    public void FlatPrices_NoProfit()
    {
        int[] prices = { 3, 3, 3, 3 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(0, result);
    }

    [Fact]
    public void BuyAfterSellScenario()
    {
        int[] prices = { 5, 10, 3, 8 };
        int result = BestTimeToBuyAndSellStock.MaxProfit(prices);
        Assert.Equal(5, result); // Buy at 3, sell at 8
    }
}
