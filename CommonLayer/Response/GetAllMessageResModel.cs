using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class GetAllMessageResModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
