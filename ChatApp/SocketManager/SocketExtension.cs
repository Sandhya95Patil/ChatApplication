//-----------------------------------------------------------------------
// <copyright file="ConnectionManager.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.SocketManager
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    /// <summary>
    /// Socket Extension class
    /// </summary>
    public static class SocketExtension
    {
        /// <summary>
        /// Add Web Socket Manager
        /// </summary>
        /// <param name="services">services parameter</param>
        /// <returns></returns>
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(SocketHandler))
                    services.AddSingleton(type);
            }
            return services;
        }

        /// <summary>
        /// Map Sockets Method
        /// </summary>
        /// <param name="app">app parameter</param>
        /// <param name="path">path parameter</param>
        /// <param name="socket">socket parameter</param>
        /// <returns>map sockets</returns>
        public static IApplicationBuilder MapSockets(this IApplicationBuilder app, PathString path, SocketHandler socket)
        {
            return app.Map(path, (x) => x.UseMiddleware<SocketMiddleware>(socket));
        }
    }
}
