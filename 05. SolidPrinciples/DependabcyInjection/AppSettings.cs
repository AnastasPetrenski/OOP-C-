using DependencyInjection.Contracts;

namespace DependencyInjection
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString => "My cool cat";
    }
}