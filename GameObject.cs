using Raylib_cs;
public abstract class GameObject
{
    protected int _x;
    protected int _y;
    protected int _speed;

    public abstract void Draw();
        // virtual? I guess this means it'd be overriden
        // main way of drawing the function
    public abstract void Move();

    public virtual int Getter(string n)
    {
        switch(n)
        {
            case "x":
            return _x;
            
            case "y":
            return _y;

            default:
            return 0;
        }
    }
}