public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;

    private double energyOutput;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        throw new System.NotImplementedException();
    }

    public double Produce()
    {
        throw new System.NotImplementedException();
    }

    public void Repair(double val)
    {
        throw new System.NotImplementedException();
    }
}