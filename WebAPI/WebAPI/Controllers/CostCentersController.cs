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
    public class CostCentersController : Controller
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            IList<CostCenter> cost = null;

            using (var client = new HttpClient())
            {
                var costUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(costUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<CostCenter>>();
                    readTask.Wait();
                    cost = readTask.Result.ToList();
                }
            }

            
            CostCentersViewModel costViewModel = new CostCentersViewModel()
            {
                costList = cost
            };

            return View(costViewModel);
        }

        public ActionResult New()
        {
            CostCentersViewModel costViewModel = new CostCentersViewModel();

            return View(costViewModel);
        }

        public ActionResult Edit(string id)
        {
            CostCenter cost = null;

            using (var client = new HttpClient())
            {
                var costUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(costUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CostCenter>();
                    readTask.Wait();
                    cost = readTask.Result;
                }
            }

            CostCentersViewModel costViewModel = new CostCentersViewModel()
            {
                CostCenterName = cost.CostCenterName,
                Id = new Guid(id)
            };

            return View("New", costViewModel);
        }

        public ActionResult Save(CostCentersViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                List<CostCenter> costList = new List<CostCenter>();

                if (string.IsNullOrEmpty(Convert.ToString(rvm.Id)) || string.Equals(Convert.ToString(rvm.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    //costList.Add(new CostCenter { CostCenterName = rvm.CostCenterName, OrganizationUnitID = new Guid("e6e16a84-8004-4425-af74-b650ed3eb8ee") });
                    costList.Add(new CostCenter { CostCenterName = rvm.CostCenterName });
                    using (var client = new HttpClient())
                    {
                        var costUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(costUrl, costList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    costList.Add(new CostCenter { Id = rvm.Id, CostCenterName = rvm.CostCenterName });
                    using (var client = new HttpClient())
                    {
                        var costUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(costUrl, costList);
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
                //ModelState.AddModelError("CostCenter",)
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var costUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "CostCenter", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(costUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CostCenter>();
                    readTask.Wait();
                    var cost = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }
    }
}