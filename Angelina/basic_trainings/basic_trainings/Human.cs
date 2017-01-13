using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class Human: IComparable<Human>
    {
        public string Name { get; }
        public int Age { get; }

        public Human(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }      

        public void Print()
        {
            Console.WriteLine("{0} is {1}", this.Name, this.Age);            
        }

        public int CompareTo(Human person)
        {
            return this.Name.CompareTo(person.Name);
        }
    }
}
