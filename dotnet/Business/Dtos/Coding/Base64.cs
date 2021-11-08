using Business.Dtos.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos.Coding
{
    public class Base64 : IUrlManager
    {
        public string Decode(string Url)
        {
            var valueBytes = Convert.FromBase64String(Url);
            return Encoding.UTF8.GetString(valueBytes);
        }

        public string Encode(string Url)
        {
            var valueBytes = Encoding.UTF8.GetBytes(Url);
            return Convert.ToBase64String(valueBytes);
        }
    }
}
