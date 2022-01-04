using System;
using System.Collections.Generic;
using System.IO;

namespace FilesWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---{Options}---");
                Console.WriteLine("1 = FilesAndDirectory");
                Console.WriteLine("2 = ReadStream");
                Console.WriteLine("3 = WriteStream");
                Console.WriteLine("4 = H1 Queue Operations Menu");
                Console.WriteLine("---{Options}---");

                Console.Write("\nI choose: ");
                char usr = Console.ReadKey().KeyChar;

                Console.Clear();

                switch (usr)
                {
                    case '1':
                        FilesAndDirectory();
                        break;
                    case '2':
                        ReadStream();
                        break;
                    case '3':
                        WriteStream();
                        break;
                    case '4':
                        OperationsMenu();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Sry option doesn't exist. Please referre to the options above!");
                        break;
                }
            }

            static void FilesAndDirectory()
            {
                File.WriteAllText(@".\StarWars.txt", "Han shot first!");
                string content = File.ReadAllText(@".\StarWars.txt");

                Console.WriteLine(content);

                File.Delete(@".\StarWars.txt");
                Console.WriteLine("File deleted.\n");

                Console.ReadKey();

                Directory.CreateDirectory(@".\Droids");
                File.WriteAllText(@".\Droids\R2D2.txt", "beep bop");

                Directory.Delete(@".\Droids", true);

                foreach (string file in Directory.GetFiles(@".\"))
                {
                    Console.WriteLine(file);
                }

                Console.ReadKey();
            }

            static void ReadStream()
            {
                File.WriteAllText(@".\Movies.txt", "Diamonds Are Forever (1975)\nA View To Kill (1985)\nCasino Royale (2006)");

                var file = new FileStream(@".\Movies.txt", FileMode.Open);
                var reader = new StreamReader(file);

                List<string> movies = new List<string>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    movies.Add(line);
                }

                foreach (string movie in movies)
                {
                    Console.WriteLine(movie);
                }

                reader.Close();

                Console.ReadKey();
            }

            static void WriteStream()
            {
                File.WriteAllText(@".\Movies.txt", "Diamonds Are Forever (1975)\nA View To Kill (1985)\nCasino Royale (2006)");

                var file = new FileStream(@".\Movies.txt", FileMode.Open);
                var writer = new StreamWriter(file);

                List<string> actors = new List<string>()
            {
                "Mark Hamill",
                "Harrison Ford",
                "Carrie Fisher"
            };

                foreach (string actor in actors)
                {
                    writer.WriteLine(actor);
                    Console.WriteLine(actor);
                }

                writer.Close();

                Console.ReadKey();
            }

            static void OperationsMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---{H1 Queue Operations Menu}---");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n{Options}");
                    Console.WriteLine("1 = Add file");
                    Console.WriteLine("2 = Delete file");
                    Console.WriteLine("3 = Display files");
                    Console.WriteLine("4 = Add folder");
                    Console.WriteLine("5 = Search for file in folder");
                    Console.WriteLine("6 = Exit");
                    Console.WriteLine("{Options}");

                    Console.Write("\nI choose: ");
                    char usr = Console.ReadKey().KeyChar;

                    Console.Clear();

                    if (usr == '6')
                        break;

                    switch (usr)
                    {
                        case '1':
                            FileAdd();
                            break;
                        case '2':
                            FileDelete();
                            break;
                        case '3':
                            FileDisplay();
                            break;
                        case '4':
                            FolderAdd();
                            break;
                        case '5':
                            FileSearch();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Sry option doesn't exist. Please referre to the options above!");
                            break;
                    }
                }
            }

            static void FileAdd()
            {
                Console.WriteLine("---{Add File}---\n");
                Console.WriteLine(@"Default file path '.\'");

                Console.Write("[Path]: ");
                string filePath = Console.ReadLine();
                Console.Write("[Name]: ");
                string fileName = Console.ReadLine();
                Console.Write("[Context]: ");
                string fileContext = Console.ReadLine();

                File.WriteAllText(filePath+fileName, fileContext);

                Console.WriteLine("\nAdded file: ");
                Console.WriteLine(filePath+fileName);

                Console.ReadKey();
            }

            static void FileDelete()
            {
                Console.WriteLine("---{Delete File}---\n");
                Console.WriteLine(@"Default file path '.\'");

                Console.Write("[Path]: ");
                string filePath = Console.ReadLine();
                Console.Write("[Name]: ");
                string fileName = Console.ReadLine();

                File.Delete(filePath + fileName);

                Console.WriteLine("\nDeleted file: ");
                Console.WriteLine(filePath + fileName);

                Console.ReadKey();
            }

            static void FileDisplay()
            {
                Console.WriteLine("---{Display file}---\n");
                Console.WriteLine(@"Default file path '.\'");

                Console.Write("[Path]: ");
                string filePath = Console.ReadLine();
                Console.Write("[Name]: ");
                string fileName = Console.ReadLine();

                var file = new FileStream(filePath+fileName, FileMode.Open);
                var reader = new StreamReader(file);
                List<string> fileText = new List<string>();

                Console.WriteLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    fileText.Add(line);
                }

                foreach (string text in fileText)
                {
                    Console.WriteLine(text);
                }

                reader.Close();

                Console.WriteLine("\nDisplayed file: ");
                Console.WriteLine(filePath + fileName);

                Console.ReadKey();
            }

            static void FolderAdd()
            {
                Console.WriteLine("---{Add Folder}---\n");
                Console.WriteLine(@"Default file path '.\'");

                Console.Write("[Path]: ");
                string folderPath = Console.ReadLine();
                Console.Write("[Name]: ");
                string folderName = Console.ReadLine();

                Directory.CreateDirectory(folderPath+folderName);

                Console.WriteLine("\nAdded file: ");
                Console.WriteLine(folderPath + folderName);

                Console.ReadKey();
            }

            static void FileSearch()
            {
                Console.WriteLine("---{Search File}---\n");
                Console.WriteLine(@"Default file path '.\'");

                Console.Write("[Path]: ");
                string folderPath = Console.ReadLine();

                foreach (string file in Directory.GetFiles(folderPath))
                {
                    Console.WriteLine(file);
                }

                Console.WriteLine("\nFiles found in: ");
                Console.WriteLine(folderPath);

                Console.ReadKey();
            }
        }
    }
}
