using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace mouseSimulation
{
    class Program
    {
        // Details of the excercise

        static int lengthOfDrain;

        static int velocity1;

        static int velocity2;

        static int measuredTime=0;

        static int drive1;

        static int drive2;

        static int meetCounter = 0;

        static int i = 1;

        static int j = 1;

        static void Main(string[] args)
        {

            Console.Write("Type the length of the drain-pipe (m):  ");

            lengthOfDrain = Convert.ToInt32(Console.ReadLine());

            Console.Write("Type the velocity of mouse #1 (m/s): ");

            velocity1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Type the velocity of mouse #2 (m/s): ");

            velocity2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Finally, type a period of time (s): ");

            measuredTime = Convert.ToInt32(Console.ReadLine());

            RunningProccess();

            Console.WriteLine("the two mice've met each other on {0} occasion(s) during {1} s.",meetCounter,measuredTime);
        }


        private static void RunningProccess()
        {
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Two mice started running....");

            Console.WriteLine("------------------------------");

            do 
            {
                Thread.Sleep(1000); 
                
                drive1 = velocity1 * i; // Az első egér által megtett út
                drive2 = velocity2 * j; // A második egér által megtett út

                Console.WriteLine("Drive of the first mouse: "+drive1+" m "); // Első egér pillanatnyi útjának kiíratása 1s -ként

                Console.WriteLine("Drive of the second mouse: "+drive2+" m "); // Második egér pillanatnyi útjának kiíratása 1s -ként

                Console.WriteLine("----------------------------------------------");

                int mod1 = drive1 % lengthOfDrain;

                int mod2 = drive2 % lengthOfDrain;

                if (mod1 == 0 && mod2 == 0)
                {
                    
                    Console.WriteLine("The two mice've reached for an end of the drain simultaneously.....");

                    Console.WriteLine("-------------------------------------------------------------------");

                    meetCounter++; 
               
                }
                else if((mod1 == lengthOfDrain - mod2) && (mod2 == lengthOfDrain - mod1))
                {

                    Console.WriteLine("The two mice meet from opposite.....");
                    meetCounter++;
                
                }
                    
                else if (mod2 + drive2 == drive1)
                {
                    Console.WriteLine("The second mouse catches upt the first one.......");

                    meetCounter++;
                }

                else if(mod1 + drive1 == drive2)
                {
                    Console.WriteLine("The first mouse catches up the second one.........");

                   meetCounter++;
                }

                i++;
                j++;

            }while(i<=measuredTime);

            if (meetCounter > 0)
            {
                Console.WriteLine(String.Format("Two mice've met on {0} occasions during {1} s", meetCounter, measuredTime));

                Console.ReadLine();

            }
            else 
            {
                Console.WriteLine(String.Format("They've never met each other during {0} s",measuredTime));

                Console.ReadLine();
            }
        }
    }
}