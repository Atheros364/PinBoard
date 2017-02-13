using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    [Serializable]
    public class Blurb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Tag> Tags { get; set; }
        public string Color { get; set; }

        public Blurb()
        {
            Id = 0;
            Name = "";
            Description = "";
            Body = "";
            Attachments = new List<Attachment>();
            Tags = new List<Tag>();
            Color = "#D3D3D3";
        }
    }
}
