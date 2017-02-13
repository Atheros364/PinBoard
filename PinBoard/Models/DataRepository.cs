using PinBoard.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models
{
    public class DataRepository
    {
        public bool IsDirty { get; set; }

        public List<Blurb> BlurbCollection = new List<Blurb>();
        public List<Canvas> CanvasCollection = new List<Canvas>();
        public List<Tag> TagCollection = new List<Tag>();

        public void ResetDataRepository()
        {
            BlurbCollection = new List<Blurb>();
            CanvasCollection = new List<Canvas>();
            TagCollection = new List<Tag>();
        }

        public void SaveDataToFile(string filePath)
        {
            RepositorySaveObject saveObject = new RepositorySaveObject();
            saveObject.BlurbCollection = BlurbCollection;
            saveObject.CanvasCollection = CanvasCollection;
            saveObject.TagCollection = TagCollection;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, saveObject);
            stream.Close();

            IsDirty = false;
        }

        public void LoadDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                RepositorySaveObject saveObject = (RepositorySaveObject)formatter.Deserialize(stream);
                stream.Close();

                if (saveObject != null)
                {
                    BlurbCollection = saveObject.BlurbCollection;
                    CanvasCollection = saveObject.CanvasCollection;
                    TagCollection = saveObject.TagCollection;
                }
            }
        }

        public void CreateNewBlurb(Blurb newBlurb)
        {
            int id = 1;
            Blurb lastBlurb = BlurbCollection.FirstOrDefault();
            if (lastBlurb != null)
            {
                id = lastBlurb.Id++;
            }
            newBlurb.Id = id;
            BlurbCollection.Add(newBlurb);
            IsDirty = true;
        }

        public void DeleteBlurb(int id)
        {
            foreach (Canvas canvas in CanvasCollection)
            {
                canvas.CanvasObjects.RemoveAll(co => co.BlurbId == id);
            }
            Blurb blurbToRemove = BlurbCollection.SingleOrDefault(b => b.Id == id);
            BlurbCollection.Remove(blurbToRemove);
            IsDirty = true;
        }

        public void CreateNewCanvas(Canvas newCanvas)
        {
            int id = 1;
            Canvas lastCanvas = CanvasCollection.FirstOrDefault();
            if (lastCanvas != null)
            {
                id = lastCanvas.Id++;
            }
            newCanvas.Id = id;

            CanvasCollection.Add(newCanvas);
            IsDirty = true;
        }

        public void DeleteCanvas(int id)
        {
            Canvas canvasToRemove = CanvasCollection.SingleOrDefault(c => c.Id == id);
            CanvasCollection.Remove(canvasToRemove);
            IsDirty = true;
        }

        public void CreateTag(Tag newTag)
        {
            int id = 1;
            Tag lastTag = TagCollection.FirstOrDefault();
            if (lastTag != null)
            {
                id = lastTag.Id++;
            }
            newTag.Id = id;

            TagCollection.Add(newTag);
            IsDirty = true;
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
            IsDirty = true;
        }
    }
}
