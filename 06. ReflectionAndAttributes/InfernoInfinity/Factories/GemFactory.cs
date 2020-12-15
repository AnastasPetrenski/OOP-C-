using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, string levelOfClarity)
        {
            var type = Type.GetType("InfernoInfinity.Gems." + gemType);
            var gem = Activator.CreateInstance(type, new Object[] { levelOfClarity }) as IGem;

            return gem;
        }
    }
}
