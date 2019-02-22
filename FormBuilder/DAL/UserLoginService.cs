using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.DAL
{
    public class UserLoginService
    {
        private FormContext db = new FormContext();

        public User GetByUsernameAndPassword(User user)
        {
            return db.Users.Where(u => u.UserName == user.UserName & u.Password == user.Password).FirstOrDefault();
        }

    }
};