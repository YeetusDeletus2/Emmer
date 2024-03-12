namespace Emmer.Library;

public class Rainbarrel : Container
{
    public Rainbarrel(int capacity)
    {
        if (capacity != 80 && capacity != 100 && capacity != 120)
        {
            throw new WrongCapacityException(nameof(capacity),
                "The capacity of a rainbarrel can only be 80, 100 or 120.");
        }
        else
        {
            this.Capacity = capacity;
        }
    }
}