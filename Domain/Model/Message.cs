using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Message : BaseModel
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        public string Lng { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// User - must change it the FK of User table
        /// </summary>
        public string User { get; set; }
    }
}
