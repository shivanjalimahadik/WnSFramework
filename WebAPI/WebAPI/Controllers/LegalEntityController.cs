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
    public class LegalEntityController : Controller
    {
        // GET: LegalEntity
        public ActionResult Index()
        {
            IList<LegalEntity> lstLegalEntity = null;

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
                    lstLegalEntity = readTask.Result.ToList();
                    TempData["LegalEntityList"] = lstLegalEntity;
                    TempData.Keep();
                }
            }

            LegalEntityViewmodel legalEntityViewModel = new ViewModels.LegalEntityViewmodel
            {
                LegalEntityList = lstLegalEntity
            };

            return View(legalEntityViewModel);
        }

        public ActionResult Save(LegalEntityViewmodel legalEntityViewModel)
        {
            if(ModelState.IsValid)
            {
                List<LegalEntity> legalEntityList = new List<LegalEntity>();

                if (string.IsNullOrEmpty(Convert.ToString(legalEntityViewModel.Id)) || string.Equals(Convert.ToString(legalEntityViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    legalEntityList.Add(new LegalEntity { LegalEntityName = legalEntityViewModel.LegalEntityName });

                    using (var client = new HttpClient())
                    {
                        var legalEntityUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "LegalEntity" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(legalEntityUrl, legalEntityList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode) { }
                    }
                }
                else
                {
                    legalEntityList.Add(new LegalEntity { Id = legalEntityViewModel.Id, LegalEntityName = legalEntityViewModel.LegalEntityName });
                    using (var client = new HttpClient())
                    {
                        var legalEntityUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "LegalEntity" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(legalEntityUrl, legalEntityList);
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
            LegalEntity legalEntity = null;

            using (var client = new HttpClient())
            {
                var legalEntityUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "LegalEntity", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(legalEntityUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LegalEntity>();
                    readTask.Wait();
                    legalEntity = readTask.Result;
                }
            }

            //IList<LegalEntity> lstLegalEntity = null;

            //using (var client = new HttpClient())
            //{
            //    var legalEntityUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "LegalEntity" }, Request.Url.Scheme);
            //    var responseTask = client.GetAsync(legalEntityUrl);
            //    responseTask.Wait();
            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IEnumerable<LegalEntity>>();
            //        readTask.Wait();
            //        lstLegalEntity = readTask.Result.ToList();
            //    }
            //}

            LegalEntityViewmodel legalEntityViewModel = new LegalEntityViewmodel
            {
                Id = new Guid(id),
                LegalEntityName = legalEntity.LegalEntityName,
                LegalEntityList = TempData["LegalEntityList"] as IList<LegalEntity>
            };

            TempData.Keep();

            return View("Index", legalEntityViewModel);
        }
    }
}