using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RolesContext _context;
        public RoleController(RolesContext context) 
        {
            _context = context;
        }

        //[HttpGet]
        //[Route("ListRoles")]
        ////GET : api/Role
        //public async Task<ActionResult> getRole() {
        //    string userid = User.Claims.First(c => c.Type == "UserId").Value;
        //    var applicationUser = new ApplicationUser();
        //    var parameters = new SqlParameter();
        //    parameters.ParameterName("Id");

        //    var sql = "Exec prc_listRoles @Id";
        //    List<RolesModel> role = _context.Database.ExecuteSqlCommand(sql, parameters = "@Id"); //return Ok(role);
        //    return Ok(role);
        //}
    }
}