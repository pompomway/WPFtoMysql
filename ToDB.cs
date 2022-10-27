using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using daoimpl;
using utils;

//介面按鈕讀取DB介面方法集
namespace ToDBC0419
{
    class ToDB
    {
        PersonDao dao = new PersonDaoImpl01();
        Person pn = new Person();
        List<Person> list;
        string showPk = "Pk  :";
        string showId = "ID  :";
        string showPw = "Pass:";
        string message;

        public void setTest(string id, string pass)
        {
            pn.Id = id;
            pn.Pass = pass;
            dao.save(pn);
        }

        public string showTest(int pk)
        {
            pn = dao.getByPk(pk);
            if (pn == null)
            {
                message = "Pk  :" + pk + " is no data";
            }
            else
            {
                message = showId + pn.Id+"\n"+ showPw + pn.Pass;
            }
            return message;
        }

        public string upTest(int pk, string pass)
        {
            pn = new Person(pk, "", pass);
            int rs = dao.update(pn);
            if (rs != 0)
            {
                message="修改資料如下:"+"\n"+showTest(rs);
            }
            else { message = "修改失敗，未有該筆資料。"; }
            return message;
        }

        public string deTest(int pk)
        {
            int rs = dao.delete(pk);
            if (rs == 0)
            {
                message = "刪除失敗，未有該筆資料。";
            }
            else
            {
                message = "Pk  :" + pk + " 資料已刪除";
            }
            return message;
        }

        public int loginCheck(string id,string pass)
        {
            int rs=10;
            Person pn = new Person();
            string[] idd = {id};
            list = dao.getByID(idd);
            foreach (Person p in list)
            {
                if (p.Pk == 1 && p.Pass == pass)
                {
                    rs = 1; //OK
                }
                else if (p.Pk != 1 && p.Pass == pass)
                {
                    rs = 2;//權限不足
                }
                else {
                    rs = 0;//帳密錯誤
                }
            }
            return rs;
        }

        public string showTestID(string[] id)
        {
            int n = 0;
            message = "";
            list = dao.getByID(id);
            foreach (Person pn in list)
            {
                message= pn.Pk == 0? message + "ID  :" + id[n] + " is no data" + "\n" + "-----------------------" + "\n": message + showPk + pn.Pk + "\n" + showId + pn.Id + "\n" + showPw + pn.Pass + "\n" + "-----------------------" + "\n";
                n++;
            }
            return message;
        }
        public string showTestPass(string[] pass)
        {
            int n = 0;
            message = "";
            list = dao.getByPass(pass);
            foreach (Person pn in list)
            {
                message = pn.Id == null ? message + "Pass:" + pass[n] + " is no data" + "\n" + "-----------------------" + "\n" : message + showId + pn.Id + "\n" + showPw + pn.Pass + "\n" + "-----------------------" + "\n";
                /*
                if (pn.Id == null)
                {
                    Console.WriteLine("Pass:" + pn.Pass + " is no data");
                    Console.WriteLine("-----------------------");
                }
                else
                {
                    Console.WriteLine(showId + pn.Id);
                    Console.WriteLine(showPw + pn.Pass);
                    Console.WriteLine("-----------------------");
                }
                */
                n++;
            }
            return message;
        }
    }
}
