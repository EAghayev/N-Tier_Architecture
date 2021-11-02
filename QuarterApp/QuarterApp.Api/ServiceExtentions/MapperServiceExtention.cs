using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuarterApp.Service.HelperService.Interfaces;
using QuarterApp.Service.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Api.ServiceExtentions
{
    public static class MapperServiceExtention
    {
        public static void AddMapperService(this IServiceCollection services)
        {

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile(provider.GetService<IHelperAccessor>()));
            }).CreateMapper());
        }
    }
}
