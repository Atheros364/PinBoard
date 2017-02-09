using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    public class Blurb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Tag> Tags { get; set; }
        public string Color { get; set; }
    }
}
