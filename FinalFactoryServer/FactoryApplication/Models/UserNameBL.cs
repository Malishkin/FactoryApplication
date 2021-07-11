using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class UserNameBL
    {
        factoryDBEntities db = new factoryDBEntities();
        public List<user> GetAllData()
        {
            List<user> li = new List<user>();
            foreach (var u in db.user)
            {
                user us = new user();
                us.ID = u.ID;
                us.fullName = u.fullName;
                us.userName = u.userName;
                us.password = u.password;
                us.num_of_actions = u.num_of_actions;
                li.Add(us);
            }
            return li;
        }

        public user GetByUserName(string username)
        {
            user user = new user();
            foreach (var item in db.user)
            {
                if (item.userName == username)
                {
                    user = item;
                }

            }
            return user;
        }

        public user GetByID(int id)
        {
            user usr = new user();
            foreach (var item in db.user)
            {
                if (item.ID == id)
                {
                    usr = item;
                }

            }
            return usr;
        }
    }
}