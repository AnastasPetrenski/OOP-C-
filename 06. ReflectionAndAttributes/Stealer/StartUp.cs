using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
            Console.WriteLine(spy.AnalyzeAcessModifiers("Stealer.Hacker"));
            Console.WriteLine(spy.RevealPrivateMethods("Stealer.Hacker"));
            Console.WriteLine(spy.CollectGetterAndSetter("Stealer.Hacker"));


            string[] arguments = new string[] { "ON", "OFF" };
            string argument = arguments.Length > 0 ? arguments[0].ToUpper() : null;

            ISwitchable lamp = new Light();

            // Pass reference to the lamp instance to each command
            ICommand switchClose = new CloseSwitchCommand(lamp);
            ICommand switchOpen = new OpenSwitchCommand(lamp);

            // Pass reference to instances of the Command objects to the switch
            Switch @switch = new Switch(switchClose, switchOpen);

            if (argument == "ON")
            {
                // Switch (the Invoker) will invoke Execute() on the command object.
                @switch.Open();
            }
            else if (argument == "OFF")
            {
                // Switch (the Invoker) will invoke the Execute() on the command object.
                @switch.Close();
            }
            else
            {
                Console.WriteLine("Argument \"ON\" or \"OFF\" is required.");
            }

        }
    }


    public interface ICommand
    {
        void Execute();
    }

    /* The Invoker class */
    public class Switch
    {
        ICommand _closedCommand;
        ICommand _openedCommand;

        public Switch(ICommand closedCommand, ICommand openedCommand)
        {
            this._closedCommand = closedCommand;
            this._openedCommand = openedCommand;
        }

        // Close the circuit / power on
        public void Close()
        {
            this._closedCommand.Execute();
        }

        // Open the circuit / power off
        public void Open()
        {
            this._openedCommand.Execute();
        }
    }

    /* An interface that defines actions that the receiver can perform */
    public interface ISwitchable
    {
        void PowerOn();
        void PowerOff();
    }

    /* The Receiver class */
    public class Light : ISwitchable
    {
        public void PowerOn()
        {
            Console.WriteLine("The light is on");
        }

        public void PowerOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    /* The Command for turning off the device - ConcreteCommand #1 */
    public class CloseSwitchCommand : ICommand
    {
        private ISwitchable _switchable;

        public CloseSwitchCommand(ISwitchable switchable)
        {
            _switchable = switchable;
        }

        public void Execute()
        {
            _switchable.PowerOff();
        }
    }

    /* The Command for turning on the device - ConcreteCommand #2 */
    public class OpenSwitchCommand : ICommand
    {
        private ISwitchable _switchable;

        public OpenSwitchCommand(ISwitchable switchable)
        {
            _switchable = switchable;
        }

        public void Execute()
        {
            _switchable.PowerOn();
        }
    }

    /* The test class or client */

}
