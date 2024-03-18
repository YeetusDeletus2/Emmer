namespace Emmer.Library;

public delegate void OverflowEventHandler(int overflowAmount);

public class Container
{
    private int _capacity;
    private int _contents;

    public int Capacity
    {
        get { return _capacity; }
        set
        {
            if (_capacity == 0)
            {
                if (value < 0 || value > 2500)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The capacity cannot be below 0 or exceed 2500.");
                }

                _capacity = value;
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
        get { return _contents; }
        protected set { _contents = value; }
        // The setter is protected to ensure that it can only be changed by the fill and empty functions outside of this class.
    }

    public void FillContent(int amount)
    {
        if (_contents + amount <= Capacity)
        {
            _contents += amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Cannot increase content above the capacity.");
        }
    }

    public void EmptyContent(int amount)
    {
        if (_contents - amount >= 0)
        {
            _contents -= amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Cannot decrease content below 0.");
        }
    }

    public void EmptyContent()
    {
        _contents = 0;
    }
}