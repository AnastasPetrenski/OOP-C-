using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {

        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected List<IRobot> Robots { get; set; }

        public abstract void DoService(IRobot robot, int procedureTime);

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            foreach (var robot in Robots)
            {   
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
