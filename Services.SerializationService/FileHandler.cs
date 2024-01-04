using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;

namespace De.HsFlensburg.DiagrammApp.Services.SerializationService
{
    public class FileHandler
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DiagrammApp\\TableData.cc";

        public Table ReadModelFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamLoad = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Table loadedCollection = (Table)formatter.Deserialize(streamLoad);
            streamLoad.Close();
            return loadedCollection;
        }

        public void WriteModelToFile(Table model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }
    }
}
