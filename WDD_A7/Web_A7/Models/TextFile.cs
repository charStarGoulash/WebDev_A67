using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_A7.Models
{
    public class TextFile
    {
        public int fileID;
        public string fileName;
        public string fileContent;

        public TextFile(int id, string fName, string fContent = null)
        {
            fileID = id;
            fileName = fName;
            fileContent = fContent;
        }
    }
}