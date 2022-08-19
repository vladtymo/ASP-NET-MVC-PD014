using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Utilities
{
    public class ToastrData
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public ToastrData() { }
        public ToastrData(string jsonString)
        {
            var data = JsonSerializer.Deserialize<ToastrData>(jsonString);
            this.Message = data.Message;
            this.Type = data.Type;
            this.Title = data.Title;
        }
    }
}
