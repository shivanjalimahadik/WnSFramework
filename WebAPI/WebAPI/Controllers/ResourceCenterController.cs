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
    public class ResourceCenterController : Controller
    {
        // GET: ResourceCenter
        public ActionResult Index()
        {
            IList<ResourceCenterWrapper> resourceCenterList = null;

            using (var client = new HttpClient())
            {
                var organizationUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter" }, Request.Url.Scheme);
                string requestUrl = organizationUnitUrl.ToString() + "/GetAllRC";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ResourceCenterWrapper>>();
                    readTask.Wait();
                    resourceCenterList = readTask.Result.ToList();
                }
            }

            IList<CostCenter> costCenterList = null;

            using (var client = new HttpClient())
            {
                var costCenterUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(costCenterUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<CostCenter>>();
                    readTask.Wait();
                    costCenterList = readTask.Result.ToList();
                    TempData["CCList"] = costCenterList;
                    TempData.Keep();
                }
            }

            ResourceCenterViewModel ouViewModel = new ResourceCenterViewModel()
            {
                RCWrapperList = resourceCenterList
            };

            return View(ouViewModel);
        }

        public ActionResult New()
        {
            ResourceCenterViewModel rcViewmodel = new ResourceCenterViewModel
            {
                CostCenterList = (IList<CostCenter>)TempData["CCList"],
                CCList = ((IList<CostCenter>)TempData["CCList"]).Select(c => new SelectListItem
                {
                    Text = c.CostCenterName,
                    Value = c.Id.ToString()
                })
            };

            return View(rcViewmodel);
        }

        public ActionResult Save(ResourceCenterViewModel rcViewModel)
        {
            if (ModelState.IsValid)
            {
                List<ResourceCenter> rcList = new List<ResourceCenter>();

                if (string.IsNullOrEmpty(Convert.ToString(rcViewModel.Id)) || string.Equals(Convert.ToString(rcViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    rcList.Add(new ResourceCenter
                    {
                        ResourceCenterName = rcViewModel.ResourceCenterName,
                        CostCenterID = rcViewModel.CCId
                    });

                    using (var client = new HttpClient())
                    {
                        var rcUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(rcUrl, rcList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    rcList.Add(new ResourceCenter
                    {
                        Id = rcViewModel.Id,
                        ResourceCenterName = rcViewModel.ResourceCenterName,
                        CostCenterID = rcViewModel.CCId
                    });

                    using (var client = new HttpClient())
                    {
                        var rcUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(rcUrl, rcList);
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
            ResourceCenter rc = null;

            using (var client = new HttpClient())
            {
                var rcUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(rcUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResourceCenter>();
                    readTask.Wait();
                    rc = readTask.Result;
                }
            }

            ResourceCenterViewModel rcViewModel = new ResourceCenterViewModel
            {
                Id = rc.Id,
                ResourceCenterName = rc.ResourceCenterName,
                CCId = rc.CostCenterID,
                CostCenterList = (IList<CostCenter>)TempData["CCList"],
                CCList = ((IList<CostCenter>)TempData["CCList"]).Select(c => new SelectListItem
                {
                    Text = c.CostCenterName,
                    Value = c.Id.ToString()
                })
            };

            return View("New", rcViewModel);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var rcUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "ResourceCenter", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(rcUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResourceCenter>();
                    readTask.Wait();
                    var ou = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }
    }
}