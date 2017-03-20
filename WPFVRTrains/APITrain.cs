using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class APITrain
    {
        public static string GetJsonFromLiikenneVirasto(string filter)
        {
            try
            {
                string url = "";
                url = @"http://rata.digitraffic.fi/api/v1/live-trains?station=" + filter;
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    string json = wc.DownloadString(url);
                    return json;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
