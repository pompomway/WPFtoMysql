using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    class Person
    {
        private int pk;
        private string id;
        private string pass;

        public Person() { }

        public Person(int pk, string id, string pass)
        {
            this.pk = pk;
            this.id = id;
            this.pass = pass;
        }

        public int Pk { get => pk; set => pk = value; }
        public string Id { get => id; set => id = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
