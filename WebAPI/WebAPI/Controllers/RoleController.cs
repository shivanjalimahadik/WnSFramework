using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class RoleController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            IList<Roles> roles = null;

            using (var client = new HttpClient())
            {
                var rolesUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(rolesUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Roles>>();
                    readTask.Wait();
                    roles = readTask.Result.ToList();
                }
            }

            RolesViewModel rolesViewModel = new RolesViewModel()
            {
                rolesList = roles
            };

            return View(rolesViewModel);
        }

        public ActionResult New()
        {
            RolesViewModel rolesViewModle = new RolesViewModel();

            return View(rolesViewModle);
        }

        public ActionResult Edit(string id)
        {
            Roles roles = null;

            using (var client = new HttpClient())
            {
                var rolesUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(rolesUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Roles>();
                    readTask.Wait();
                    roles = readTask.Result;
                }
            }

            RolesViewModel rolesViewModel = new RolesViewModel()
            {
                RoleName = roles.RoleName,
                Id = new Guid(id)
            };

            return View("New", rolesViewModel);
        }

        public ActionResult Save(RolesViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                List<Roles> rolesList = new List<Roles>();

                if (string.IsNullOrEmpty(Convert.ToString(rvm.Id)) || string.Equals(Convert.ToString(rvm.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    rolesList.Add(new Roles { RoleName = rvm.RoleName });

                    using (var client = new HttpClient())
                    {
                        var rolesUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(rolesUrl, rolesList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    rolesList.Add(new Roles { Id = rvm.Id, RoleName = rvm.RoleName });
                    using (var client = new HttpClient())
                    {
                        var rolesUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(rolesUrl, rolesList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
            }
            else
            {
                //ModelState.AddModelError("Role",)
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var rolesUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(rolesUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Roles>();
                    readTask.Wait();
                    var roles = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }
    }
}