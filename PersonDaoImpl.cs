using System;
using System.Collections.Generic;

using dao;
using MySql.Data.MySqlClient;
using dbutils;
using utils;

namespace daoimpl
{
    abstract class PersonDaoImpl : PersonDao
    {
        //精簡
        MySqlConnection conn = null;
        MySqlCommand sqlcmd = null;
        MySqlDataReader rs = null;
        string sql;

        public int delete(int pk)
        {
            conn = DBUtil.getUtils().getConnection();
            sql = "delete from login where pk=" + pk + ";";
            sqlcmd = new MySqlCommand(sql, conn);
            int rs = sqlcmd.ExecuteNonQuery();
            DBUtil.getUtils().close(conn);
            return rs == 0 ? rs : pk;
        }

        public Person getByPk(int pk)
        {
            MySqlConnection conn = DBUtil.getUtils().getConnection();

            string sql = "select id,pass from login where pk=" + pk + ";";
            Person pn = new Person();
            MySqlCommand sqlcmd = new MySqlCommand(sql, conn);
            rs = sqlcmd.ExecuteReader();
            while (rs.Read())
            {
                pn.Id = (string)rs["id"];
                pn.Pass = (string)rs["pass"];
            }
            DBUtil.getUtils().close(rs);
            DBUtil.getUtils().close(conn);
            return pn.Id == null ? null : pn;
        }

        public void save(Person pn)
        {
            MySqlConnection conn = DBUtil.getUtils().getConnection();
            string sql = "insert into login (id,pass)value('" + pn.Id + "','" + pn.Pass + "');";
            MySqlCommand sqlcmd = new MySqlCommand(sql, conn);
            int rs = sqlcmd.ExecuteNonQuery();
            if (rs == 1)
            {
                Console.WriteLine("insert OK");
            }
            else { Console.WriteLine("insert NG"); }
            DBUtil.getUtils().close(conn);

        }

        public int update(Person pn)
        {
            MySqlConnection conn = DBUtil.getUtils().getConnection();
            string sql = "update login set pass=" + pn.Pass + " where pk=" + pn.Pk + ";";
            MySqlCommand sqlcmd = new MySqlCommand(sql, conn);
            int rs = sqlcmd.ExecuteNonQuery();
            DBUtil.getUtils().close(conn);
            return rs == 0 ? rs : pn.Pk;
        }

        public abstract List<Person> getByID(string[] id);


        public abstract List<Person> getByPass(string[] pass);

        
    }
}
