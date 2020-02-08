using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class AddMessageResponseModel
    {
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
