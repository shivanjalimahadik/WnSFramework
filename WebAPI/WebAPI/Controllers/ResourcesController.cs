using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        public ActionResult Index()
        {
            IList<ResourceWrapper> ResourceList = null;

            using (var client = new HttpClient())
            {
                var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources" }, Request.Url.Scheme);
                string requestUrl = resourceUrl.ToString() + "/GetAllR";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ResourceWrapper>>();
                    readTask.Wait();
                    ResourceList = readTask.Result.ToList();
                }
            }

            IList<ResourceCenter> resourceCenterList = null;

            using (var client = new HttpClient())
            {
                var resourceCenterUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(resourceCenterUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ResourceCenter>>();
                    readTask.Wait();
                    resourceCenterList = readTask.Result.ToList();
                    TempData["RCList"] = resourceCenterList;
                    TempData.Keep();
                }
            }

            ResourceViewModel rViewModel = new ResourceViewModel()
            {
                ResourceWrapperList = ResourceList
            };

            return View(rViewModel);
        }

        public ActionResult New()
        {
            ResourceViewModel resourceViewModel = new ResourceViewModel
            {
                ResourceCentersList = (IList<ResourceCenter>)TempData["RCList"],
                RCList = ((IList<ResourceCenter>)TempData["RCList"]).Select(c => new SelectListItem
                {
                    Text = c.ResourceCenterName,
                    Value = c.Id.ToString()
                })
            };

            return View(resourceViewModel);
        }

        public ActionResult Edit(string id)
        {
            Resources r = null;


            using (var client = new HttpClient())
            {
                var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(resourceUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Resources>();
                    readTask.Wait();
                   r = readTask.Result;
                }
            }

            ResourceViewModel rViewModel = new ResourceViewModel()
            {
                Id = r.Id,
                ResourceName = r.ResourceName,
                RCId = r.ResourceCenterID,

                ResourceCentersList = (IList<ResourceCenter>)TempData["RCList"],
                RCList = ((IList<ResourceCenter>)TempData["RCList"]).Select(c => new SelectListItem
                {
                    Text = c.ResourceCenterName,
                    Value = c.Id.ToString()
                })

            };

            return View("New", rViewModel);
        }

        public ActionResult Save(ResourceViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                List<Resources> resourceList = new List<Resources>();

                if (string.IsNullOrEmpty(Convert.ToString(rvm.Id)) || string.Equals(Convert.ToString(rvm.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    resourceList.Add(new Resources
                    {
                        ResourceName = rvm.ResourceName,
                        ResourceCenterID = rvm.RCId
                    });

                    using (var client = new HttpClient())
                    {
                        var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(resourceUrl, resourceList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                     resourceList.Add(new Resources
                    {
                        Id = rvm.Id,
                        ResourceName = rvm.ResourceName,
                        ResourceCenterID = rvm.RCId
                    });

                    using (var client = new HttpClient())
                    {
                        var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(resourceUrl, resourceList);
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
                //ModelState.AddModelError("Resource",)
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(resourceUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Resources>();
                    readTask.Wait();
                    var resource = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }


    }
}