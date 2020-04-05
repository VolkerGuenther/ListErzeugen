using System;
using System.Collections.Generic;
using System.Text;

namespace ListeErzeugen.UI
{
    class ConsoleWriter : UIWriter
    {
        public void WriteLineString(string theString)
        {
            Console.WriteLine(theString);
        }

        public void WriteString(string theString)
        {
            Console.Write(theString);
        }
    }
}
