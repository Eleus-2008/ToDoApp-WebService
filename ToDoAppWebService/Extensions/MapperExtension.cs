using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ToDoAppWebService.Mapper;

namespace ToDoAppWebService.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}