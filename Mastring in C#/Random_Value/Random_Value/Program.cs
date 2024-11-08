
using System.Text;
using System.Xml.Schema;
namespace Random_Value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please select an option : ");
                Console.WriteLine("[1] Generate a random number \t\t [2] Generate a random string");
                var selectedoption = Console.ReadLine();
                if (selectedoption == "1")
                {
                    GenerateRandomNumber();
                }
                else if (selectedoption == "2") 
                {
                    GenerateRandomString();
                }
                else
                {
                    Console.WriteLine("Envalid option!!!!!!!!!");
                }

            }
        }
        static void GenerateRandomNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("enter the minimum value = ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("enter the maximum value = ");
            int max = int.Parse(Console.ReadLine());
            var rnd = new Random();
            int val = rnd.Next(min, max);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"random number = {val}");
        }
        private const string capital_words= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string small_words = "abcdefghijklmnopqrstuvwxyz";
        private const string numbers = "013456789";
        private const string sympols = "?!@#$%/&*";

        static void GenerateRandomString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("enter the length of string = ");
            int lengthh = int.Parse(Console.ReadLine());
            string buffer ="";
            int not_includee=0;
            Console.WriteLine("[1] Include capital letters ? yes/no");
            string capital_letters = Console.ReadLine();
            //-------------------------------
            if (capital_letters.Equals("yes", StringComparison.OrdinalIgnoreCase))
                buffer = buffer + capital_words;
            else
                not_includee += 1;
            //-------------------------------
            Console.WriteLine("[2] Include small letters ? yes/no");
            string small_letters = Console.ReadLine();
            //-------------------------------
            if (small_letters.Equals("yes", StringComparison.OrdinalIgnoreCase))
                buffer = buffer + small_words;
            else
                not_includee += 1;
            //-------------------------------
            Console.WriteLine("[3] Include numbers ? yes/no");
            string numbers1 = Console.ReadLine();
            //-------------------------------
            if (numbers1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                buffer = buffer + numbers;
            else
                not_includee += 1;
            //-------------------------------
            Console.WriteLine("[4] Include sympols ? yes/no");
            string sympols1 = Console.ReadLine();
            //-------------------------------
            if (sympols1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                buffer = buffer + sympols;
            else
                not_includee += 1;
            //-------------------------------   
           if (not_includee == 4)
           {
               Console.WriteLine("how to assemble string and you rejected all options!!!!!!!!!!!!!!");                
           }
           else
           {
               var rnd = new Random();
               var sb = new StringBuilder();
               while (sb.Length < lengthh)
               {
                    int range=rnd.Next(0,buffer.Length -1);
                    sb.Append(buffer[range]);
               }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"random string is : {sb}");
           }
        }
    }
}
