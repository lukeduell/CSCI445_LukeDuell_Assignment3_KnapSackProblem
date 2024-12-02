using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI445_LukeDuell_Assignment3
{
    class Program
    {
        static int Maximum(int one, int two)
        {
            if(one > two)
            {
                return one;
            }
            else
            {
                return two;
            }
        }

        static int KnapSack(int W, int[] weight, int[] val, int n)
        {
            int maxReturn = 0;
            int val_1 = 0, val_2 = 0;
            //checking to see if the number of items or maximum weight is zero
            if(n == 0 || W == 0)
            {
                return 0;
            }
            //checking to see if the weight is more than the number of items
            //this will ensure the numebr of items does not excede the max capacity
            if(weight[n - 1] > W)
            {
                //since the numebr of items excedes the max capacity, we return the number of items minus the last
                return KnapSack(W, weight, val, n - 1);
            }
            else
            {
                //since the number n does not excede the maxm we return the maximum weight of the items that can be carried
                //we're checking to find the optimal number of items that can fit in the knapsack
                val_1 = val[n - 1] + KnapSack(W - weight[n - 1], weight, val, n - 1);
                val_2 = KnapSack(W, weight, val, n - 1);

                maxReturn = Maximum(val_1, val_2);

                return maxReturn;
            }
        }

        static void Main(string[] args)
        {
            int[] dollars = new int[] { 50, 100, 250, 60 };
            int[] pounds = new int[] { 50, 30, 10, 5};
            int knapsackWeight = 45;
            int n = 4;

            Console.WriteLine($"Maximum Profit: {KnapSack(knapsackWeight, pounds, dollars, n)}");

        }
    }
}
