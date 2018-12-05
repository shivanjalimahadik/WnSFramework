using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Entities.Wrappers;
using System.Net.Http;
using WebAPI.ViewModels;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class UserRoleMappingController : Controller
    {
        // GET: UserRoleMapping
        public ActionResult Index()
        {
            IList<UserRoleWrapper> userRoleWrapperList = null;
            IList<Roles> roleList = null;
            IList<Users> userList = null;

            using (var client = new HttpClient())
            {
                var userRoleWrapperUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "UserRoleMapping" }, Request.Url.Scheme);
                string requestUrl = userRoleWrapperUrl.ToString() + "/GetAllUserRole";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<UserRoleWrapper>>();
                    readTask.Wait();
                    userRoleWrapperList = readTask.Result.ToList();
                }
            }

            using (var client = new HttpClient())
            {
                var roleUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Roles" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(roleUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Roles>>();
                    readTask.Wait();
                    roleList = readTask.Result.ToList();
                    TempData["RoleList"] = roleList;
                    TempData.Keep();
                }
            }

            using (var client = new HttpClient())
            {
                var userUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Users" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(userUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Users>>();
                    readTask.Wait();
                    userList = readTask.Result.ToList();
                    TempData["UserList"] = userList;
                    TempData.Keep();
                }
            }

            UserRoleMappingViewModel urViewModel = new UserRoleMappingViewModel
            {
                UserRoleWrapper = userRoleWrapperList
            };

            return View(urViewModel);
        }

        public ActionResult New()
        {
            UserRoleMappingViewModel urViewModel = new UserRoleMappingViewModel
            {
                UserList = ((IList<Users>)TempData["UserList"]).Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.UserName
                }),
                Roles = ((IList<Roles>)TempData["RoleList"]).Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.Id.ToString()
                })
            };

            return View(urViewModel);
        }

        public ActionResult Save(UserRoleMappingViewModel urViewModel)
        {
            if (ModelState.IsValid)
            {
                List<UserRoleMapping> urList = new List<UserRoleMapping>();

                if (string.IsNullOrEmpty(Convert.ToString(urViewModel.Id)) || string.Equals(Convert.ToString(urViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    foreach (Guid item in urViewModel.SelectedRoles)
                    {
                        urList.Add(new UserRoleMapping
                        {
                            UserID = urViewModel.UserID,
                            RoleID = item
                        });
                    }

                    using (var client = new HttpClient())
                    {
                        var urUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "UserRoleMapping" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(urUrl, urList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    foreach (Guid item in urViewModel.SelectedRoles)
                    {
                        urList.Add(new UserRoleMapping
                        {
                            UserID = urViewModel.UserID,
                            RoleID = item,
                            Id = urViewModel.Id
                        });
                    }

                    using (var client = new HttpClient())
                    {
                        var urUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "UserRoleMapping" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(urUrl, urList);
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
            IList<UserRoleMapping> userRoleList = null;
            List<Guid> ids = new List<Guid>();
            List<Guid> userSelectedRoles = new List<Guid>();

            ids.Add(new Guid(id));
            string ss = JsonConvert.SerializeObject(ids);

            using (var client = new HttpClient())
            {
                string url = Request.UrlReferrer.ToString().Substring(0, Request.UrlReferrer.ToString().LastIndexOf('/'));
                Uri uriCall = new Uri(url + "/api/v1/UserRoleMapping/ids/?ids=" + ss);
                var responseTask = client.GetAsync(uriCall);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<UserRoleMapping>>();
                    readTask.Wait();
                    userRoleList = readTask.Result.ToList();
                }
            }

            UserRoleMapping urMapping = userRoleList.First(c => c.UserID == new Guid(id));

            foreach (UserRoleMapping ur in userRoleList)
            {
                userSelectedRoles.Add(ur.RoleID);
            }

            UserRoleMappingViewModel urViewModel = new UserRoleMappingViewModel
            {
                UserID = urMapping.UserID,
                SelectedRoles = userSelectedRoles.ToArray(),

                UserList = ((IList<Users>)TempData["UserList"]).Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.UserName
                }),
                Roles = ((IList<Roles>)TempData["RoleList"]).Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.Id.ToString()
                })
            };

            return View("New", urViewModel);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var urUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "UserRoleMapping", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(urUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserRoleMapping>();
                    readTask.Wait();
                    var urMapping = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }
    }
}