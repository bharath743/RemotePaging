using Newtonsoft.Json;
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

        public async Task<List<Info2>> GetAsync2(int top, int skip)
        {
            try
            {
                var url = new Uri($"https://apitest.processcloud.net/PFAPI_Manager/pfapi/list?committente=2&class=RAPPINTE&top={top}&skip={skip}&sort=RowID DESC");
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var rawJson = await response.Content.ReadAsStringAsync();//getting raw json data
                    var raw = JObject.Parse(rawJson);
                    var d = raw.SelectToken("value").ToObject<List<Info2>>();

                    return d!;
                }

                //if there is a 400 badrequest result returns an empty list.
                return new List<Info2>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Info2>();
            }
        }

        public async Task<DataInfo> GetAsync3(int top, int skip)
        {
            try
            {
                var url = new Uri($"https://ghoapi.azureedge.net/api/WHOSIS_000001?$count=true&$top={top}&skip={skip}");
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var rawJson = await response.Content.ReadAsStringAsync();//getting raw json data
                    var data = JsonConvert.DeserializeObject<DataInfo>(rawJson);

                    return data!;
                }

                //if there is a 400 badrequest result returns an empty list.
                return null!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null!;
            }
        }
    }
}
