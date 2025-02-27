using Library.Application.Dto;
using System.Net;
using System.Net.Mime;
using System.Reflection;

namespace Library.UI.Helpers
{
    public class ApiCaller
    {
        public async Task<string> CallGetApiAsync(string url,string token, int UserId)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.KeepAlive = true;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
                {
                    return true;
                };

                if (string.IsNullOrEmpty(token) == false)
                {
                    httpWebRequest.Headers["Authorization"] = "Bearer " + token;
                    httpWebRequest.Headers["UserId"] = UserId+"";
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseText = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = await streamReader.ReadToEndAsync();
                }
                return responseText;
            }
            catch (Exception err)
            {
                return "errorOccured:" + err.ToString();
            }
        }
        public async Task<string> CallDeleteApiAsync(string url, string contentType, string bodyParameter, string token, int UserId)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "DELETE";
                httpWebRequest.KeepAlive = true;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
                {
                    return true;
                };

                httpWebRequest.ContentType = contentType;
                if (string.IsNullOrEmpty(token) == false)
                {
                    httpWebRequest.Headers["Authorization"] = "Bearer " + token;
                    httpWebRequest.Headers["UserId"] = UserId+"";
                }
                if (string.IsNullOrEmpty(bodyParameter) == false /*&& acceptType.ToLower().Contains("json")*/)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(bodyParameter);
                    }
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseText = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = await streamReader.ReadToEndAsync();
                }
                return responseText;
            }
            catch (Exception err)
            {
                return "errorOccured:" + err.ToString();
            }
        }
        public async Task<string> CallPostApiAsync(string url,string contentType,string bodyParameter,string token,int UserId)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
                {
                    return true;
                };

                if (string.IsNullOrEmpty(token) == false)
                {
                    httpWebRequest.Headers["Authorization"] = "Bearer " + token;
                    httpWebRequest.Headers["UserId"] = UserId+"";
                }
                if (string.IsNullOrEmpty(bodyParameter) == false /*&& acceptType.ToLower().Contains("json")*/)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(bodyParameter);
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseText = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = await streamReader.ReadToEndAsync();
                }
                return responseText;
            }
            catch (Exception err)
            {
                return "errorOccured:" + err.ToString();
            }
        }
        public async Task<string> CallPutApiAsync(string url,string contentType,string bodyParameter,string token,int UserId)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = "PUT";
                httpWebRequest.KeepAlive = true;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
                {
                    return true;
                };

                if (string.IsNullOrEmpty(token) == false)
                {
                    httpWebRequest.Headers["Authorization"] = "Bearer " + token;
                    httpWebRequest.Headers["UserId"] = UserId+"";
                }
                if (string.IsNullOrEmpty(bodyParameter) == false /*&& acceptType.ToLower().Contains("json")*/)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(bodyParameter);
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseText = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = await streamReader.ReadToEndAsync();
                }
                return responseText;
            }
            catch (Exception err)
            {
                return "errorOccured:" + err.ToString();
            }
        }
    }
}
