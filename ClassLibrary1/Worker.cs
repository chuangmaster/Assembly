using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Worker
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Worker()
        {
            this.Name = "No Name";
            this.Age = 1;
        }

        public void PrintAge()
        {
            Console.WriteLine($"Age is {Age}");
        }
        public void PrintName()
        {
            Console.WriteLine($"Name is {Name}");
        }
        public void SaySomthing(string words)
        {
            Console.WriteLine($"The worker say {words}");
        }
        public override string ToString()
        {
            return $"Name is {Name} and Age is {Age}";
        }
    }
}
