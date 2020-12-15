public class Program
{
    public static void Main(string[] args)
    {
        HarvesterFactory harvesterFactory = new HarvesterFactory();
        ProviderFactory providerFactory = new ProviderFactory();
        DraftManager manager = new DraftManager(harvesterFactory, providerFactory);
        Engine engine = new Engine(manager);
        engine.Run();
    }
}