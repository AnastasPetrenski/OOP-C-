using OOP03InterfacesAndAbstraction.Enums;

namespace OOP03InterfacesAndAbstraction.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }

        public string MissionStatEnum { get; }

        void CompleteMission(string missionName);
    }
}