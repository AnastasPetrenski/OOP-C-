using DependencyInjection;
using DependencyInjection.Contracts;
using SimpleInjector;
using System;
using System.IO;

namespace DependabcyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var container = new Container();

            container.Register<IAppSettings, AppSettings>();
            container.Register<IDateTimeProvider, DateTimeProvider>();
            container.Register<IDbContext, DbContext>();
            container.Register<IRandomProvider, RandomProvider>();
            container.Register<CatService>();

            container.Verify();

            var catService = container.GetInstance<CatService>();
            
            var randomCat = catService.RandomCatsFromToday();

            foreach (var item in randomCat)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
