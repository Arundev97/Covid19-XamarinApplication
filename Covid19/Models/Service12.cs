using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Covid19.Models;

namespace Covid19.Models
{
    class Service12
    {
        public async Task<List<ResultData>> LoginProcess(Uri u, HttpContent content)
        {
            try
            {
                var response = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    client.MaxResponseContentBufferSize = 256000;
                    client.Timeout = TimeSpan.FromMinutes(30);
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = u,
                        Content = content
                    };
                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        response = await responseMessage.Content.ReadAsStringAsync();

                    }
                    // Dictionary<string, List<resultlist>> output = new Dictionary<string, List<resultlist>>();

                    List<ResultData> datas = new List<ResultData>();

                    var results = JsonConvert.DeserializeObject<List<ResultData>>(response);
                    var model = new ResultData
                    {
                        Status = results[0].Status,
                        Name = results[0].Name,
                        SlotId = results[0].SlotId,
                        IsSystem=results[0].IsSystem
                    };

                    datas.Add(model);

                    return datas;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ResultData>> ForgotPassword(Uri u, HttpContent c)
        {
            try
            {
                var response = string.Empty;
                using (HttpClient client=new HttpClient())
                {
                    client.MaxResponseContentBufferSize = 256000;
                    client.Timeout = TimeSpan.FromMinutes(30);
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = u,
                        Content = c
                    };
                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        response = await responseMessage.Content.ReadAsStringAsync();

                    }
                    List<ResultData> datas = new List<ResultData>();

                    var results = JsonConvert.DeserializeObject<List<ResultData>>(response);
                    var model = new ResultData
                    {
                        Status = results[0].Status,
                        Name = results[0].Name,
                        Email = results[0].Email,
                        PersonId=results[0].PersonId
                       
                    };

                    datas.Add(model);

                    return datas;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DataUpdate(Uri u, HttpContent content)
        {
            try
            {
                var response = string.Empty;
                using (var client = new HttpClient())
                {
                    client.MaxResponseContentBufferSize = 256000;
                    client.Timeout = TimeSpan.FromMinutes(30);
                    HttpRequestMessage httpRequest = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = u,
                        Content = content
                    };
                    HttpResponseMessage result = await client.SendAsync(httpRequest);
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();

                    }
                    else
                    {
                        return false;
                    }

                }
                return true;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ResultData>> GetData(Uri u)
        {
            var response = string.Empty;
            using (var client=new HttpClient())
            {
                client.MaxResponseContentBufferSize = 256000;
                client.Timeout = TimeSpan.FromMinutes(30);
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
                List<ResultData> resultData = new List<ResultData>();
                var results = JsonConvert.DeserializeObject<List<ResultData>>(response);
                for(var i = 0; i < results.Count; i++)
                {
                    var model = new ResultData
                    {
                        Name = results[i].Name,
                        Latitude = results[i].Latitude,
                        Longitude = results[i].Longitude,
                        Address = results[i].Address
                    };
                    resultData.Add(model);
                }
                return resultData;
            }
            
        }

        public async Task<List<ResultData>> GetDataByUserId(Uri u, HttpContent c)
        {
            try
            {
                var response = string.Empty;
                using (var client = new HttpClient())
                {
                    HttpRequestMessage httpRequest = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = u,
                        Content = c
                    };
                    HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        response = await httpResponse.Content.ReadAsStringAsync();
                    }
                    List<ResultData> datas = new List<ResultData>();
                    var results = JsonConvert.DeserializeObject<List<ResultData>>(response);
                    var model = new ResultData
                    {
                        Name = results[0].Name,
                        Latitude = results[0].Latitude,
                        Longitude = results[0].Longitude,
                        PersonId = results[0].PersonId,
                        Email=results[0].Email,
                        MobileNumber=results[0].MobileNumber,
                        DateOfBirth=results[0].DateOfBirth,
                        BloodGroup=results[0].BloodGroup,
                        Address=results[0].Address
                    };
                    datas.Add(model);

                    return datas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> GetResponse(Uri u)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(u);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

       
    }
}
