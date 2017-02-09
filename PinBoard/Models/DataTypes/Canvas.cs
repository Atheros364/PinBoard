using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    public class Canvas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string BackgroundColor { get; set; }
        public List<CanvasObject> CanvasObjects { get; set; }
    }
}
