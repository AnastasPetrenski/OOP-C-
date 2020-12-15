namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Writer writer = new Writer();
            Reader reader = new Reader();
            ManagerController manager = new ManagerController();
            Engine engine = new Engine(reader, writer, manager);
            engine.Run();
        }
    }
}