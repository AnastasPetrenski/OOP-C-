using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Contracts
{
    public interface IFeedable
    {
        public void TryFeeding(IFood food);
    }
}
