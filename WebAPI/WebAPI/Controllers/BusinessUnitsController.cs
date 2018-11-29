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
    public class BusinessUnitsController : Controller
    {
        // GET: BusinessUnits
        public ActionResult Index()
        {
            IList<BusinessUnit> businessUnit = null;

            using (var client = new HttpClient())
            {
                var businessUnitUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "BusinessUnit" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(businessUnitUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<BusinessUnit>>();
                    readTask.Wait();
                    businessUnit = readTask.Result.ToList();
                }
            }

            BusinessUnitsViewModel businessUnitModel = new BusinessUnitsViewModel()
            {

                businessUnitList = businessUnit
            };       
                return View(businessUnitModel);
        }

        public ActionResult New()
        {
            
            BusinessUnitsViewModel businessUnitViewModel = new BusinessUnitsViewModel();
         

            // BUList = businessUnitList.Select(c => new SelectListItem
            //{
            //    Text = c.BusinessUnitName,
            //    Value = c.Id.ToString()
            //})

            return View(businessUnitViewModel);


        }

        public ActionResult Edit(string id)
        {
            BusinessUnit businessUnit = null;
 

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
                    businessUnit = readTask.Result;
                }
            }

            BusinessUnitsViewModel businessUnitViewModel = new BusinessUnitsViewModel()
            {

                BusinessUnitName = businessUnit.BusinessUnitName,
                BusinessUnitDescription = businessUnit.BusinessUnitDescription,
                Id = new Guid(id),

                //businessUnitList = (IList<BusinessUnit>) 
                //LEList = businessUnitList.Select(c => new SelectListItem
                //{
                //    Text = c.BusinessUnitName,
                //    Value = c.Id.ToString()
                //})

            };

            return View("New", businessUnitViewModel);
        }

        public ActionResult Save(BusinessUnitsViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                List<BusinessUnit> businessUnitList = new List<BusinessUnit>();

                if (string.IsNullOrEmpty(Convert.ToString(rvm.Id)) || string.Equals(Convert.ToString(rvm.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    businessUnitList.Add(new BusinessUnit { BusinessUnitName = rvm.BusinessUnitName, BusinessUnitDescription= rvm.BusinessUnitDescription });
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
                    businessUnitList.Add(new BusinessUnit { Id = rvm.Id, BusinessUnitName = rvm.BusinessUnitName, BusinessUnitDescription = rvm.BusinessUnitDescription });
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