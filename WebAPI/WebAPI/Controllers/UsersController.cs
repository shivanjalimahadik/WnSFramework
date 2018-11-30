using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            IList<OrganizationUnit> organizationUnitList = null;
            IList<BusinessUnit> businessUnitList = null;
            IList<UsersWrapper> userList = null;

            using (var client = new HttpClient())
            {
                var organizationUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Users" }, Request.Url.Scheme);
                string requestUrl = organizationUnitUrl.ToString() + "/GetAllUsers";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<UsersWrapper>>();
                    readTask.Wait();
                    userList = readTask.Result.ToList();
                }
            }


            using (var client = new HttpClient())
            {
                var organizationUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(organizationUnitUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<OrganizationUnit>>();
                    readTask.Wait();
                    organizationUnitList = readTask.Result.ToList();
                    TempData["OUList"] = organizationUnitList;
                    TempData.Keep();
                }
            }

            using (var client = new HttpClient())
            {
                var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(businessUnitUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<BusinessUnit>>();
                    readTask.Wait();
                    businessUnitList = readTask.Result.ToList();
                    TempData["BUList"] = businessUnitList;
                    TempData.Keep();
                }
            }

            UsersViewModel usersViewModel = new UsersViewModel
            {
                UsersList = userList
            };

            return View(usersViewModel);
        }

        public ActionResult New()
        {
            UsersViewModel userViewModel = new UsersViewModel
            {
                BUList = ((IList<BusinessUnit>)TempData["BUList"]).Select(c => new SelectListItem
                {
                    Text = c.BusinessUnitName,
                    Value = c.Id.ToString()
                }),
                OUList = ((IList<OrganizationUnit>)TempData["OUList"]).Select(c => new SelectListItem
                {
                    Text = c.OrganizationUnitName,
                    Value = c.Id.ToString()
                })
            };

            return View(userViewModel);
        }

        public ActionResult Save(UsersViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Users> userlist = new List<Users>();
                if (string.IsNullOrEmpty(Convert.ToString(userViewModel.Id)) || string.Equals(Convert.ToString(userViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    userlist.Add(
                        new Users
                        {
                            UserName = userViewModel.UserName,
                            FirstName = userViewModel.FirstName,
                            LastName = userViewModel.LastName,
                            Email = userViewModel.Email,
                            Password = userViewModel.Password,
                            PasswordExpiry = userViewModel.PasswordExpiry,
                            ContactNo = userViewModel.ContactNo,
                            OrganizationUnitID = userViewModel.OUId,
                            BusinessUnitID = userViewModel.BUId,
                        }
                        );

                    using (var client = new HttpClient())
                    {
                        var usersUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Users" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(usersUrl, userlist);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    userlist.Add(
                        new Users
                        {
                            Id = userViewModel.Id,
                            UserName = userViewModel.UserName,
                            FirstName = userViewModel.FirstName,
                            LastName = userViewModel.LastName,
                            Email = userViewModel.Email,
                            Password = userViewModel.Password,
                            PasswordExpiry = userViewModel.PasswordExpiry,
                            ContactNo = userViewModel.ContactNo,
                            OrganizationUnitID = userViewModel.OUId,
                            BusinessUnitID = userViewModel.BUId,
                        }
                        );

                    using (var client = new HttpClient())
                    {
                        var usersUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Users" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(usersUrl, userlist);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
            }


            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            Users user = null;

            using (var client = new HttpClient())
            {
                var usersUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Users", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(usersUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Users>();
                    readTask.Wait();
                    user = readTask.Result;
                }
            }

            UsersViewModel userViewModel = new UsersViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                PasswordExpiry = user.PasswordExpiry,
                ContactNo = user.ContactNo,
                OUId = user.OrganizationUnitID,
                BUId = user.BusinessUnitID,
                BUList = ((IList<BusinessUnit>)TempData["BUList"]).Select(c => new SelectListItem
                {
                    Text = c.BusinessUnitName,
                    Value = c.Id.ToString()
                }),
                OUList = ((IList<OrganizationUnit>)TempData["OUList"]).Select(c => new SelectListItem
                {
                    Text = c.OrganizationUnitName,
                    Value = c.Id.ToString()
                })
            };

            return View("NEw", userViewModel);
        }
    }
}