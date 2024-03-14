
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace cli
{
    class createResponseFile
    {
        static void Main(string[] args)
        {

            var bundleCommand = new Command("bundle", "Bundle code files to a single file");

            var languageOption = new Option<string>("--language", "programming language to include in the bundle") { IsRequired = true };
            languageOption.AddAlias("-l");
            bundleCommand.AddOption(languageOption);

            var outputOption = new Option<string>("--output", "File name");
            outputOption.AddAlias("-o");
            bundleCommand.AddOption(outputOption);

            var noteOption = new Option<bool>("--note");
            noteOption.AddAlias("-n");
            bundleCommand.AddOption(noteOption);

            var sortOption = new Option<string>("--sort");
            sortOption.AddAlias("-s");
            bundleCommand.AddOption(sortOption);

            var removeEmptyLinesOption = new Option<bool>("--remove_empty_lines");
            removeEmptyLinesOption.AddAlias("-r");
            bundleCommand.AddOption(removeEmptyLinesOption);

            var authorOption = new Option<string>("--author", "Return creator name");
            authorOption.AddAlias("-a");
            bundleCommand.AddOption(authorOption);

            var createResponseFile = new Command("createRsp", "Create a response file");

            createResponseFile.SetHandler(() =>
            {
                // יצירת משתנים שמייצגים את האופציות ואתחולם
                bool note, removeEmptyLines;
                string author = "", language = "", sort = "", output;
                Console.WriteLine("Enter respons file name:");
                string rspName = Console.ReadLine();

                try
                {
                    // השמת הנתיב של הקובץ תגובה שניצור במשתנה
                    var responseFilePath = Path.Combine(Environment.CurrentDirectory, rspName + ".rsp");

                    Console.WriteLine("enter a name for the new file");
                    output = Console.ReadLine();

                    var extationList = new List<string> { "js", "cc", "java", "py", "cs", "php", "swift", "rb", "kt", "sql","html","all" };
                    bool isValidL = false;
                    Console.WriteLine("enter a program language: ");
                    // בדיקת תקינות אם השפה שהוא הקיש היא סיומת של שפת תכנות ושהוא הקיש משהו 
                    while (!isValidL)
                    {
                        language = Console.ReadLine().ToLower();
                        if (!extationList.Contains(language) || string.IsNullOrEmpty(language))
                        {
                            Console.WriteLine("your language is not valid");
                            Console.WriteLine("enter a program language: ");
                        }
                        else
                            isValidL = true;
                    }


                    Console.WriteLine("enter a sorting option (name or type or no): "); 
                    bool isValidS = false;
                    // בודק אם האופציה מיון היא אחד מהאפשרויות לעיל
                    while (!isValidS)
                    {
                        sort = Console.ReadLine().ToLower();
                        if (sort != "name" && sort != "type" && sort != "no")
                        {
                            Console.WriteLine("you enter an invalid option");
                            Console.WriteLine("enter a sorting option (name or type or no)");
                        }
                        else
                            isValidS = true;
                    }


                    //Console.WriteLine("enter if you want to add note (true or false): ");
                    //note = bool.Parse(Console.ReadLine());
                    //if (note)
                    //    note = true;
                    //else
                    //    note = false;

                    string userInput;
                    do
                    {
                        Console.WriteLine("Enter if you want to add note (true or false): ");
                        userInput = Console.ReadLine().ToLower();

                        if (bool.TryParse(userInput, out note))
                        {

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                        }

                    } while (true);

                    //Console.WriteLine("enter if you want to remove empy lines: ");
                    //removeEmptyLines = bool.Parse(Console.ReadLine());
                    //if (removeEmptyLines)
                    //    removeEmptyLines = true;
                    //else
                    //    removeEmptyLines = false;

                    //בודק אם המשתמש הקיש טרו או פולס אם לא אז הוא מבקש ממנו שוב פעם להקיש
                    string secondUserInput;
                    do
                    {
                        Console.WriteLine("enter if you want to remove empy lines (true or false): ");
                        secondUserInput = Console.ReadLine().ToLower();

                        if (bool.TryParse(secondUserInput, out removeEmptyLines))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                        }

                    } while (true);

                    Console.WriteLine("enter an author name (or no): ");
                    bool isValidA = false;
                    while (!isValidA)
                    {
                        author = Console.ReadLine().ToLower();
                        if (string.IsNullOrEmpty(author))
                        {
                            Console.WriteLine("invalid input. Please enter an author name or no if you dont want to");
                        }
                        else
                            isValidA = true;
                    }



                    var oneLine = new StringBuilder();
                    oneLine.AppendLine($"--output {output}");
                    oneLine.AppendLine($"--language {language}");
                    oneLine.AppendLine($"--note {note}");
                    if (sort != "no")
                        oneLine.AppendLine($"--sort {sort}");
                    oneLine.AppendLine($"--remove_empty_lines {removeEmptyLines}");
                    if (author != "no")
                        oneLine.AppendLine($"--author {author}");

                    using (StreamWriter rspFile = new StreamWriter(responseFilePath))
                    {
                        rspFile.WriteLine(oneLine.ToString());
                    }
                    Console.WriteLine($"creating new respons file: {responseFilePath}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error creating the response file: {e.Message}");
                }

            });

            bundleCommand.SetHandler((output, language, note, sort, removeEmptyLines, author) =>
            {
                string[] allFiles = Array.Empty<string>();
                try
                {
                    string outputFilePath;
                    if (!string.IsNullOrEmpty(output))
                    {
                        //בודק אם זה נתיב מוחלט אם כן משתמשת בנתיב כמו שהוא אם לא יוצר נתיב מוחלט
                        if (Path.IsPathRooted(output))
                        {
                            outputFilePath = output;
                        }
                        else
                        {
                            outputFilePath = Path.Combine(Environment.CurrentDirectory, output);//יוצר קישור שלשם ייכנס קובץ הייצוא
                        }
                    }
                    else
                    {
                        Console.WriteLine("the output is invalid");
                        return;
                    }

                    var extationList = new List<string> { "js", "cc", "java", "py", "cs", "php", "swift", "rb", "kt", "sql","html" };
                   
                    if (!string.IsNullOrEmpty(sort))
                    {
                        if (sort.ToLower() == "name")
                        {
                            if (language.ToLower() == "all")
                            {

                                allFiles = Directory.GetFiles(".", "*.*")
                                                    .Where(file => extationList.Any(ext => file.EndsWith("." + ext)))
                                                    .ToArray();
                                allFiles = allFiles.OrderBy(file => Path.GetFileName(file)).ToArray();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(language) && extationList.Contains(language))
                                {
                                    allFiles = Directory.GetFiles(".", $"*.{language}");
                                    allFiles = allFiles.OrderBy(file => Path.GetFileName(file)).ToArray();
                                }

                                else
                                {
                                    Console.WriteLine("the language is not valid");
                                    return;
                                }

                            }

                        }
                        else if (sort.ToLower() == "type")
                        {
                            if (language.ToLower() == "all")
                            {

                                allFiles = Directory.GetFiles(".", "*.*")
                                                    .Where(file => extationList.Any(ext => file.EndsWith("." + ext)))
                                                    .ToArray();
                                allFiles = allFiles.OrderBy(file => Path.GetExtension(file)).ToArray();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(language) && extationList.Contains(language))
                                {
                                    allFiles = Directory.GetFiles(".", $"*.{language}");
                                    allFiles = allFiles.OrderBy(file => Path.GetExtension(file)).ToArray();
                                }

                                else
                                {
                                    Console.WriteLine("the language is not valid");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (language.ToLower() == "all")
                        {

                            allFiles = Directory.GetFiles(".", "*.*")
                                                .Where(file => extationList.Any(ext => file.EndsWith("." + ext)))
                                                .ToArray();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(language) && extationList.Contains(language))
                                allFiles = Directory.GetFiles(".", $"*.{language}");
                            else
                            {
                                Console.WriteLine("the language is not valid");
                                return;
                            }

                        }
                    }

                    string docPath = Environment.CurrentDirectory;//מכניס למשתנה את הקישור של התיקייה הנוכחית
                                                                  //Console.WriteLine(allFiles);
                                                                  //try
                                                                  //{
                    using (StreamWriter outputFile = new StreamWriter(outputFilePath))//יוצר אובייקט מהמחלקה streamwriter שהאובייקט מכיל את שם קובץ הייצוא שלנו ואת המיקום ששם הוא יווצר
                    {
                        if (note)
                        {
                            outputFile.WriteLine($"// Source code from: {docPath}");
                        }

                        if (!string.IsNullOrEmpty(author))
                        {
                            outputFile.WriteLine($"Author: {author}");
                        }

                        foreach (string file in allFiles)
                        {

                            if (removeEmptyLines)
                            {
                                //Console.WriteLine($"im in remove");
                                Console.WriteLine($"Content of {file} after removing empty lines:");
                                string[] nonEmptyLines = File.ReadAllLines(file).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

                                foreach (string line in nonEmptyLines)
                                {
                                    outputFile.WriteLine(line);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Content of {file}:");
                                outputFile.WriteLine(File.ReadAllText(file));
                            }
                        }
                        Console.WriteLine($"Files have been successfully bundled to {outputFilePath}");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred: {e.Message}");
                }
            }, outputOption, languageOption, noteOption, sortOption, removeEmptyLinesOption, authorOption);
            
            var rootCommand = new RootCommand("Root command for file Bundler CLI");
            rootCommand.AddCommand(bundleCommand);
            rootCommand.AddCommand(createResponseFile);
            rootCommand.Invoke(args);
        }
    }
}

