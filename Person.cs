using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Person
    {
        private string id = "";
        private string name = "";
        private string surname = "";
        public string Id {
            get { return id; }
            set { id = value; } 
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public Person(string id, string name, string surname) {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }
        public Person() {
            this.Id = "Default";
            this.Name = "Default";
            this.Surname = "Default";
        }
    }
}
