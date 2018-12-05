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
    public class OrganizationUnitController : Controller
    {
        // GET: OrganizationUnit
        public ActionResult Index()
        {
            IList<OUWrapper> organizationUnitList = null;

            using (var client = new HttpClient())
            {
                var organizationUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit" }, Request.Url.Scheme);
                string requestUrl = organizationUnitUrl.ToString() + "/GetAllOU";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<OUWrapper>>();
                    readTask.Wait();
                    organizationUnitList = readTask.Result.ToList();
                }
            }

            IList<BusinessUnit> businessUnitList = null;

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

            OrganizationUnitViewModel ouViewModel = new OrganizationUnitViewModel()
            {
                OUWrapperList = organizationUnitList
            };

            return View(ouViewModel);
        }

        public ActionResult New()
        {
            //IList<BusinessUnit> businessUnitList = null;

            //using (var client = new HttpClient())
            //{
            //    var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
            //    var responseTask = client.GetAsync(businessUnitUrl);
            //    responseTask.Wait();
            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IEnumerable<BusinessUnit>>();
            //        readTask.Wait();
            //        businessUnitList = readTask.Result.ToList();
            //        TempData["BUList"] = businessUnitList;
            //        TempData.Keep();
            //    }
            //}



            OrganizationUnitViewModel ouViewmodel = new OrganizationUnitViewModel
            {
                BusinessUnitList = (IList<BusinessUnit>)TempData["BUList"],
                BUList = ((IList<BusinessUnit>)TempData["BUList"]).Select(c => new SelectListItem {
                    Text = c.BusinessUnitName,
                    Value = c.Id.ToString()
                })
            };

            return View(ouViewmodel);
        }

        public ActionResult Save(OrganizationUnitViewModel ouViewModel)
        {
            if(ModelState.IsValid)
            {
                List<OrganizationUnit> ouList = new List<OrganizationUnit>();

                if (string.IsNullOrEmpty(Convert.ToString(ouViewModel.Id)) || string.Equals(Convert.ToString(ouViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    ouList.Add(new OrganizationUnit {
                        OrganizationUnitName = ouViewModel.OrganizationUnitName,
                        OrganizationUnitDescription = ouViewModel.OrganizationUnitDescription,
                        BusinessUnitID = ouViewModel.BUId
                    });

                    using (var client = new HttpClient())
                    {
                        var ouUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(ouUrl, ouList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    ouList.Add(new OrganizationUnit
                    {
                        Id = ouViewModel.Id,
                        OrganizationUnitName = ouViewModel.OrganizationUnitName,
                        OrganizationUnitDescription = ouViewModel.OrganizationUnitDescription,
                        BusinessUnitID = ouViewModel.BUId
                    });

                    using (var client = new HttpClient())
                    {
                        var ouUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(ouUrl, ouList);
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
            OrganizationUnit ou = null;

            using (var client = new HttpClient())
            {
                var ouUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(ouUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrganizationUnit>();
                    readTask.Wait();
                    ou = readTask.Result;
                }
            }

            OrganizationUnitViewModel ouViewModel = new OrganizationUnitViewModel
            {
                Id = ou.Id,
                OrganizationUnitName = ou.OrganizationUnitName,
                OrganizationUnitDescription = ou.OrganizationUnitDescription,
                BUId = ou.BusinessUnitID,
                BusinessUnitList = (IList<BusinessUnit>) TempData["BUList"],
                BUList = ((IList<BusinessUnit>)TempData["BUList"]).Select(c => new SelectListItem
                {
                    Text = c.BusinessUnitName,
                    Value = c.Id.ToString()
                })
            };

            return View("New", ouViewModel);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var ouUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "OrganizationUnit", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(ouUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrganizationUnit>();
                    readTask.Wait();
                    var ou = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }
    }
}