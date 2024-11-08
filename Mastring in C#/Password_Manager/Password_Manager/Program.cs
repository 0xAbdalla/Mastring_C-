using System.Text;

namespace Password_Manager
{
    internal class Program
    {
        private static readonly Dictionary<string, string> passwords = new();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\t\t\t\t\t\t[ PASSWORD MANAGER ]\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. List of all passwords");
                Console.WriteLine("2. Get password");
                Console.WriteLine("3. Delete password");
                Console.WriteLine("4. Add password");
                Console.WriteLine("5. Change password");
                Console.WriteLine("6. Exit");
                Console.Write("What do you need ??" );
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    list_of_all_passwords();
                }
                else if (input == 2)
                {
                    get_password();
                }
                else if (input == 3)
                {
                    delete_password();
                }
                else if (input == 4) 
                {
                    add_password();
                }else if (input == 5)
                {
                    change_password();
                }
                else if (input == 6)
                {
                    break;
                }


            }
        }
        static void list_of_all_passwords()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var password in passwords) 
            {
                Console.WriteLine($"{password.Key} = {password.Value}");
            }
        }
        static void get_password()
        {
            Console.WriteLine("Enter the website/app name : ");
            var webapp = Console.ReadLine();
            if (passwords.ContainsKey(webapp))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{webapp}={passwords[webapp]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry the website/app name not exist.");
            }
        }
        static void delete_password()
        {
            Console.WriteLine("Enter the website/app name : ");
            var webapp = Console.ReadLine();
            if (passwords.ContainsKey(webapp))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                passwords.Remove(webapp);
                savepassword();
                Console.WriteLine("Success removing.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry the website/app name not exist.");
            }
        }
        static void add_password()
        {
            Console.WriteLine("Enter the website/app name :");
            var webapp = Console.ReadLine();
            Console.WriteLine("Enter the password :");
            var password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            passwords.Add(webapp, password);
            savepassword();
            Console.WriteLine($"{webapp}={passwords[webapp]}");
        }
        static void change_password()
        {
            Console.WriteLine("Enter the website/app name :");
            var webapp = Console.ReadLine();
            if (!passwords.ContainsKey(webapp))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry the website/app name not exist.");
            }
            else
            {
                Console.WriteLine("Enter the new password :");
                var newpassword = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                passwords[webapp] = newpassword;
                savepassword();
                Console.WriteLine($"{webapp}={passwords[webapp]}");
            }
        }

        private static void readpassword()
        {
            var readtext = File.ReadAllText("C:\\Users\\HP\\Desktop\\passwords.txt");
            foreach (var line in readtext.Split(Environment.NewLine)) 
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var equal = line.IndexOf("=");
                    var webapp = line.Substring(0, equal).Trim();
                    var password = line.Substring(equal + 1).Trim();
                    passwords.Add(webapp, password);
                }
            }
        }
        private static void savepassword()
        {
            var sb = new StringBuilder();
            foreach (var password in passwords) 
            {
                sb.AppendLine($"{password.Key} = {password.Value}");
            }
            File.WriteAllText("C:\\Users\\HP\\Desktop\\passwords.txt",sb.ToString());
        }

    }
}
