using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedAuthorization.DataAccess
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Errors { get; set; }
    }
}
