using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMatchingPermutations
{
    class Program
    {
        static void Main(string[] args)
        {

            //read number of queries
            int.TryParse(Console.ReadLine(), out int numOfQueries);

            for (int i = 0; i<numOfQueries; i++)
            {
                Int64 elements = 0;
                Int64 num = 0;
                decimal totalPossibleCombinations = 0;
                Int64 totalNumberOfPairTimes2 = 0;
                Int64 pair = 0;
                decimal totalCombinations = 0;
                decimal pNumerator = 0;
                Int64 pDenominator = 0;
                decimal totalPossibleForOnePairs = 0;
                decimal totalPossibleForAllPairs = 0;
                Int64 elementsAndPairs = 0;
                decimal overLapOfAllPairs = 0;

                //read number of elements
                Int64.TryParse(Console.ReadLine(), out elements);

                //readline then parse by "space"
                string line = " ";
                string[] list;

                try
                {
                    using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                    {
                        line = sr.ReadLine();
                    }
                }
                catch(Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {

                }

                
                line = line.Trim();
                list = line.Split(' ');

                num = elements;
                totalPossibleCombinations = 1;
                Dictionary<int, int> elementValue = new Dictionary<int, int>();
                for (int j = 0; j<elements; j++)
                {
                    {
                        int val = Convert.ToInt32(list[j]);
                        totalPossibleCombinations *= (num--);

                        if (elementValue.ContainsKey(val))
                        {
                            elementValue[val] = elementValue[val] + 1;
                            pair = pair + 1;
                        }
                        else
                        {
                            elementValue.Add(val, 1);
                        }                        
                    }
                }
                
                totalNumberOfPairTimes2 = Convert.ToInt32(Math.Pow(2, pair));
                
                
                totalCombinations = totalPossibleCombinations / totalNumberOfPairTimes2;

                //Determine Pair Overlap, if pairs exist
                if(pair > 0)
                {
                    //How many where A not next to A = Total - A is Next to A
                    //Treat AA as one  
                    //Now Pair total possible = (n-1)! / (pairs - 1)2!

                    //(N-1)!

                    pNumerator = totalPossibleCombinations / Convert.ToDecimal(elements);

                    //(pairs-1)!
                    pDenominator = totalNumberOfPairTimes2 / 2;

                    totalPossibleForOnePairs = Convert.ToDecimal(pNumerator / pDenominator);

                    totalPossibleForAllPairs = totalPossibleForOnePairs * (pair);

                    //Overlap.  If more than one pair remove overlap
                    //Treat Each pair as 1.  So for AABB there are two pairs.   A B and B A where A = AA and B = BB or 2! overlap

                    if (pair > 1)
                    {
                        elementsAndPairs = elementValue.Count();

                        Int64 o = elementsAndPairs;
                        overLapOfAllPairs = o;

                        while (o > 1)
                        {
                            overLapOfAllPairs *= (--o);
                        }
                    }
                    
                }

                decimal result = totalCombinations - (totalPossibleForAllPairs - overLapOfAllPairs);


                double print = Convert.ToDouble(result) % (Math.Pow(10, 9) + 7d);
                Console.WriteLine(print.ToString());
            }
            
            //Reset for next query

            Console.ReadKey();
        }
    }
}
