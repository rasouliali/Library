using Newtonsoft.Json.Linq;

namespace Library.API.Controllers
{
    internal static class SharedLogic
    {

        public static int GetUserId(HttpRequest request)
        {
            try
            {
                return int.Parse(request.Headers["UserId"].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public static string CalcResult(string res)
        {
            var resObj = JObject.Parse(res);
            if (resObj.Value<bool>("success"))
                return "";
            return (res ?? "").Contains("(401) Unauthorized") ? "401" : resObj.Value<string>("message");
        }
    }
}