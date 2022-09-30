using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
    public class RegionController : BaseController<Region, RegionRepository>
    {
        public RegionController(RegionRepository repository) : base(repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
    // below is the example of using httpClientGenerics and one way to implement token into the app
    //public class RegionController : Controller
    //{
    //    // using generics 
    //    HTTPClientGenerics<Region> HttpApiRegion = new HTTPClientGenerics<Region>("Region"); // setting the end point
    //    // select all data
    //    public IActionResult Index()
    //    {
    //        IEnumerable<Region> regions = null;
    //        string token = HttpContext.Session.GetString("token");
    //        regions = HttpApiRegion.Get(token);
    //        return View(regions);
    //        //IEnumerable<Region> regions = null;
    //        //using (var client = new HttpClient())
    //        //{
    //        //    string token = HttpContext.Session.GetString("token");

    //        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //        //    client.BaseAddress = new Uri("https://localhost:44364/api/");
    //        //    // http get
    //        //    var responseTask = client.GetAsync("Region");
    //        //    responseTask.Wait();
    //        //    var result = responseTask.Result;
    //        //    if (result.IsSuccessStatusCode)
    //        //    {
    //        //        // Get the response
    //        //        var ResultJsonString = result.Content.ReadAsStringAsync();
    //        //        ResultJsonString.Wait();
    //        //        JObject rss = JObject.Parse(ResultJsonString.Result);
    //        //        JArray data = (JArray)rss["data"];
    //        //        regions = JsonConvert.DeserializeObject<List<Region>>(JsonConvert.SerializeObject(data));
    //        //    }
    //        //    else
    //        //    {
    //        //        regions = Enumerable.Empty<Region>();
    //        //        ModelState.AddModelError(string.Empty, "Server Error");
    //        //    }
    //        //}
    //        //return View(regions);
    //    }

    //    // getting create page
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // create operation
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(Region region)
    //    {
    //        string token = HttpContext.Session.GetString("token");
    //        string statusCode = HttpApiRegion.Create(region, token);
    //        if (!string.IsNullOrWhiteSpace(statusCode) && statusCode == "200")
    //        {
    //            // resultCode returns 200 which means its successful
    //            return RedirectToAction("Index");
    //        }
    //        return View(region);
    //        //using (var client = new HttpClient())
    //        //{
    //        //    string token = HttpContext.Session.GetString("token");

    //        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //        //    client.BaseAddress = new Uri("https://localhost:44364/api/");
    //        //    var postTask = client.PostAsJsonAsync<Region>("Region", region);
    //        //    postTask.Wait();
    //        //    var result = postTask.Result;
    //        //    if (result.IsSuccessStatusCode)
    //        //    {
    //        //        return RedirectToAction("Index");
    //        //    }
    //        //}
    //        //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
    //        //return View(region);
    //    }

    //    // getting edit page
    //    public IActionResult Edit(int? id)
    //    {
    //        if(id == null)
    //        {
    //            return BadRequest();
    //        }
    //        string token = HttpContext.Session.GetString("token");
    //        Region region = null;
    //        region = HttpApiRegion.Get(id, token);
    //        return View(region);
    //        //Region region = null;
    //        //using(var client = new HttpClient())
    //        //{
    //        //    string token = HttpContext.Session.GetString("token");

    //        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //        //    client.BaseAddress = new Uri("https://localhost:44364/api/");
    //        //    // get by id
    //        //    var responseTask = client.GetAsync("Region/" + id.ToString());
    //        //    responseTask.Wait();
    //        //    var result = responseTask.Result;
    //        //    if (result.IsSuccessStatusCode)
    //        //    {
    //        //        // Get the response
    //        //        var ResultJsonString = result.Content.ReadAsStringAsync();
    //        //        ResultJsonString.Wait();
    //        //        JObject rss = JObject.Parse(ResultJsonString.Result);
    //        //        JObject data = (JObject)rss["data"];
    //        //        region = JsonConvert.DeserializeObject<Region>(JsonConvert.SerializeObject(data));
    //        //    }
    //        //}
    //        //return View(region);
    //    }

    //    // edit operation
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(Region region)
    //    {
    //        string token = HttpContext.Session.GetString("token");
    //        string statusCode = HttpApiRegion.Edit(region, region.Id, token);
    //        if (!string.IsNullOrWhiteSpace(statusCode) && statusCode == "200")
    //        {
    //            return RedirectToAction("Index");
    //        }
    //        return View(region);
    //    }

    //    // getting delete confirmation page
    //    public IActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return BadRequest();
    //        }
    //        string token = HttpContext.Session.GetString("token");
    //        Region region = null;
    //        region = HttpApiRegion.Get(id, token);
    //        return View(region);
    //    }

    //    // delete operation
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Delete(Region region)
    //    {
    //        string token = HttpContext.Session.GetString("token");
    //        string statusCode = HttpApiRegion.Delete(region.Id, token);
    //        if (!string.IsNullOrWhiteSpace(statusCode) && statusCode == "200")
    //        {
    //            return RedirectToAction("Index");
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    //// edit operation
    //    //[HttpPost]
    //    //[ValidateAntiForgeryToken]
    //    //public IActionResult Edit(Region region)
    //    //{
    //    //    using(var client = new HttpClient())
    //    //    {
    //    //        string token = HttpContext.Session.GetString("token");

    //    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //        client.BaseAddress = new Uri("https://localhost:44364/api/");
    //    //        var putTask = client.PutAsJsonAsync<Region>("Region/"+region.Id.ToString(), region);
    //    //        putTask.Wait();
    //    //        var result = putTask.Result;
    //    //        if (result.IsSuccessStatusCode)
    //    //        {
    //    //            return RedirectToAction("Index");
    //    //        }
    //    //    }
    //    //    return View(region);
    //    //}

    //    //// getting delete confirmation page
    //    //public IActionResult Delete(int id)
    //    //{
    //    //    Region region = null;
    //    //    using (var client = new HttpClient())
    //    //    {
    //    //        string token = HttpContext.Session.GetString("token");

    //    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //        client.BaseAddress = new Uri("https://localhost:44364/api/");
    //    //        // get by id
    //    //        var responseTask = client.GetAsync("Region/" + id.ToString());
    //    //        responseTask.Wait();
    //    //        var result = responseTask.Result;
    //    //        if (result.IsSuccessStatusCode)
    //    //        {
    //    //            // Get the response
    //    //            var ResultJsonString = result.Content.ReadAsStringAsync();
    //    //            ResultJsonString.Wait();
    //    //            JObject rss = JObject.Parse(ResultJsonString.Result);
    //    //            JObject data = (JObject)rss["data"];
    //    //            region = JsonConvert.DeserializeObject<Region>(JsonConvert.SerializeObject(data));
    //    //        }
    //    //    }
    //    //    return View(region);
    //    //}

    //    //// delete operation
    //    //[HttpPost]
    //    //[ValidateAntiForgeryToken]
    //    //public IActionResult Delete(Region region)
    //    //{
    //    //    using(var client = new HttpClient())
    //    //    {
    //    //        string token = HttpContext.Session.GetString("token");

    //    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //        client.BaseAddress = new Uri("https://localhost:44364/api/");
    //    //        var deleteTask = client.DeleteAsync("Region/" + region.Id.ToString());
    //    //        deleteTask.Wait();

    //    //        var result = deleteTask.Result;
    //    //        if (result.IsSuccessStatusCode)
    //    //        {

    //    //            return RedirectToAction("Index");
    //    //        }

    //    //    }
    //    //    return RedirectToAction("Index");
    //    //}
    //}
}
