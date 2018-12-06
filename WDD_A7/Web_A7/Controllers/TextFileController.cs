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
        // currently 
        string dirName = Directory.GetCurrentDirectory();
        //string dirName = @"C:\tmp";

        private List<TextFile> GetAllFiles()
        {            
            List<TextFile> lFiles = new List<TextFile>();
            int i = 0;
            if (!Directory.Exists(dirName + @"\MyFiles")) { Directory.CreateDirectory(dirName + @"\MyFiles"); }

            foreach (string s in Directory.EnumerateFiles(dirName + @"\MyFiles"))
            {
                string[] str = s.Split('\\');
                lFiles.Add(new TextFile(i++, str[str.Count() - 1], File.ReadAllText(s)));
            }
            return lFiles;
        }

        public IEnumerable<TextFile> GetAllTextFiles()
        {
            return GetAllFiles();
        }

        public IHttpActionResult GetTestFile(int id)
        {
            TextFile tf = GetAllFiles().FirstOrDefault((p) => p.fileID == id);
            if (tf == null) { return NotFound(); }
            return Ok(tf);
        }

        [AcceptVerbs("POST")]
        [ActionName("SaveFile")]
        public async Task<string> saveFileAsync()
        {
            try
            {
                dynamic obj = await Request.Content.ReadAsAsync<JObject>();
                string fileName = obj.fileName;
                string fileContent = obj.fileContent;
                string filePath = dirName + @"\MyFiles\" + fileName;

                if (!Directory.Exists(dirName + @"\MyFiles")) { Directory.CreateDirectory(dirName + @"\MyFiles"); }
                File.WriteAllText(filePath, fileContent);

                return "File saved successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
