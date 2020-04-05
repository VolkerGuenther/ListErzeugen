using System;
using System.Collections.Generic;
using System.Text;

namespace ListeErzeugen.UI
{
    interface UIWriter
    {
        public void WriteString(String theString);

        public void WriteLineString(String theString);
    }
}
