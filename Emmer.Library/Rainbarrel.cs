namespace Emmer.Library;

public class Rainbarrel : Container
{
    private RainbarrelCapacity RainbarrelCapacity { get; set; }

    public Rainbarrel(RainbarrelCapacity capacity)
    {
        this.Capacity = (int)capacity;
    }
}