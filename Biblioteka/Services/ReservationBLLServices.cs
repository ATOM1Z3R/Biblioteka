using Biblioteka.BLL.ReservationBLL;
using Biblioteka.BLL.ReservationBLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteka.Services
{
    public static class ReservationBLLServices
    {
        public static IServiceCollection AddReservationBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IReadListData, ReadListData>();
            services.AddScoped<IWriteData, WriteData>();
            return services;
        }
    }
}
