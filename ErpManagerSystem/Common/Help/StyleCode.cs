﻿namespace Common.Help
{
    public static class StyleCode
    {
        public static MessageModel<T> NotFound<T>(MessageModel<T> res)
        {
            res.Code = 404;
            res.Msg = "请输入正确的信息！！！";
            res.Success = false;
            return res;
        }
    }
}