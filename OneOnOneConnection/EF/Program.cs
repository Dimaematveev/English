using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext userContext = new UserContext();

            List<User> users = userContext.Users.ToList();
            List<UserData> usersData = userContext.UsersData.ToList();

            //User user = new User();
            //user.Login = "dima-367";
            //user.Password = "qwerty";
            //UserData userData = new UserData();
            //userData.Name = "dima";
            //userData.DateTime = DateTime.Now;

            //user.UserData = userData;

            //userContext.Users.Add(user);
            //userContext.UsersData.Add(userData);

            //userContext.SaveChanges();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
