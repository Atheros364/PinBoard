using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    [Serializable]
    public class Canvas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string BackgroundColor { get; set; }
        public List<CanvasObject> CanvasObjects { get; set; }

        public Canvas()
        {
            Id = 0;
            Name = "";
            Height = 1000;
            Width = 1000;
            BackgroundColor = "#F0E68C";
            CanvasObjects = new List<CanvasObject>();
        }
    }
}
