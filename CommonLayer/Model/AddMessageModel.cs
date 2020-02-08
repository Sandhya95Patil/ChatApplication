using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AddMessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ReceiverId { get; set; }
        //public int SenderId { get; set; }
    }
}
