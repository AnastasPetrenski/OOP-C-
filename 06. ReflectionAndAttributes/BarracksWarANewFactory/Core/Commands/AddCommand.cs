using BarracksWarANewFactory.Contracts;
using CustomAttributes;

namespace BarracksWarANewFactory.Core.Commands
{
    public class AddCommand : Command
    {

        //[Inject]
        //private IRepository repository;

        //[Inject]
        //private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.Add(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
