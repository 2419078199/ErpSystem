using System;

namespace Common.Help
{
    public class MessageModel<T>
    {
        public bool Success { get; set; } = true;
        public int Code { get; set; } = 200;
        public string Msg { get; set; } = "成功！！！";
        public T Data { get; set; }
    }
}