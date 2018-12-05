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
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            IList<ProcessWrapper> processList = null;

            using (var client = new HttpClient())
            {
                var processUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Process" }, Request.Url.Scheme);
                string requestUrl = processUrl.ToString() + "/GetAllP";
                var responseTask = client.GetAsync(requestUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProcessWrapper>>();
                    readTask.Wait();
                    processList = readTask.Result.ToList();
                }
            }

            IList<Resources> resourceList = null;

            using (var client = new HttpClient())
            {
                var resourceUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Resources" }, Request.Url.Scheme);
                var responseTask = client.GetAsync(resourceUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Resources>>();
                    readTask.Wait();
                    resourceList = readTask.Result.ToList();
                    TempData["RList"] = resourceList;
                    TempData.Keep();
                }
            }

            ProcessViewModel pViewModel = new ProcessViewModel()
            {
                ProcessWrapperList = processList
            };

            return View(pViewModel);
        }

        public ActionResult New()
        {
            ProcessViewModel processViewmodel = new ProcessViewModel
            {
                ResourceList = (IList<Resources>)TempData["RList"],
                RList = ((IList<Resources>)TempData["RList"]).Select(c => new SelectListItem
                {
                    Text = c.ResourceName,
                    Value = c.Id.ToString()
                })
            };

            return View(processViewmodel);
        }

        public ActionResult Save(ProcessViewModel pViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Process> pList = new List<Process>();

                if (string.IsNullOrEmpty(Convert.ToString(pViewModel.Id)) || string.Equals(Convert.ToString(pViewModel.Id), "00000000-0000-0000-0000-000000000000"))
                {
                    pList.Add(new Process
                    {
                        ProcessName = pViewModel.ProcessName,
                        ResourcesID = pViewModel.RId
                    });

                    using (var client = new HttpClient())
                    {
                        var pUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Process" }, Request.Url.Scheme);
                        var response = client.PostAsJsonAsync(pUrl, pList);
                        response.Wait();
                        var result = response.Result;

                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                else
                {
                    pList.Add(new Process
                    {
                        Id = pViewModel.Id,
                        ProcessName = pViewModel.ProcessName,
                        ResourcesID = pViewModel.RId
                    });

                    using (var client = new HttpClient())
                    {
                        var pUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Process" }, Request.Url.Scheme);
                        var response = client.PutAsJsonAsync(pUrl, pList);
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
            Process p = null;

            using (var client = new HttpClient())
            {
                var pUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Process", id = id }, Request.Url.Scheme);
                var responseTask = client.GetAsync(pUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Process>();
                    readTask.Wait();
                    p = readTask.Result;
                }
            }

            ProcessViewModel pViewModel = new ProcessViewModel
            {
                Id = p.Id,
                ProcessName = p.ProcessName,
                RId = p.ResourcesID,
                ResourceList = (IList<Resources>)TempData["RList"],
                RList = ((IList<Resources>)TempData["RList"]).Select(c => new SelectListItem
                {
                    Text = c.ResourceName,
                    Value = c.Id.ToString()
                })
            };

            return View("New", pViewModel);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var pUrl = Url.RouteUrl("DefaultApi", new { httpRoute = "", controller = "Process", id = id }, Request.Url.Scheme);
                var responseTask = client.DeleteAsync(pUrl);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Process>();
                    readTask.Wait();
                    var p = readTask.Result;
                }
            }

            return RedirectToAction("Index");
        }

    }
}