using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string w;
            int i;
            double ttl = 0;
            List<TimeSheetEntry> ents = new List<TimeSheetEntry>();
            Console.Write("Enter what you did: ");
            w = Console.ReadLine();
            TimeSheetEntry ent = new TimeSheetEntry();
            ent.HoursWorked = yesOrNo(); //we place in the hours worked the return from the method
            ent.WorkDone = w;
            ents.Add(ent);
            Console.Write("Do you want to enter more time:");
            String conditional = Console.ReadLine(); // i changed the boolean and noy i check the string that we read from the console
            if (conditional.ToUpper() == "YES") //i turn it into uppercase because it can me valid if you say "yes" or "YES"
            {  //also if you put things like "ye" or "yess" it should don't work and don't enter in the do/while so i think this way it works quite well.
                do
                {
                    Console.Write("Enter what you did: ");
                    w = Console.ReadLine();
                    ent.HoursWorked = yesOrNo(); //we place in the hours worked the return from the method
                    ent.WorkDone = w;
                    ents.Add(ent);
                    Console.Write("Do you want to enter more time:");
                    conditional = Console.ReadLine();
                } while (conditional.ToUpper() == "YES");
            }
            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.Contains("Acme"))
                {
                    ttl += i;
                }
            }
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + ttl * 150 + " for the hours worked.");
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.Contains("ABC"))
                {
                    ttl += i;
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + ttl * 125 + " for the hours worked.");
            for (i = 0; i < ents.Count; i++)
            {
                ttl += ents[i].HoursWorked;
            }
            if (ttl > 40)
            {
                Console.WriteLine("You will get paid $" + ttl * 15 + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + ttl * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static double yesOrNo() //i created a method to check if the string that comes from the console can be parsered to double
        { //and i say double because i saw in the correct code that we can place double numbers in it
            Console.Write("How long did you do it for: ");
            String number = Console.ReadLine();
            double i;
            if (Double.TryParse(number, out i)) //if it can be parsered we return the double
            {
                return i;
            }
            Console.WriteLine("Invalid number given"); //if not we call the method again until it can do the parse
            yesOrNo();
            return 0;           
        }
    }

    public class TimeSheetEntry
    {
        public string WorkDone;
        public double HoursWorked;
    }
}
