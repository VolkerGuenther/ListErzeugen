using System;

namespace ListeErzeugen
{
    class Project
    {
        public static object Models { get; internal set; }
        public int Id { get; set; }

        public String ProjectName { get; set; }

        public String Customer { get; set; }

        public String Order { get; set; }

        public String Location { get; set; }

        public String Responsible { get; set; }
    }
}
