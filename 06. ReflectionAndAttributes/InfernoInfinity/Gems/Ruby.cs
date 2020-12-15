using InfernoInfinity.Contracts;

namespace InfernoInfinity.Gems
{
    public class Ruby : IGem
    {
        private const int STRENGTH = 7;
        private const int AGILITY = 2;
        private const int VITALITY = 5;

        public Ruby(string levelOfClarity)
        {
            this.Strength = STRENGTH;
            this.Agiity = AGILITY;
            this.Vitality = VITALITY;
            this.LevelOfClarity = levelOfClarity;
        }

        public int Strength { get; }

        public int Agiity { get; }

        public int Vitality { get; }

        public string LevelOfClarity { get; set; }
    }
}
