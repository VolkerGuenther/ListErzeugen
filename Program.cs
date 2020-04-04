using System;
using System.Collections.Generic;

namespace ListeErzeugen
{
    class ProjectList
    {
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
            Console.WriteLine("<ProjectList>");
            for (int i = 0; i <listofProject.Count; i++)
            {
                
                Console.WriteLine("      <Project>");
                Console.WriteLine($"        <ID>{listofProject[i].Id}</ID>");
                Console.WriteLine($"        <Location>{listofProject[i].Location}</Location>");
                Console.WriteLine($"        <ProjectName>{listofProject[i].ProjectName}</ProjectName>");
                Console.WriteLine($"        <Responsible>{listofProject[i].Responsible}</Responsible>");
                Console.WriteLine($"        <Order>{listofProject[i].Order}</Order>");
                Console.WriteLine($"        <Customer>{listofProject[i].Customer}</Customer>");
                Console.WriteLine("      </Project>");
                Console.WriteLine("test");
                
            }
            Console.WriteLine("</ProjectList>");


        }
    }
}
