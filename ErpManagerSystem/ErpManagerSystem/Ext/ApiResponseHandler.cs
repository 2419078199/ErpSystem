﻿using Common.Help;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ErpManagerSystem.Ext
{
    public class ApiResponseHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ApiResponseHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new System.NotImplementedException();
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            MessageModel<string> res = new MessageModel<string>();
            res.Code = 401;
            res.Success = false;
            res.Msg = "很抱歉，您无权访问该接口，请确保已经登录!";
            await Response.WriteAsync(JsonConvert.SerializeObject(res));
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status403Forbidden;
            MessageModel<string> res = new MessageModel<string>();
            res.Code = 403;
            res.Success = false;
            res.Msg = "很抱歉，您的访问权限等级不够，联系管理员!";
            await Response.WriteAsync(JsonConvert.SerializeObject(res));
        }
    }
}