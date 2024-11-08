namespace App_cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[CMD] ");
                var input = Console.ReadLine().Trim();
                if (input=="clear")
                {
                    Console.Clear();
                }
                else
                {
                    int WhiteSpaceIndex = input.IndexOf(' ');
                    var command = input.Substring(0, WhiteSpaceIndex).Trim();
                    var path = input.Substring(WhiteSpaceIndex + 1).Trim();

                    if (path.Contains("->") == true)
                    {
                        var arrow = path.LastIndexOf('>');
                        var old = path.Substring(0, arrow - 1).Trim();
                        var fresh = path.Substring(arrow + 1).Trim();
                        var dir = Directory.Exists(old);
                        var file = File.Exists(old);
                        string[] commands = new string[] { "rename", "move", "mkdir", "mkfile" };
                        if (file || dir)
                        {
                            if (command == commands[0])
                            {
                                if (dir)
                                {
                                    string dest = old.Substring(0, old.LastIndexOf('\\')).Trim() + '\\' + fresh;
                                    Directory.Move(old, dest);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Success the process.");
                                }
                                else if (file)
                                {
                                    string dest = old.Substring(0, old.LastIndexOf('\\')).Trim() + '\\' + fresh;
                                    File.Move(old, dest);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Success the process.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This path incorrect!!");
                                }
                            }
                            else if (command == commands[1])
                            {
                                try
                                {
                                    if (dir)
                                    {
                                        string dest = fresh + old.Substring(old.LastIndexOf('\\'));
                                        Directory.Move(old, dest);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Success the process.");
                                    }
                                    else if (file)
                                    {
                                        string dest = fresh + old.Substring(old.LastIndexOf('\\'));
                                        File.Move(old, dest);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Success the process.");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("The new location incorrect!!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Write the command true.");
                                }

                            }
                            else if (command == commands[2])
                            {
                                if (dir)
                                {
                                    Directory.CreateDirectory(old + "\\" + fresh);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Success the process.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This input not directory");
                                }
                            }
                            else if (command == commands[3])
                            {
                                if (dir)
                                {
                                    using (FileStream fs = File.Create(old + "\\" + fresh))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Success the process.");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This input not directory");
                                }
                            }
                            else
                            {
                                Console.WriteLine("INVALID COMMAND!!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This path incorrect!!");
                        }
                    }
                    else
                    {
                        var dir = Directory.Exists(path);
                        var file = File.Exists(path);
                        string[] commands = new string[] { "list", "info", "remove", "read" };
                        if (file || dir)
                        {
                            if (command == commands[0])
                            {
                                if (dir)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    foreach (var getfile in Directory.GetFiles(path))
                                    {
                                        var packslach = getfile.LastIndexOf('\\');
                                        Console.WriteLine(getfile.Substring(packslach + 1));
                                    }
                                    foreach (var getdir in Directory.GetDirectories(path))
                                    {
                                        var packslach = getdir.LastIndexOf('\\');
                                        Console.WriteLine(getdir.Substring(packslach + 1));
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("sorry this path of file not directory");
                                }

                            }
                            else if (command == commands[1])
                            {
                                if (file)
                                {
                                    var fileinfo = new FileInfo(path);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Type : File");
                                    Console.WriteLine($"Created at : {fileinfo.CreationTime}");
                                    Console.WriteLine($"Last Modified at : {fileinfo.LastWriteTime}");
                                    Console.WriteLine($"Size as bytes : {fileinfo.Length}");


                                }
                                else if (dir)
                                {
                                    var dirinfo = new DirectoryInfo(path);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Type : Directory");
                                    Console.WriteLine($"Created at : {dirinfo.CreationTime}");
                                    Console.WriteLine($"Last Modified at : {dirinfo.LastWriteTime}");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Sorry this path incorrect");
                                }


                            }
                            else if (command == commands[2])
                            {
                                if (file)
                                {
                                    File.Delete(path);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Succes of the process.");
                                }
                                else if (dir)
                                {
                                    Directory.Delete(path);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Succes of the process.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This file/Directory does not exist.");
                                }
                            }
                            else if (command == commands[3])
                            {
                                if (file)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(File.ReadAllText(path));
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Sorry this path is directory not file");
                                }


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("INVALID COMMAND!!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This path incorrect!!");
                        }

                    }
                }
               
            }
        }
    }
}
