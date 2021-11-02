using Microsoft.AspNetCore.Http;
using QuarterApp.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.HelperService.Implementations
{
    public class HelperAccessor : IHelperAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string BaseUrl => $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
    }
}
