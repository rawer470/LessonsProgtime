﻿using Newtonsoft.Json;
using RestApi_Sun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApi_Sun
{
    public static class SunProccessor
    {
        private static HttpClient client = new HttpClient();
        public static async Task<SunResultModel> LoadSunInfo(float lat = 0,float lng =0)
        {
            string url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lng}\r\n";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                SunResultModel sunResultModel = JsonConvert.DeserializeObject<SunResultModel>(responceString);
                return sunResultModel;
            }
        }
    }
}
