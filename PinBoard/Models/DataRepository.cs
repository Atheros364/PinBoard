using PinBoard.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models
{
    public class DataRepository
    {
        public bool IsDirty { get; set; }

        public List<Blurb> BlurbCollection;
        public List<Canvas> CanvasCollection;
        public List<Tag> TagCollection;

        public void LoadDataFromFile(string filePath)
        {
            //
        }

        public void SaveDataToFile(string filePath)
        {
            //
        }

        public void CreateNewBlurb(Blurb newBlurb)
        {
            BlurbCollection.Add(newBlurb);
        }

        public void DeleteBlurb(int id)
        {
            foreach (Canvas canvas in CanvasCollection)
            {
                canvas.CanvasObjects.RemoveAll(co => co.BlurbId == id);
            }
            Blurb blurbToRemove = BlurbCollection.SingleOrDefault(b => b.Id == id);
            BlurbCollection.Remove(blurbToRemove);
        }

        public void CreateNewCanvas(Canvas newCanvas)
        {
            CanvasCollection.Add(newCanvas);
        }

        public void DeleteCanvas(int id)
        {
            Canvas canvasToRemove = CanvasCollection.SingleOrDefault(c => c.Id == id);
            CanvasCollection.Remove(canvasToRemove);
        }

        public void CreateTag(Tag newTag)
        {
            TagCollection.Add(newTag);
        }

        public void DeleteTag(int id)
        {
            foreach (Blurb blurb in BlurbCollection)
            {
                Tag blurbTagToRemove = blurb.Tags.SingleOrDefault(t => t.Id == id);
                blurb.Tags.Remove(blurbTagToRemove);
            }
            Tag tagToRemove = TagCollection.SingleOrDefault(t => t.Id == id);
            TagCollection.Remove(tagToRemove);
        }
    }
}
