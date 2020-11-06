using OOP03InterfacesAndAbstraction.Enums;
using OOP03InterfacesAndAbstraction.Interfaces;
using OOP03InterfacesAndAbstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Core
{
    public class Engine
    {
        private readonly ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            ISoldier soldier;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = commandArgs[0];
                int id = int.Parse(commandArgs[1]);
                string name = commandArgs[2];
                string family = commandArgs[3];

                if (soldierType == typeof(Private).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    soldier = new Private(id, name, family, salary);
                    this.soldiers.Add(soldier);
                }
                else if (soldierType == typeof(LieutenantGeneral).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    var privatesArgs = commandArgs.Skip(5).Select(int.Parse).ToArray();
                    List<ISoldier> privates = GetPrivates(privatesArgs);
                    soldier = new LieutenantGeneral(id, name, family, salary, privates);
                    this.soldiers.Add(soldier);
                }
                else if (soldierType == typeof(Engineer).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    string corp = commandArgs[5];
                    try
                    {
                        var partsArgs = commandArgs.Skip(6).ToArray();
                        var parts = new List<IRepair>();
                        for (int i = 0; i < partsArgs.Length; i++)
                        {
                            var part = new Repair(partsArgs[i], int.Parse(partsArgs[++i]));
                            parts.Add(part);
                        }
                        soldier = new Engineer(id, name, family, salary, corp, parts);
                        this.soldiers.Add(soldier);
                    }
                    catch (Exception)
                    {
                    }
                
                }
                else if (soldierType == typeof(Commando).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    string corp = commandArgs[5];
                    try
                    {
                        Commando commando = new Commando(id, name, family, salary, corp);
                        var missionArgs = commandArgs.Skip(6).ToArray();
                        for (int i = 0; i < missionArgs.Length; i++)
                        {
                            try
                            {
                                var mission = new Mission(missionArgs[i], missionArgs[++i]);
                                commando.AddMission(mission);
                            }
                            catch (Exception)
                            {
                            }
                        }

                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (soldierType == typeof(Spy).Name)
                {
                    int code = int.Parse(commandArgs[4]);
                    soldier = new Spy(id, name, family, code);
                    this.soldiers.Add(soldier);
                }
            }

            PrintResult(soldiers);
        }

        private List<ISoldier> GetPrivates(int[] privatesArgs)
        {
            List<ISoldier> privates = new List<ISoldier>();
            
            foreach (var id in privatesArgs)
            {
                if (this.soldiers.Any(s => s.Id == id))
                {
                    privates.Add(this.soldiers.FirstOrDefault(s => s.Id == id));
                }
            }

            return privates;
        }

        private void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
