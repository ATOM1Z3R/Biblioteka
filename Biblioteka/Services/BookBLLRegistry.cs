using Biblioteka.BLL.BookBLL;
using Biblioteka.BLL.BookBLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteka.Services
{
    public static class BookBLLRegistry
    {
        public static IServiceCollection AddBookBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IReadListData, ReadListData>();
            services.AddScoped<IReadDetailData, ReadDetailData>();
            services.AddScoped<IDeleteData, DeleteData>();
            services.AddScoped<IUpdateData, UpdateData>();
            services.AddScoped<IWriteData, WriteData>();
            return services;
        }
    }
}
