using Biblioteka.BLL.AuthorBLL;
using Biblioteka.BLL.AuthorBLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteka.Services
{
    public static class AuthorBLLServices
    {
        public static IServiceCollection AddAuthorBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorDbSet, AuthorDbSet>();
            services.AddScoped<IDeleteAuthorData, DeleteAuthorData>();
            services.AddScoped<IReadListAuthorData, ReadListAuthorData>();
            services.AddScoped<IReadDetailAuthorData, ReadDetailAuthorData>();
            services.AddScoped<IUpdateAuthorData, UpdateAuthorData>();
            services.AddScoped<IWriteAuthorData, WriteAuthorData>();
            return services;
        }
    }
}
