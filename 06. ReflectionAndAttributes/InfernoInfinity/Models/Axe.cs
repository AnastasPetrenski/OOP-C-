using System;
using System.Collections.Generic;

using InfernoInfinity.Contracts;
using InfernoInfinity.CustomAttributes;

namespace InfernoInfinity.Models
{
    public class Axe : IWeapon
    {
        private const int SOCKETS = 4;

        public Axe(string levelOfRarity, string name)
        {
            this.LevelOfRarity = levelOfRarity;
            this.Name = name;
            this.Gems = new List<IGem>(SOCKETS);
        }

        [Damage(5, 10)]
        public int Damage { get; private set; }

        public IList<IGem> Gems { get; private set; }
        public string LevelOfRarity { get; private set; }
        public string Name { get; private set; }

        public bool CheckSocket(int index)
        {
            return index >= 0 && index < SOCKETS;
        }

        public void InsertGemAtSocket(int index, IGem gem)
        {
            try
            {
                this.Gems.RemoveAt(index);
            }
            catch (Exception)
            {
            }
            
            this.Gems.Insert(index, gem);
        }
    }
}
