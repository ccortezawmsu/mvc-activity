using Again.Areas.security.Models;
using Again.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Again.Areas.security.Controllers
{
    public class UsersController : Controller
    {
       
        //
        // GET: /security/Users/
        public ActionResult Index()
        {
            using (var db = new DataBaseContext())
            {                
            var Users = (from user in db.Users
                             select new UserModel
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate
                             }).ToList();
              return View(Users);
            }
        }
        //
        // GET: /security/Users/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));
        }

        //
        // GET: /security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem> {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = " Female" 
                }
            };
            return View();
        }

        //
        // POST: /security/Users/Create
        [HttpPost]
        public ActionResult Create(UserModel Usersmodel)
        {
            try
            {
             if (ModelState.IsValid == false)
                    return View();
             using (var db = new DataBaseContext())
             {
                 db.Users.Add(new User
                 {
                     //Id = UserModel.Id,
                     FirstName = Usersmodel.FirstName,
                     LastName = Usersmodel.LastName,
                     Age = Usersmodel.Age,
                     Gender = Usersmodel.Gender,
                     EmploymentDate= Usersmodel.EmploymentDate
                 });
                 db.SaveChanges();
             }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /security/Users/Edit/5
        public ActionResult Edit(int id)
        {

            return View(GetUser(id));
        }

        //
        // POST: /security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel Usersmodel)
        {
            try
            {                // TODO: Add update logic here

                if (ModelState.IsValid == false)
                    return View();

                 using (var db = new DataBaseContext())
                 {
                var user = db.Users.FirstOrDefault (u => u.Id == id);
                     {
                    user.FirstName = Usersmodel.FirstName;
                    user.LastName = Usersmodel.LastName;
                    user.Age = Usersmodel.Age;
                    user.Gender = Usersmodel.Gender;
          
                     db.SaveChanges();
                    };
                 }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /security/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetUser(id));
        }

        //
        // POST: /security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                  var users = db.Users.FirstOrDefault(u => u.Id == id);
                    db.Users.Remove(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        private UserModel GetUser(int id)
        {
            using (var db = new DataBaseContext())
            {
                return (from user in db.Users
                        where user.Id == id
                        select new UserModel
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Age = user.Age,
                            Gender = user.Gender,
                            EmploymentDate = user.EmploymentDate
                        }).FirstOrDefault();

                
            }

        }
    }
}
