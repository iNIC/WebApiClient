﻿using System.Threading.Tasks;

namespace WebApiClientCore.Attributes
{
    /// <summary>
    /// 使用JsonFormatter序列化参数值得到的json文本作为application/json请求
    /// 每个Api只能注明于其中的一个参数
    /// </summary>
    public class JsonContentAttribute : HttpContentAttribute
    {
        /// <summary>
        /// 设置参数到http请求内容
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        protected override Task SetHttpContentAsync(ApiParameterContext context)
        {
            var utf8Json = context.SerializeToJson();
            context.HttpContext.RequestMessage.Content = new JsonContent(utf8Json);
            return Task.CompletedTask;
        }
    }
}
