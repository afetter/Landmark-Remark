using System;
using System.Collections.Generic;
using System.Text;

namespace Map.Comunicator.Domain.ViewModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
    }
}
