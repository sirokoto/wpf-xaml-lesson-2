using System.IO;
using System.Text;

namespace WpfApp2
{
    internal class PersonCollection
    {
        private List<Person> list;
        public PersonCollection()
        {
            list = new List<Person>();
            FileStream fS = new FileStream(@"G:\person.txt", FileMode.Open);
            StreamReader sR = new StreamReader(fS, encoding:Encoding.UTF8);
            string line; string[] split;
            while ((line = sR.ReadLine()) != null)
            {
                split = line.Split(" ");
                Person obj = new Person(split[0], split[1], split[2]);
                list.Add(obj);
            }
            fS.Close();
        }
        public void Add(Person obj)
        {
            list.Add(obj);
        }
        public int Count() { return list.Count; }
        public void Remove(string id)
        {
            foreach (Person obj in list) { if (obj.Id == id) list.Remove(obj); }
        }

        public Person GetItem(string? id)
        {
            foreach (Person obj in list) { 
                if (obj.Id == id) 
                { 
                    return obj; 
                } 
            }
            return null; 
        }
        public IEnumerator<Person> GetEnumerator() { return list.GetEnumerator(); }

        public Person this[string id] { 
            get
            {
                return GetItem(id);
            }
        }
    }
}