/*
* FILE          : TestFile.cs
* PROJECT       : PROG2000 - Assignment #7
* PROGRAMMER    : Alex Kozak & Attila Katona
* FIRST VERSION : 2018-12-06
* DESCRIPTION   : This file contains the class structure to be sent back and forth throug the API in JSON blocks
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web_A7.Models
{
    /*  CLASS       : TextFile
     *  DESCRIPTION : This class contains the ID, name, and content of the file, stored in plain text.
     * 
     * 
     */ 
    public class TextFile
    {
        public int fileID;
        public string fileName;
        private string fullFilePath;
        public string fileContent;

        public TextFile(int fileID, string fileName, string fullFilePath, string fileContent = null)
        {
            this.fileID = fileID;
            this.fileName = fileName;
            this.fullFilePath = fullFilePath;
            this.fileContent = fileContent;
        }

        public void GetContent()
        {
            fileContent = File.ReadAllText(fullFilePath);
        }
    }
}