using Newtonsoft.Json;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WTD.Controllers
{
    public class MapJSONController : Controller
    {
        //
        // GET: /MapJSON/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FetchEvents()
        {
            string URL = "http://api.eventful.com/json/events/search";
            string urlParameters = "?app_key=NGmDfJc99PXsLsT5&q=music&l=21015&within=10&units=miles";

           // var client = new HttpClient();

            //List<Events> model = null;

            //var task = client.GetAsync("http://api.eventful.com/json/events/search?app_key=NGmDfJc99PXsLsT5&q=music&l=21015&within=10&units=miles")
            //   .ContinueWith((taskwithresponse) =>
            //   {
            //       var response = taskwithresponse.Result;
            //       var jsonString = response.Content.ReadAsStringAsync();
            //       jsonString.Wait();
            //       model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Events>>(jsonString.Result);

            //   });
            //task.Wait();


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;


            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!

                //var dataObjects = response.Content.ReadAsAsync<Events>().Result;


                var dataObjects = response.Content.ReadAsStringAsync();
                dataObjects.Wait();

                string data = dataObjects.Result.Where(c => c.Equals ("event")).ToString();

                List<Events> model = JsonConvert.DeserializeObject<List<Events>>(data.ToString());
                
                

                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.description);
                //}
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            return null;
        }
        public class Events
        {
            public object watching_count { get; set; }
            public string olson_path { get; set; }
            public object calendar_count { get; set; }
            public object comment_count { get; set; }
            public string region_abbr { get; set; }
            public string postal_code { get; set; }
            public object going_count { get; set; }
            public string all_day { get; set; }
            public string latitude { get; set; }
            public object groups { get; set; }
            public string url { get; set; }
            public string id { get; set; }
            public string privacy { get; set; }
            public string city_name { get; set; }
            public object link_count { get; set; }
            public string longitude { get; set; }
            public string country_name { get; set; }
            public string country_abbr { get; set; }
            public string region_name { get; set; }
            public string start_time { get; set; }
            public object tz_id { get; set; }
            public string description { get; set; }
            public string modified { get; set; }
            public string venue_display { get; set; }
            public object tz_country { get; set; }
            public object performers { get; set; }
            public string title { get; set; }
            public string venue_address { get; set; }
            public string geocode_type { get; set; }
            public object tz_olson_path { get; set; }
            public object recur_string { get; set; }
            public object calendars { get; set; }
            public string owner { get; set; }
            public object going { get; set; }
            public string country_abbr2 { get; set; }
            public Image image { get; set; }
            public string created { get; set; }
            public string venue_id { get; set; }
            public object tz_city { get; set; }
            public string stop_time { get; set; }
            public string venue_name { get; set; }
            public string venue_url { get; set; }
        }

        public class Image
        {
            public Small small { get; set; }
            public string width { get; set; }
            public object caption { get; set; }
            public Medium medium { get; set; }
            public string url { get; set; }
            public Thumb thumb { get; set; }
            public string height { get; set; }
        }

        public class Small
        {
            public string width { get; set; }
            public string url { get; set; }
            public string height { get; set; }
        }

        public class Medium
        {
            public string width { get; set; }
            public string url { get; set; }
            public string height { get; set; }
        }

        public class Thumb
        {
            public string width { get; set; }
            public string url { get; set; }
            public string height { get; set; }
        }




    }

}