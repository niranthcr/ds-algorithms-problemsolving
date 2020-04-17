 class Program
 {
     public static void Main(string[] args)
     {
         int[] profits = new int[]{60,100,20,40,20};
         int[] deadlines = new int[]{2,1,3,2,1};
         var result = JobSequencing(profits, deadlines);
         System.Console.WriteLine(result);
     }

     public static int[] JobSequencing(int[] profits, int[] deadlines)
     {
         JobSequence[] jobSequences = new JobSequence[deadlines.Length];

         for(int i = 0; i < deadlines.Length; i++)
         {
             jobSequences[i]  = new JobSequence(profits[i], deadlines[i]);
         }
         int[] result = new int[deadlines.Max()];
         var compare = new Compare();
         Array.Sort(jobSequences, compare);
         int resultCapacity = 0;
         for(int i = 0; i < jobSequences.Length; i++)
         {
             int index = jobSequences[i].deadline - 1;
             if(result[index] <= 0)
             {
                 result[index] = i + 1;
                 resultCapacity++;
             }
             else
             {
                 while(index > 0)
                 {
                     index--;
                     if(result[index] == 0)
                     { 
                         result[index] = i + 1;
                         resultCapacity++;
                         break;
                     }
                 }
             }
             if(resultCapacity == result.Length)
                 break;
         }
         return result;
     }
 }
 class Compare : IComparer
 {
     int IComparer.Compare(object x, object y)
     {
         var item1 = (JobSequence)x;
         var item2 = (JobSequence)y;
         return item2.profit.CompareTo(item1.profit);
     }
 }
 class JobSequence
 {
     public int profit { get; set; }
     public int deadline { get; set; }

     public JobSequence(int profit, int deadline)
     {
         this.profit = profit;
         this.deadline = deadline;
     }
 }
