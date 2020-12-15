using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController manager;

        public Engine(IReader reader, IWriter writer, IManagerController manager)
        {
            this.reader = reader;
            this.writer = writer;
            this.manager = manager;
        }

        public void Run()
        {
            string command = string.Empty;
            var sb = new StringBuilder();

            while ((command = reader.ReadLine()) != "Exit")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = input[0];
                try
                {
                    if (commandType == "AddPlayer")
                    {
                        sb.AppendLine(manager.AddPlayer(input[1], input[2]));
                    }
                    if (commandType == "AddCard")
                    {
                        sb.AppendLine(manager.AddCard(input[1], input[2]));
                    }
                    if (commandType == "AddPlayerCard")
                    {
                        sb.AppendLine(manager.AddPlayerCard(input[1], input[2]));
                    }
                    if (commandType == "Fight")
                    {
                        sb.AppendLine(manager.Fight(input[1], input[2]));
                    }
                    if (commandType == "Report")
                    {
                        sb.AppendLine(manager.Report());
                    }
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.Message);
                }
                
            }

            writer.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
