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

            //Step 1
            int amount = ReadInt("Ange antalet löner: ");

            Console.WriteLine();

            //Step 2
            ProcessSalaries(amount);
        }

        static int ReadInt(string question)
        {
            bool loop = false;
            int quantity = 0;


            do
            {
                try
                {
                    Console.Write(question);
                    quantity = int.Parse(Console.ReadLine()); //TEST! !!!!!!!!!!!!!!!----------------------

                    loop = false;


                    // DON'T KNOW IF APPROVED!
                        if (quantity < 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("För ny beräkning håll inne valfri tangent - ESC avslutar");
                            Console.ResetColor();
                            ConsoleKeyInfo kvt;
                            kvt = Console.ReadKey();
                            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                            {
                                loop = true;
                            }
                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }
                        
                                                                                      
                         }

                    }
                    catch // !! INTE KLAR MED DETTA ÄN !!
                        {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("FEL! {0} tolkas inte som ett heltal.", quantity); 
                        Console.WriteLine();
                        loop = true;                   
                        }

                } while (loop == true);
 
            return quantity;
            }



        static void ProcessSalaries(int count)
        {           
            int[] payment = new int[count];
            int[] presentation = new int[count];
            // Step 2
            bool loop = true;
            do
                try
                {
                    for (int i = 0; count > i; ++i)
                    {
                        Console.Write("Ange lön nummber {0,2}: ", i + 1);
                        payment[i] = int.Parse(Console.ReadLine());
                        presentation[i] = payment[i];
                        loop = false;                        
                    }
                }
                catch
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("FEL! Kunde inte läsas in som ett hel tal");
                        Console.ResetColor();
                        Console.WriteLine();
                        loop = true;

                    } while (loop == true);


            
            
            

            //Step 3
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
                      
            int col = 1;
                for (int i = 0; i < payment.Length; ++i)
                    {
                        Console.Write("   {0,5} ", presentation[i]); // Presentation variabel används här

                            if (col > 2)
                        {
                            col = 0;
                            Console.WriteLine();
                        }
                    ++col;
                    }            
                    
            Console.WriteLine();                        
        }
    }
}
