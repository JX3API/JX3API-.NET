using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace JX3API.NET
{
    public class common
    {


        /// <summary>
        /// get请求封装
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="queryParams">请求参数</param>
        /// <param name="cookies">请求cookies</param>
        /// <returns></returns>
        public async static Task<JObject> RequestGet(string url, object queryParams = null, string cookies = "", object headers = null)
        {
            JObject data;
           
            url = Jx3Api.Jx3ApiUrl + url;


            try
            {
                var response = await url
                    .SetQueryParams(queryParams)
                    .WithCookies(cookies)
                    .WithHeaders(headers)
                    .GetAsync();

                // 获取响应的内容并解析为 JSON
                var result = await response.GetJsonAsync();
                data = JObject.FromObject(result);
                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error in HTTP request: {ex.Message}");
                data = JObject.FromObject(new { code = 401, error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                data = JObject.FromObject(new { code = 500, error = ex.Message });
            }

            return data;
        }

        /// <summary>
        /// post请求封装
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="queryParams">请求参数</param>
        /// <param name="cookies">请求cookies</param>
        /// <returns></returns>
        public async static Task<JObject> RequestPost(string url, object queryParams, string cookies = "", object headers = null)
        {
            JObject data;
            url = Jx3Api.Jx3ApiUrl + url;
            try
            {
                // 发送 POST 请求并接收 JSON 数据
                var result = await url
                    .WithCookies(cookies)
                    .WithHeaders(headers)
                    .PostJsonAsync(queryParams)
                    .ReceiveJson();
                // 将 JSON 数据转换为 JObject
                data = JObject.FromObject(result);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error in HTTP request: {ex.Message}");
                data = JObject.FromObject(new { code = 401, error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                data = JObject.FromObject(new { code = 500, error = ex.Message });
            }

            return data;
        }


        /// <summary>
        /// json解析
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static JObject Jobject(string response)
        {


            JObject responseObj = JObject.Parse(response);
            return responseObj;
        }


        
    }
}
