using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        //collection 

        private List<Astronaut> astronauts;

        public int Count
          => this.astronauts.Count;
        public SpaceStation(string listName, int capacity)
        {
            this.Capacity = capacity;
            this.Name = listName;


            astronauts = new List<Astronaut>(capacity);
            

        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Astronaut someAustronaut)
        {         
            //add if there is space
            
           if(astronauts.Count< this.Capacity)
            {
                astronauts.Add(someAustronaut);
                
            }
        }

        public bool Remove(string name)
        {

            for (int i = 0; i < astronauts.Count; i++)
            {

                if (astronauts[i].Name == name)
                {
                    this.astronauts.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            var austrPerson = this.astronauts.OrderByDescending(a => a.Age).FirstOrDefault();
            return austrPerson;

        }

        public Astronaut GetAstronaut(string name)
        {
            var austr = this.astronauts.FirstOrDefault(x => x.Name == name);

            return austr;
        }

        public string Report()
        {
            StringBuilder sb2 = new StringBuilder();

            sb2.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var item in astronauts)
            {
                sb2.AppendLine(item.ToString());
            }
            //"Astronaut: {name}, {age} ({country})"
            return sb2.ToString().TrimEnd();

            //Astronaut: Stephen, 40 (Bulgaria)
            //Astronaut: Mark, 34 (UK)
        }
    }
}
