using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboardProject;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc;


namespace AdminDashboardProject
{
    public class AccountController : Controller
    {

        private AdminDBContext _db;

        public AccountController( AdminDBContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            Validate();
            return View();
        }

        public ActionResult Validate()
        {
            var x = Request; //request.query
            //var _admin = _db.Users.Where(s => s.Email == admin.Email);
            //if (_admin.Any())
            //{
            //    if (_admin.Where(s => s.Password == admin.Password).Any())
            //    {

            //        return Json(new { status = true, message = "Login Successfull!" });
            //    }
            //    else
            //    {
            //        return Json(new { status = false, message = "Invalid Password!" });
            //    }
            //}
            //else
            //{
            //    return Json(new { status = false, message = "Invalid Email!" });
            //}
            return View();
        }
    }
}