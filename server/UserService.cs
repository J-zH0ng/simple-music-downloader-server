using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserService”。
    public class UserService : IUserService
    {
        public bool LogIn(string username, string password)
        {
            using(playerdbEntities context = new playerdbEntities())
            {
                var query = (from user in context.users
                             where username == user.username
                             select user.password).SingleOrDefault();
                if (String.IsNullOrEmpty(username) || password != query)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool SignIn(string username, string password)
        {
            using(playerdbEntities context = new playerdbEntities())
            {
                var query = (from user in context.users
                             where user.username == username
                             select user.username).SingleOrDefault();
                if (String.IsNullOrEmpty(query))
                {
                    //context.users.Add(new user { username = username,password = password });
                    //try
                    //{
                    context.Database.ExecuteSqlCommand("INSERT INTO `playerdb`.`users` (`username`, `password`) VALUES (@p0, @p1);", username, password);
                        return true;
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.Message);
                    //    return false;
                    //}
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
