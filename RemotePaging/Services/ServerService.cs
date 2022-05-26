using Newtonsoft.Json.Linq;
using RemotePaging.Models;

namespace RemotePaging.Services
{
    public class ServerService
    {
        private readonly HttpClient httpClient;

        public ServerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Info>> GetAsync(int top, int skip)
        {
            try
            {
                var url = new Uri($"https://apitest.processcloud.net/PFAPI_Manager/pfapi/list?committente=2&class=ARTICOLI&top={top}&skip={skip}&sort=RowID DESC");
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var rawJson = await response.Content.ReadAsStringAsync();//getting raw json data
                    var raw = JObject.Parse(rawJson);
                    var d = raw.SelectToken("value").ToObject<List<Info>>();

                    return d!;
                } 

                //if there is a 400 badrequest result returns an empty list.
                return new List<Info>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Info>();
            }
        }
    }
}
