using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChalkCouture.HttpClientServices
{
    public class HttpService : IHttpService
    {

        public void GetOrder(int customerId)
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<object>>(json);
            }
        }
    }
}
