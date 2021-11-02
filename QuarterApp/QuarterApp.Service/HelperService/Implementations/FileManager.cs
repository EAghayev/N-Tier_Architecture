using Microsoft.AspNetCore.Http;
using QuarterApp.Service.Dtos;
using QuarterApp.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.HelperService.Implementations
{
    public class FileManager : IFileManager
    {
        private readonly IHelperAccessor _helperAccessor;

        public FileManager(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;
        }
        public async Task<SavedFileDto> Save(IFormFile file,string folder)
        {
            string newFileName = file.FileName;
            newFileName = newFileName.Length > 64 ? newFileName.Substring(newFileName.Length - 64, 64) : newFileName;
            newFileName = Guid.NewGuid().ToString() + newFileName;
            string path = Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/uploads/",folder,newFileName);


            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            SavedFileDto savedFile = new SavedFileDto
            {
                FileName = file.FileName,
                ChangedFileName = newFileName,
                Path = _helperAccessor.BaseUrl+"/uploads/properties/" + newFileName
            };

            return savedFile;
        }
    }
}
