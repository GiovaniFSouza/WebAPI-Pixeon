using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        readonly private UserManager<ApplicationUser> _userManager;
        //private RoleManager<ApplicationRoles> _roleManager;

        public UserProfileController(UserManager<ApplicationUser> userManager
                                    //, RoleManager<ApplicationRoles> roleManager
                                    )
        {
            _userManager = userManager;
          //  _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize]
        //GET: /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userid = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userid);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Methodo for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetForCustomer()
        {
            return "Methodo for Customer";
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer()
        {
            return "Methodo for Admin or Customer";
        }

        [HttpGet]
        //[AllowAnonymous]
        [Route("ListRoles")]
        //GET : api/UserProfile/ListRoles
        public string GetListRoles()
        {
            // return DbContext.FromSql("[sp_GetLoanDetails]").AsNoTracking();
             return "Estou aqui.";
            // SqlConnection con = new SqlConnection();
            // SqlCommand cmd = new SqlCommand();


            //var sql = @"exec prcs_listRoles";
            //var idParam = new SqlParameter("Id", Id? );


            //return Ok(role);


            //List<AspNetRolesModel> role = await RolesContext.AspNetRoles.FromSql("Select Name from AspNetRoles").ToListAsync();

            //return Ok(role);
        }

    }


}