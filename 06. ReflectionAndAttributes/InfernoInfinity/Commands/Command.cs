using InfernoInfinity.Contracts;

namespace InfernoInfinity.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] data, IRepository repository)
        {
            this.Data = data;
            this.Repository = repository;
        }

        public string[] Data { get; set; }
        public IRepository Repository { get; set; }

        public abstract void Execute();
    }
}
