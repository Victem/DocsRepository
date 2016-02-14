using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleAuth
{
    public class UsersRepository : IUsersRepository
    {
        #region Члены IUsersRepository
        BicycleAuthContext context = new BicycleAuthContext();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public bool Register(string userName, string password)
        {
            User user = (from u in Users where u.Name == userName select u).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            else
            {
                user = new User();
                user.Name = userName;
                user.Password = PasswordHasher.HashPassword(password);
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
           
            
        }

        public string LogInUser(string userName, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);
            User user = (from u in Users where u.Name == userName && u.Password.Equals(hashedPassword) select u).FirstOrDefault();
            if (user != null)
            {
                return user.Name;
            }
            return null;
        }

        #endregion
    }
}
