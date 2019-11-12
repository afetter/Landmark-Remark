using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Comunicator.Domain.ViewModel
{
    public class ResponseEnvelope<T>
    {
        public ResponseEnvelope()
        {
            Errors = new List<string>();
        }
        public ResponseEnvelope<T> AddError(string message)
        {
            Errors.Add(message);
            return this;
        }
        public T Result { get; set; }

        public IList<string> Errors { get; set; }

        public bool HasError

        {
            get
            {
                return Errors != null && Errors.Any();
            }

        }
    }
}
