using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime SendTime { get; set; }
        public string TextMessage { get; set; }
    }
}
