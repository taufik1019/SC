using Microsoft;
using Microsoft.EntityFrameworkCore;
using SC.Context;
using SC.Handler;
using SC.Models;
using SC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public ResponLogin Login(Login login)
        {
            var data = myContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Email.Equals(login.Email));
            var Verify = Hashing.ValidatePassword(login.Password, data.Password);
            if (Verify)
            {
                if (data.Role.RoleId == 1)
                {
                    var data1 = myContext.Users
                                .Include(x => x.Role)
                                .FirstOrDefault(x => x.Email.Equals(login.Email));
                    var verify = Hashing.ValidatePassword(login.Password, data.Password);
                    if (Verify)
                        if (data1 != null)
                        {
                            var respon = new ResponLogin()
                            {
                                Id = data1.UserId,
                                RoleId = data1.Role.RoleId,
                                Name = data1.UserName,
                                Role = data1.Role.RoleName
                            };
                            return respon;
                        }
                }
                else if (data.Role.RoleId == 2)
                {
                    var data1 = myContext.Users
                               .Include(x => x.Role)
                               .FirstOrDefault(x => x.Email.Equals(login.Email));
                    var verify = Hashing.ValidatePassword(login.Password, data.Password);
                    if (Verify)
                        if (data1 != null)
                        {
                            var respon = new ResponLogin()
                            {
                                Id = data1.UserId,
                                RoleId = data1.Role.RoleId,
                                Name = data1.UserName,
                                Role = data1.Role.RoleName
                            };
                            return respon;
                        }
                }
            }
            return null;

        }

        // Register
        public int Register(Register register)
        {
            //mapping data ke User
            int id = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email)).UserId;
            User user = new User()
            {
                UserId = id,
                UserName = register.Name,
                Email = register.Email,
                Password = Hashing.HashPassword(register.Password),
                RoleId = register.RoleId
            };
            myContext.Users.Add(user);
            myContext.SaveChanges();
            myContext.Users.Remove(user);
            myContext.SaveChanges();
            return 0;
        }
    }
}