namespace Emmer.Library;

public class Container
{
    private int capacity;
    private int contents;

    public int Capacity
    {
        get { return capacity; }
        set
        {
            if (capacity == 0)
            {
                if (value < 0 || value > 2500)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The capacity cannot be below 0 or exceed 2500.");
                }

                capacity = value;
            }
            else
            {
                throw new InvalidOperationException(
                    "The capacity cannot be changed after the container has been made.");
            }
        }
    }

    public int Contents
    {
        get { return contents; }
        set { contents = value; }
    }

    public void IncreaseContent(int amount)
    {
        if (contents + amount <= Capacity)
        {
            contents += amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Cannot increase content above the capacity.");
        }
    }

    public void DecreaseContent(int amount)
    {
        if (contents - amount >= 0)
        {
            contents -= amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount), 
                "Cannot decrease content below 0.");
        }
    }

    public void EmptyContent()
    {
        contents = 0;
    }
}