using HelloMD.models;
using HelloMD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelloMD.Dtos
{
    public class MessageDto
    {
        public int MessageID { get; set; }
        public int? WriterID { get; set; }
        public virtual User Sender { get; set; }
        public int? ReceiverID { get; set; }
        public virtual User Receiver { get; set; }
        public string Body { get; set; }
        public int? ReplayFor { get; set; }
        public virtual Message ReplMsg { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
