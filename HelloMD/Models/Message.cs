using HelloMD.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace HelloMD.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        
        [ForeignKey("Sender")]
        public int? WriterID { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int? ReceiverID { get; set; }
        public virtual User Receiver { get; set; }

        [Required]
        public string Body { get; set; }
        
        [ForeignKey("ReplMsg")]
        public int? ReplayFor { get; set; }
        public virtual Message ReplMsg { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
