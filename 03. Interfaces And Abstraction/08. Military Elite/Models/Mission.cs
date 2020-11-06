using OOP03InterfacesAndAbstraction.Enums;
using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Mission : IMission
    {
        private string missionStatEnum;

        public Mission(string codeName, string missionStatEnum)
        {
            this.CodeName = codeName;
            this.MissionStatEnum = missionStatEnum;
        }

        public string CodeName { get; }

        public string MissionStatEnum 
        { 
            get => this.missionStatEnum;
            set
            {
                MissionStatEnum missionStatEnum;
                if (!Enum.TryParse<MissionStatEnum>(value, out missionStatEnum))
                {
                    throw new ArgumentException();
                }

                this.missionStatEnum = missionStatEnum.ToString();
            }
        }

        public void CompleteMission(string missionName)
        {
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {missionStatEnum}";
        }
    }
}
