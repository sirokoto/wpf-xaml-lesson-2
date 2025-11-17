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
        private string branch = "";
        private string fullName = "";
        private string age = "";
        private string salary = "";
        private string internship = "";
        private string stats = "";
        public string Id {
            get { return id; }
            set { id = value; } 
        }
        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Internship
        {
            get { return internship; }
            set { internship = value; }
        }
        public string Stats
        {
            get { return stats; }
            set { stats = value; }
        }
        public Person(string id, string branch, string fullName, string age, string salary, string internship)
        {
            this.Id = id;
            this.Branch = branch;
            this.FullName = fullName;
            this.Age = age;
            this.Salary = salary;
            this.Internship = internship;
            this.Stats = "";
        }
        public Person() {
            this.Id = "Default";
            this.FullName = "Default";
            this.branch = "Default";
            this.Age = "Default";
            this.Salary = "Default";
            this.Internship = "Default";
            //this.Stats = "Default";
        }
    }
}
