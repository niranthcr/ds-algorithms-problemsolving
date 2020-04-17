 class Program
 {
     public static void Main(string[] args)
     {
         int[] profit = new int[]{10,5,15,7,6,18,3};
         int[] weight = new int[]{2,3,5,7,1,4,1};
         int capacity = 15;
         var result = Knapsack(profit, weight, capacity);
         System.Console.WriteLine(result);
     }

     public static double Knapsack(int[] profit, int[] weight, int capacity)
     {
         ItemValue[] itemValues = new ItemValue[weight.Length];
         for(int i = 0; i < weight.Length; i++)
         {
             itemValues[i] = new ItemValue(weight[i], profit[i], i);
         }
         var cmp = new Compare();
         Array.Sort(itemValues, cmp);
         double maxProfit = 0;
         foreach(var item in itemValues)
         {
             int curWt = item.weight;
             int curProfit = item.profit;

             if(capacity - curWt >= 0)
             {
                 capacity -= curWt;
                 maxProfit += curProfit;
             }
             else
             {
                 double weightFrac = (double)capacity / (double)item.weight;
                 maxProfit = maxProfit + (item.profit * weightFrac);
                 break;
             }
         }
         return maxProfit;
     }
 }
 class Compare : IComparer
 {
     int IComparer.Compare(object x, object y)
     {
         var item1 = x as ItemValue;
         var item2 = y as ItemValue;
         return item2.cost.CompareTo(item1.cost);
     }
 }
 public class ItemValue
 {
     public int weight, profit, index;
     public double cost;
     public ItemValue(int weight, int profit, int index)
     {
         this.weight = weight;
         this.profit = profit;
         this.index = index;
         this.cost = profit / weight;
     }
 }
