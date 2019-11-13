using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class User: BaseModel
    {
        /// <summary>
        /// Username/Email
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Pwd { get; set; }
    }
}
