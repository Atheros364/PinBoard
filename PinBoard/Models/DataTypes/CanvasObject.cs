using PinBoard.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PinBoard.Models.DataTypes
{
    [Serializable]
    public class CanvasObject
    {
        public int Id { get; set; }
        public CanvasObjectTypes Type { get; set; }
        public Vector Origin { get; set; }
        public Vector Vertex { get; set; }
        public int BlurbId { get; set; }
        public Blurb Blurb { get; set; }
        public string Color { get; set; }
        public bool IsFilled { get; set; }

        public CanvasObject()
        {
            Id = 0;
        }
    }
}
