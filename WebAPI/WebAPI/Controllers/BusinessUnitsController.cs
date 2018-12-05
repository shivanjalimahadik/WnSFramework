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
    public class BusinessUnitsController : Controller
    {
        // GET: BusinessUnits
        public ActionResult Index()
        {
            IList<BUWrapper> businessUnitList = null;

            using (var client = new HttpClient())
            {
                var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
                string requestUrl = businessUnitUrl.ToString() + "/GetAllBU";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<BUWrapper>>();
                    readTask.Wait();
                    businessUnitList = readTask.Result.ToList();
                }
            }

            IList<LegalEntity> LegalEntityList = null;

            using (var client = new HttpClient())
            {
                var legalEntityUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "LegalEntity" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(legalEntityUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<LegalEntity>>();
                    readTask.Wait();
                    LegalEntityList = readTask.Result.ToList();
                    TempData["LEList"] = LegalEntityList;
                    TempData.Keep();
                }
            }

            BusinessUnitsViewModel businessUnitModel = new BusinessUnitsViewModel()
            {
                BUWrapperList = businessUnitList
            };       
                return View(businessUnitModel);
        }

        public ActionResult New()
        {
            BusinessUnitsViewModel businessUnitModel = new BusinessUnitsViewModel
            {
                LegalEntityList = (IList<LegalEntity>)TempData["LEList"],
                LEList = ((IList<LegalEntity>)TempData["LEList"]).Select(c => new SelectListItem
                {
                    Text = c.LegalEntityName,
                    Value = c.Id.ToString()
                })
            };

            return View(businessUnitModel);
        }

        public ActionResult Edit(string id)
        {
            BusinessUnit bu = null;
 

            using (var client = new HttpClient())
            {
                var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(businessUnitUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BusinessUnit>();
                    readTask.Wait();
                    bu = readTask.Result;
                }
            }

            BusinessUnitsViewModel businessUnitViewModel = new BusinessUnitsViewModel()
            {
                Id = bu.Id,
                BusinessUnitName = bu.BusinessUnitName,
                BusinessUnitDescription = bu.BusinessUnitDescription,
                LEId = bu.LegalEntityID,

                LegalEntityList = (IList<LegalEntity>)TempData["LEList"],
                LEList = ((IList<LegalEntity>)TempData["LEList"]).Select(c => new SelectListItem
                {
                    Text = c.LegalEntityName,
                    Value = c.Id.ToString()
                })

            };

            return View("New", businessUnitViewModel);
        }

        public ActionResult Save(BusinessUnitsViewModel buvm)
        {
            if (ModelState.IsValid)
            {
                List<BusinessUnit> businessUnitList = new List<BusinessUnit>();

                if (string.IsNullOrEmpty(Convert.ToString(buvm.Id)) || string.Equals(Convert.ToString(buvm.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    businessUnitList.Add(new BusinessUnit
                    {
                        BusinessUnitName = buvm.BusinessUnitName,
                        BusinessUnitDescription = buvm.BusinessUnitDescription,
                        LegalEntityID = buvm.LEId
                    });

                    using (var client = new HttpClient())
                    {
                        var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(businessUnitUrl, businessUnitList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    businessUnitList.Add(new BusinessUnit
                    {
                        Id = buvm.Id, BusinessUnitName = buvm.BusinessUnitName,
                        BusinessUnitDescription = buvm.BusinessUnitDescription,
                        LegalEntityID = buvm.LEId
                    });

                    using (var client = new HttpClient())
                    {
                        var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(businessUnitUrl, businessUnitList);
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
                //ModelState.AddModelError("BusinessUnit",)
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(businessUnitUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BusinessUnit>();
                    readTask.Wait();
                    var businessUnit = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }


    }
}