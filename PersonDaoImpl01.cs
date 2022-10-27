using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using utils;
using dbutils;

namespace daoimpl
{
    class PersonDaoImpl01 : PersonDaoImpl
    {
        MySqlConnection conn = null;
        MySqlCommand sqlcmd = null;
        MySqlDataReader rs = null;
        List<Person> list;
        Person pn;
        string sql;
        public override List<Person> getByID(string[] id)
        {
            conn = DBUtil.getUtils().getConnection();
            list = new List<Person>();
            foreach (string s in id)
            {
                pn = new Person();
                sql = "select * from login where id='" + s + "';";
                sqlcmd = new MySqlCommand(sql, conn);
                rs = sqlcmd.ExecuteReader();
                while (rs.Read())
                {
                    pn.Pk = (int)rs["pk"];
                    pn.Id = (string)rs["id"];
                    pn.Pass = (string)rs["pass"];

                }
                list.Add(pn);
                DBUtil.getUtils().close(rs);
            }
            DBUtil.getUtils().close(conn);
            return list;
        }

        public override List<Person> getByPass(string[] pass)
        {
            conn = DBUtil.getUtils().getConnection();
            list = new List<Person>();
            foreach (string s in pass)
            {

                sql = "select id,pass from login where pass='" + s + "';";
                sqlcmd = new MySqlCommand(sql, conn);
                rs = sqlcmd.ExecuteReader();
                while (rs.Read())
                {
                    pn = new Person();
                    pn.Id = (string)rs["id"];
                    pn.Pass = (string)rs["pass"];
                    list.Add(pn);
                }
                DBUtil.getUtils().close(rs);
            }
            DBUtil.getUtils().close(conn);
            return list;
        }
    }
}
