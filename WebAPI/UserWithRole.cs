using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI
{
    public class UserWithRole
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        public UserWithRole()
        {

            //using (var context = new RolesContext())
            //{
            //    var sql = @"
            //            SELECT AspNetUsers.UserName, AspNetRoles.Name 
            //    FROM AspNetUsers 
            //    LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
            //    LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId";


            //    var result = context.Database.ExecuteQuery<UserWithRole>(sql);

            //}
            //return ok(result);
        }
    }
}
