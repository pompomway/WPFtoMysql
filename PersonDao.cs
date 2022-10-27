using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;

namespace dao
{
    interface PersonDao
    {
        void save(Person pn);
        int delete(int pk);
        int update(Person pn);
        Person getByPk(int pk);

        List<Person> getByID(string[] id);
        List<Person> getByPass(string[] pass);
    }
}
