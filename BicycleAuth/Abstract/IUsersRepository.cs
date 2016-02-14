using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleAuth
{
    public interface IUsersRepository
    {
        IQueryable<User> Users {get;}

        bool Register(string userName, string password);



        string LogInUser(string userName, string password); 
    }
}
