
using System.Collections.Generic;

namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string LevelOfRarity { get; }

        string Name { get; }

        int Damage { get; }

        IList<IGem> Gems { get; }

        public bool CheckSocket(int index);

        public void InsertGemAtSocket(int index, IGem gem);
    }
}
