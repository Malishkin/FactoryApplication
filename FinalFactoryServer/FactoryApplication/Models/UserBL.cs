using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class UserBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<user> getAllUsers()
        {
            List<user> lst = new List<user>();
            foreach (var us in db.user)
            {
                user newUser = new user();
                newUser.ID = us.ID;
                newUser.fullName = us.fullName;
                newUser.userName = us.userName;
                newUser.password = us.password;
                newUser.num_of_actions = us.num_of_actions;
                lst.Add(newUser);

            }
            return lst;
        }

        public user GetUserById(int userID)
        {
            user us = db.user.Where(x => x.ID == userID).First();
            user newUser = new user();
            newUser.ID = us.ID;
            newUser.fullName = us.fullName;
            newUser.userName = us.userName;
            newUser.password = us.password;
            newUser.num_of_actions = us.num_of_actions;

            return newUser;

        }

        public int AddUser(user us)
        {
            db.user.Add(us);
            db.SaveChanges();
            return us.ID;
        }

        public void UpdateUser(int id, user us)
        {
            var currentUser = db.user.Where(x => x.ID == id).First();
            currentUser.fullName = us.fullName;
            currentUser.userName = us.userName;
            currentUser.password = us.password;
            currentUser.num_of_actions = us.num_of_actions;
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var currentUser = db.user.Where(x => x.ID == id).First();
            db.user.Remove(currentUser);
            db.SaveChanges();
        }
    }
}