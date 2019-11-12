﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Map.Comunicator.Domain.Model
{
    public class Message : BaseModel
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
    }
}
