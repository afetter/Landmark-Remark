using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class User: BaseModel
    {
        public string Username { get; set; }
        public string Pwd { get; set; }
    }
}
