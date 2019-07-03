using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReadApi
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-8.59755&date=today";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                    //if (comicNumber == 0)
                    //{
                    //    MaxComicNumber = comic.Num;
                    //}

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase); //sunInfo.Sunset.ToLocalTime().ToShortTimeString();
                }
            }
        }
        
        public static Task<SunModel> getStuff()
        {
            var sunInfo = SunProcessor.LoadSunInformation();

            var a= sunInfo.Result;

            return sunInfo;
        }

        public static string getSunrise()
        {
            Task<SunModel> sunInfo1 = getStuff();

            SunModel sunInfo = sunInfo1.Result;

            return sunInfo.Sunrise.ToLocalTime().ToShortTimeString();
        }

        public static string getSunset()
        {
            Task<SunModel> sunInfo1 =getStuff();

            SunModel sunInfo = sunInfo1.Result;

            return sunInfo.Sunset.ToLocalTime().ToShortTimeString();
        }
    }
}
