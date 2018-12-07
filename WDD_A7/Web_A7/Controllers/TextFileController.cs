/*
* FILE          : TestFileController.cs
* PROJECT       : PROG2000 - Assignment #7
* PROGRAMMER    : Alex Kozak & Attila Katona
* FIRST VERSION : 2018-12-06
* DESCRIPTION   : This file contains the Controller for the /api/textfile commands
*/

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Web_A7.Models;

namespace Web_A7.Controllers
{
    public class TextFileController : ApiController
    {
        string dirName = Directory.GetCurrentDirectory();
        //string dirName = @"C:\tmp";

        /* FUNCTION     : GetAllFiles
         * DESCIPTION   : This function Saves the current contents of the 
         *              main text window, sending a post request to the API with
         *              the current value of the save file text box as the file name
         * PARAMETERS   : VOID
         * RETURNS      : List<TextFile> : all of the current files in the directory
         */
        private List<TextFile> GetAllFiles()
        {                               
            // confirm the directory exists, creating it if it doesnt exist.
            if (!Directory.Exists(dirName + @"\MyFiles")) { Directory.CreateDirectory(dirName + @"\MyFiles"); }

            List<TextFile> lFiles = new List<TextFile>();
            int i = 0;
            foreach (string fullFilePath in Directory.EnumerateFiles(dirName + @"\MyFiles"))
            {
                // split the path to get the file name only from the full path
                string[] splitPath = fullFilePath.Split('\\');
                string fileName = splitPath[splitPath.Count() - 1];

                // add a new text file to the list, adding ID, name, and path
                lFiles.Add(new TextFile(i++, fileName, fullFilePath));
            }
            return lFiles;
        }

        /* FUNCTION     : GetAllTextFiles
         * DESCIPTION   : This returns all of the files on a /api/textfile call, without the content of the file
         * PARAMETERS   : VOID
         * RETURNS      : IEnumerable<TextFile> : all of the current files in the directory
         */
        public IEnumerable<TextFile> GetAllTextFiles()
        {
            // get the list of name/id but not file path 
            return GetAllFiles();
        }

        /* FUNCTION     : GetTestFile
         * DESCIPTION   : This returns a single file based on ID call, including the content of the file
         * PARAMETERS   : VOID
         * RETURNS      : IHttpActionResult : The file requested with an OK message, or a NotFound message
         */
        public IHttpActionResult GetTestFile(int id)
        {            
            // get all of the text files, then only send back the requested file with the full content of the file
            TextFile tf = GetAllFiles().FirstOrDefault((p) => p.fileID == id);
            if (tf == null) { return NotFound(); }
            tf.GetContent();
            return Ok(tf);
        }

        /* FUNCTION     : saveFileAsync
         * DESCIPTION   : This function handles a POST request to /api/testfile/SaveFile by saving the 
         *              given file to the working directory if possible. Returning a string to the client
         *              notifying if the file was saved or not
         * PARAMETERS   : VOID
         * RETURNS      : string : returns a message to be displayed to the client, either a success message
         *              or the error code explaining why the message wasn't displayed
         */
        [AcceptVerbs("POST")]
        [ActionName("SaveFile")]
        public async Task<string> saveFileAsync()
        {
            try
            {
                // Get the values from the post method which contain the name and content of the file to be saved.
                dynamic obj = await Request.Content.ReadAsAsync<JObject>();
                string fileName = obj.fileName;
                string fileContent = obj.fileContent;
                string filePath = dirName + @"\MyFiles\" + fileName.Replace('\\','_').Replace('/','_');

                // If there is no file extension, append a .txt extension
                if (!filePath.Contains(".")) { filePath += ".txt"; }

                // confirm the directory exists, otherwise create it
                if (!Directory.Exists(dirName + @"\MyFiles")) { Directory.CreateDirectory(dirName + @"\MyFiles"); }

                // (over)write the content to the selected file.
                File.WriteAllText(filePath, fileContent);

                // The file saved successfully, send back a message saying that.
                return "File saved successfully";
            }
            catch(Exception e)
            {
                // return the message if for some reason the file fialed to save (i.e. bad file name)
                return e.Message;
            }
        }
    }
}
