using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    public class JsonFileController: IStorageController
    {
        public string FilePath { get; set; } 
        public string FileName { get; set; }
        public string FullPath { get; set; }
        protected IAdapterJson adapter;
        

        public JsonFileController(IAdapterJson adapter)
        {
            this.adapter = adapter;
            FileName = "\\users.json";
            CalculateFullPath();
        }

        public List<User> ReadData()
        {
            CalculateFullPath();
            try
            {
                var data =  File.ReadAllText(FullPath);

                return adapter.ConvertFromJson(data);
            }
            catch(FileNotFoundException e)
            {
                return null;
            }
        }
        public void WriteData(List<User> userList)
        {
            CalculateFullPath();

            var jsonString = this.adapter.ConvertToJson(userList);
            File.WriteAllText(FullPath, jsonString);
        }
        private void CalculateFullPath()
        {
            FilePath = Directory.GetCurrentDirectory();
            FullPath = FilePath + FileName;
        }
    }
}
