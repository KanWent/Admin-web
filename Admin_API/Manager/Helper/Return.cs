using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Manager.API.Helper
{
    public class Return
    {
        /// <summary>
        /// 返回查询类json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <param name="t"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetReturn<T>(int code, string msg, T t, int count = 0)
        {
            Manager.Model.Base.ReturnBase<T> errReturn = new();
            errReturn.code = code;
            errReturn.data = t;
            errReturn.count = count;
            errReturn.msg = msg;
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(errReturn, timeConverter);
        }

    }
}
