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
            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .FirstOrDefault(x => x.User.Campus.Email.Equals(login.Email));
                 var Verify = Hashing.ValidatePassword(login.Password, data.User.Password);
            if(Verify)
            {
                if (data.Role.Id == 1)
                {
                    var data1 = myContext.UserRoles
                                .Include(x => x.Role)
                                .Include(x => x.User)
                                .Include(x => x.User.Campus)
                                .FirstOrDefault(x => x.User.Campus.Email.Equals(login.Email));
                    var verify = Hashing.ValidatePassword(login.Password, data.User.Password);
                    if(Verify)
                    if (data1 != null) {
                        var respon = new ResponLogin()
                        {
                            Id = data1.User.Id,
                            RoleId = data1.Role.Id,
                            Name = data1.User.Campus.Name,
                            Role = data1.Role.Name
                        };
                        return respon;
                    }
                }
                else if (data.Role.Id == 2)
                {
                    var data1 = myContext.UserRoles
                               .Include(x => x.Role)
                               .Include(x => x.User)
                               .Include(x => x.User.Campus)
                               .FirstOrDefault(x => x.User.Campus.Email.Equals(login.Email));
                    var verify = Hashing.ValidatePassword(login.Password, data.User.Password);
                    if (Verify)
                        if (data1 != null)
                    {
                        var respon = new ResponLogin()
                        {
                            Id = data1.User.Id,
                            RoleId = data1.Role.Id,
                            Name = data1.User.Campus.Name,
                            Role = data1.Role.Name
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
            Campus campus = new Campus()
            {
                Name = register.Name,
                Email = register.Email
            };
            myContext.Campuses.Add(campus);
            var resultCampus = myContext.SaveChanges();
            if (resultCampus > 0)
            {
                int id = myContext.Campuses.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Users.Add(user);
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    UserRole userRole = new UserRole()
                    {
                        UserId = id,
                        RoleId = register.RoleId
                    };
                    myContext.UserRoles.Add(userRole);
                    var resultUserRole = myContext.SaveChanges();
                    if (resultUserRole > 0)
                        return resultUserRole;
                    myContext.Users.Remove(user);
                    myContext.SaveChanges();
                    myContext.Campuses.Remove(campus);
                    myContext.SaveChanges();
                    return 0;
                }
                myContext.Campuses.Remove(campus);
                myContext.SaveChanges();
                return 0;
            }
            return 0;
        }

       
    }
}
