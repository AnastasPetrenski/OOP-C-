using OOP03InterfacesAndAbstraction.Interfaces;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWork)
        {
            this.PartName = partName;
            this.HoursWork = hoursWork;
        }

        public string PartName { get; }

        public int HoursWork { get; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWork}";
        }
    }
}
