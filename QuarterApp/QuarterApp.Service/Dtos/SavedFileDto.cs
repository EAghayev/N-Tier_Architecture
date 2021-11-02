using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Dtos
{
    public class SavedFileDto
    {
        public string FileName { get; set; }
        public string ChangedFileName { get; set; }
        public string Path { get; set; }
    }
}
