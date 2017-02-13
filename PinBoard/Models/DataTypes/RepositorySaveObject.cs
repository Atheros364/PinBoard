using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    [Serializable]
    public class RepositorySaveObject
    {
        public List<Blurb> BlurbCollection = new List<Blurb>();
        public List<Canvas> CanvasCollection = new List<Canvas>();
        public List<Tag> TagCollection = new List<Tag>();
    }
}
