using Microsoft.AspNetCore.Http;
using QuarterApp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.HelperService.Interfaces
{
    public interface IFileManager
    {
        Task<SavedFileDto> Save(IFormFile file, string folder);
    }
}
