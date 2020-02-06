using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using WPF_TaskList.Models;

namespace WPF_TaskList.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<TaskModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TaskModel>();
            }

            using (StreamReader reader = File.OpenText(PATH))
            {
                string fileText = reader.ReadToEnd();
                if (fileText != "")
                    return JsonConvert.DeserializeObject<BindingList<TaskModel>>(fileText);
                return new BindingList<TaskModel>();
            }
        }

        public void SaveData(object _taskListData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_taskListData);
                writer.Write(output);
            }
        }
    }
}
