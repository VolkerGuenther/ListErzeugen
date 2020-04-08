using System;
using System.Collections.Generic;
using System.Text;

namespace ListeErzeugen.UI
{
    class FileWriter : UIWriter
    {
        protected String FileName;

        public FileWriter(String FileName)
        {
            // FileName is also the name of the property of FileWriter
            // Do distinguish between the property and the method argument use this
            // 
            // this.FileName and FileName are both variables
            // this.FileName is a property of the class FileWriter
            // FileName without this. is the method argument
            this.FileName = FileName;
        }

        public void WriteLineString(string theString)
        {
            // We use FileName without this, because there is no method argument
            using System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, true);
            file.WriteLine(theString);
        }

        public void WriteString(string theString)
        {
            // English training
            // - translate the following sentences to English or to German
            // - translate with e.g. translate.google.com the following sentences
            //
            // Hilfe 
            // ¦ bedeutet, dass Du aus den Übersetzungen getrennt durch ¦ auswählen kannst
            // Beispiel: must ¦ have to = müssen, have to
            // 
            //
            // - dürfen = is allowed
            // - müssen = [must ¦ have to]
            // - darf nicht = ( is not allowed ¦ mustn't ¦ cannot ), muss nicht != must not (wichtig, "falscher Freund"!)) 
            //
            // Versuche zuerst ohne Hilfe zu übersetzen:
            // ==========================================
            // Er darf heute arbeiten
            // Er darf heute nicht arbeiten
            // Er darf nicht nach draussen gehen
            // Er muss arbeiten heute
            // Er muss nicht arbeiten heute
            // Die Namen dürfen nicht identisch sein
            // He must not work today

            // I introduce the local variable FileName
            // Visual Studio gives a warning because the variable FileName is not used.
            String FileName = "my local variable";

            // remove the // in the following line: A local variable cannot have the same name with a method argument
            // String theString = " my local theString";
            // 
            // => Understand the difference of local variable, property and (method) argument
            // When you see a variable, understand quickly what kind of variable it is
            // property variables can always be prefixed by this. to differentiate between local variables and arguments
            // 
            // 
            using System.IO.StreamWriter file = new System.IO.StreamWriter(this.FileName, true);
            file.Write(theString);
        }
    }
}
