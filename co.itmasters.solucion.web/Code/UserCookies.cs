using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace co.itmasters.solucion.web.Code
{
    public class UserCookies : PageBase
    {
        public void Add(string key, string value)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            Request.Cookies.Add(cookie);
                
        }
        public string Get(string key)
        {
            string cookieValue =  Request.Cookies[key]?.Value;
            return cookieValue;
        }
        public void Remove(string key)
        {
            Request.Cookies.Remove(key);
        }
    }
}