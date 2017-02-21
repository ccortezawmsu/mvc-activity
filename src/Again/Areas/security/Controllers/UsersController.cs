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
        private IList<UserModel>Users
        { 
            get
            {
                   if (Session["data"]==null)
                   {
                       Session["data"] = new List<UserModel>(){
                           new UserModel {
                            Id = Guid.NewGuid(),
                            FirstName = "Christian",
                            LastName = "Corteza",
                            Age = 21 ,
                            Gender =  "Male"
                        },
                    new UserModel {
                        Id = Guid.NewGuid(),
                        FirstName = "Lorem",
                        LastName = "Ipsum",
                        Age = 19 ,
                        Gender = "Female"

                       }
                    };
                   }
                   return Session["data"] as List<UserModel>;

            }
        }
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
                                 Gender = user.Gender
                             }).ToList();
              return View(Users);
            }
        }
        //
        // GET: /security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            var u = Users.FirstOrDefault(users => users.Id == id);
            // Users.Contains(u);
            return View(u);
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
                     Id = Guid.NewGuid(),
                     FirstName = Usersmodel.FirstName,
                     LastName = Usersmodel.LastName,
                     Age = Usersmodel.Age,
                     Gender = Usersmodel.Gender

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
        public ActionResult Edit(Guid id)
        {
           
            var u = Users.FirstOrDefault(users => users.Id == id);
            return View(u);
        }

        //
        // POST: /security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserModel Usersmodel)
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
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(users => users.Id == id);
            return View(u);
        }

        //
        // POST: /security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var u = Users.FirstOrDefault(user => user.Id == id);
                Users.Remove(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
