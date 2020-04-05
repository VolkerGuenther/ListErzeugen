using System;
using System.Collections.Generic;

// I changed the code a lot for training purposes
// Your version is much shorter and was correct. 
// My version is more flexible. My version can be extended. You don't need to understand what that means at the moment:
// - later we can add validations 
// - the indention (Einrücken mit Tabulatoren) is done by the code, in your version you have to put the spaces manually and you don't use TABs
// - you probably know from e.g. (<- wofür steht die Abkürzug) Word that a tab and spaces are different (you know?, if not, ask me!)
//
// The following code has 2 bugs, the output is not correct
// Find the bugs and fix them.
// Hints: The end tag syntax is wrong for some elements. Set debugMode = true to find the other bug.
namespace ListeErzeugen
{
    class ProjectList
    {
        // Write additional information (i.e. (<- wofür steht die Abkürzung i.e.?) variable values) into the console if set to true
        // You can also use the debugger instead to inspect variable values
        private static readonly bool debugMode = true;

        // Write output to a file
        // Try with writeToFile = true
        private static readonly bool writeToFile = true;

        // File name
        // Please create a directory c:/temp
        // Check https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
        // I copied code from Example #4
        //
        // Check also: https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.8
        // Chapter: Instantiate a String object. Check the documentation about the @ symbol. 
        // Remove the @ symbol and Visual Studio shows you an error
        // If you dont understand, it is ok. It is not very important at the moment.
        static readonly String fileName = @"C:\temp\ListeErzeugen.cs.xml";

        static void Main(string[] args)


        {
            List<Project> listofProject = new List<Project>()
            {
                    new Project()
                    {
                        Id =1,
                        Location = "HCMC",
                        ProjectName = "Beton auf Ameisensäure prüfen",
                        Responsible ="Thich Quan Duc",
                        Order = "422",
                        Customer = "Bird Corp"
                    },
                    new Project()
                    {
                        Id =2,
                        Location = "HCMC",
                        ProjectName = "Beton auf Rattenreste prüfen",
                        Responsible ="Thich Quan Duc",
                        Order = "169",
                        Customer = "Bird Corp"
                    },
            };

            if (writeToFile)
            {
                // Write empty file
                // Remove the following the // in the following line later. Do you understand the difference between 
                // appending and writing to a file?
                System.IO.File.WriteAllText(fileName, "");
            }
            int currentLevel = StartElement("ProjectList", 0);
            for (int i = 0; i < listofProject.Count; i++)
            {
                currentLevel = StartElement("Project", currentLevel);
                WriteElementWithContent("ID", listofProject[i].Id.ToString(), currentLevel);
                WriteElementWithContent("Location", listofProject[i].Location, currentLevel);
                WriteElementWithContent("ProjectName", listofProject[i].ProjectName, currentLevel);
                WriteElementWithContent("Responsible", listofProject[i].Responsible, currentLevel);
                WriteElementWithContent("Order", listofProject[i].Order, currentLevel);
                WriteElementWithContent("Customer", listofProject[i].Customer, currentLevel);
                currentLevel = EndElement("Project", currentLevel);

            }
            currentLevel = EndElement("ProjectList", currentLevel);
            // The next line I commented out. currentLevel will equal 1.
            //currentLevel = endElement("ProjectList", currentLevel);
            if (currentLevel != 0 && debugMode)
            {
                // This is a simple validation: startElement increases the currentLevel. endElement decreases the currentLevel.
                // endElement needs to be called as often as startElement. Because every element that is started has to be ended.
                // An element starts with the start tag and it's attributes and ends with the end tag
                //
                // We always write ERRORs and debug information to console, so we see the information immediately
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("ERROR");
                Console.WriteLine("XML Format is invalid!");
            }


        }

        private static void WriteElementWithContent(String element, String content, int currentLevel)
        {
            WriteTabs(currentLevel);
            // We could put everything into 1 line (task: replace the following lines with just one line Console.WriteLine(...) 
            // but this is easier to read:

            WriteString(String.Concat("<", element, ">"));
            WriteString(content);
            WriteLineString(String.Concat("</", element, ">"));

        }

        private static void WriteString(String theString)
        {
            if (writeToFile)
            {
                using System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
                file.Write(theString);
            }
            else
            {
                Console.Write(theString);
            }
        }

        private static void WriteLineString(String theString)
        {
            if (writeToFile)
            {
                using System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
                file.WriteLine(theString);
            }
            else
            {
                Console.WriteLine(theString);
            }
        }

        private static int StartElement(string element, int currentLevel)
        {
            // The method call to writeTabs could be moved to writeElement
            // In that case the method signature (<= was ist das?) has to be changed
            WriteTabs(currentLevel);
            currentLevel += WriteElement(element, true);
            if (debugMode)
                Console.WriteLine("currentLevel = " + currentLevel);
            return currentLevel;
        }

        private static int EndElement(string element, int currentLevel)
        {
            // Logic test :-) Why currentLevel - 1? Why not currentLevel? 
            WriteTabs(currentLevel - 1);
            currentLevel += WriteElement(element, false);
            if (debugMode)
                Console.WriteLine("currentLevel = " + currentLevel);
            return currentLevel;
        }

        private static int WriteElement(string element, Boolean start)
        {
            // Entweder oder. Wenn Start == true, dann "<", ansonsten "</>"
            String firstString = start ? "<" : "</";
            WriteLineString(String.Concat(firstString, element, ">"));
            // Wenn start == true, dann wird 1 zurückgegeben, ansonsten -1
            int levelModifier = start ? 1 : -1;
            return levelModifier;
        }

        private static void WriteTabs(int count)
        {
            // Example: Level 0 => nothing happens
            // Level 3 => The Console command will be reached twice. That means 2 TABs will be printed
            for (int i = 0; i < count; i++)
            {
                WriteString("\t");
            }
        }
    }
}
