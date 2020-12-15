using BarracksWarANewFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data { get; set; }

        protected IRepository Repository { get; set; }

        protected IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            set { this.unitFactory = value; }
        }

        public abstract string Execute();
    }
}
