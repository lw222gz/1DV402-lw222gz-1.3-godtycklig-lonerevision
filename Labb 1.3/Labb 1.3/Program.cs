using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Read in the amount of salaries with a method and return that value to a variabel.
            //Step 2: Send the amount of salaries to a new method and read in the salaries with a for-loop.
            //Step 3: Calculate all wanted values, avarage, diffrence, median and present them.
            //Step 4: Add all rules, amunt > 2, try-catch if not a valid number etc.
            //Step 5: Tidy up the code.

            int amount = 0;           
            
            //the loop for the entire program
            do
            {
                
                    Console.Clear();
                    amount = ReadInt("Ange antalet löner: ");
                                           
                    Console.WriteLine();

                    if (amount > 1)
                    {
                        ProcessSalaries(amount);
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("För liten mängd löner.");
                        Console.ResetColor();
                    }
                
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck valfri tangent för att göra en omberäkning - Esc avslutar");
                Console.ResetColor();

            
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
           
        }

        static int ReadInt(string prompt)
        {
          
            int quantity = 0;
            
            do
            {
                string input;
                Console.Write(prompt);
                input = Console.ReadLine();
                try
                {
                    
                    quantity = int.Parse(input);
                    break;
                                          
                }
                catch
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal", input);
                        Console.ResetColor();
                        Console.WriteLine();
                                          
                    }

                } while (true);
 
            return quantity;                                              
            }



        static void ProcessSalaries(int quantity)
        {

        int[] payment = new int[quantity];
        
        //reads in the values to an array
        for (int i = 0; i < quantity; ++i)
            {
               // string.Format("Ange lön nummer {0}:", i+1)
                payment[i] = ReadInt("Ange lön nr: "+ (1+i) +": ");                
            }                    
        
        //copying the array for presentation reasons.
        int[] presentation = (int[])payment.Clone();


        // calculating the median, avarage and  wage diffriential  
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");

            Array.Sort(payment);
                       
            int diffrence = payment.Max() - payment.Min();
            
            Console.WriteLine("Löneskillnad :       {0:c0}", diffrence);           
            Console.WriteLine("Medevärdet   :       {0:c0}", payment.Average());
            
            if (payment.Length % 2 == 0)
            {
                int Middlenumber1 = payment.Length / 2;
                int Middlenumber2 = payment.Length / 2 - 1;
                int median = (payment[Middlenumber1] + payment[Middlenumber2]) / 2;
                Console.WriteLine("Medianen     :       {0:c0}", median);
            }

            if (payment.Length % 2 == 1)
            {
                int UnEvenMedian = payment.Length / 2;
                Console.WriteLine("Medianen     :       {0:c0}", payment[UnEvenMedian]);
            }

            Console.WriteLine("-------------------------------------------------");
               
           //presentation of the array values with use of the clone.        
                for (int i = 0; i < payment.Length; ++i)
                    {
                        if (i % 3 == 0)
                        {                          
                            Console.WriteLine();
                        } 

                        Console.Write("   {0,5} ", presentation[i]);                                            
                    }            
                    
            Console.WriteLine();                        
        }
    }
}
