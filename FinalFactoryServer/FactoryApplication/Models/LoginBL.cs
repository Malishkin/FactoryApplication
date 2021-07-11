using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
namespace FactoryApplication.Models
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class LoginBL
    {
        factoryDBEntities db = new factoryDBEntities();

        //public bool IsUserExist(string username, string password)
        //{
        //    var result = db.user.Where(x => x.userName == username && x.password == password);
        //    if (result.Count() > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public List<user> GetAllUsers()
        {
            return db.user.ToList();
        }

        public user GetUserById(int id)
        {
            return db.user.Where(x => x.ID == id).First();
        }

       

        public user VerifyUser(user u)
        {
            var res = db.user.Where(x => x.userName == u.userName && x.password == u.password);
            if (res.Count() == 1)
            {
                DateTime LDate = DateTime.Now;
                var userlog = db.user_actions.Where(x => x.user_id == res.FirstOrDefault().ID);
                if (userlog.Count() == 1)
                {
                    if (userlog.FirstOrDefault().enterDate.ToShortDateString() != LDate.ToShortDateString())
                    {
                        userlog.FirstOrDefault().enterDate = LDate;
                        userlog.FirstOrDefault().actions = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    user_actions newuserlog = new user_actions();
                    newuserlog.user_id = res.FirstOrDefault().ID;
                    newuserlog.enterDate = LDate;
                    db.user_actions.Add(newuserlog);
                    db.SaveChanges();
                }
                return res.First();
            }
            else
            {
                return null;
            }
        }

        public void AddAction(int userID, user_actions user)
        {
            var currentUserLog = db.user_actions.Where(x => x.user_id == userID).First();
            var currentUser = db.user.Where(x => x.ID == userID).First();
            currentUserLog.actions++;
            db.SaveChanges();

        }

        public bool checkALogs(int userID)
        {
            var currentUserLog = db.user_actions.Where(x => x.user_id == userID).First();
            var currentUser = db.user.Where(y => y.ID == userID).First();
            if (currentUserLog.actions >= currentUser.num_of_actions)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}