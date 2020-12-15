using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.Happiness -= 5;
            robot.ProcedureTime -= procedureTime;
            robot.IsChipped = true;

            this.Robots.Add(robot);
            //if (!this.Robots.ContainsKey(this.GetType().Name))
            //{
            //    this.Robots.Add(this.GetType().Name, new List<IRobot>());
            //}

            //this.Robots[this.GetType().Name].Add(robot);
        }
    }
}
