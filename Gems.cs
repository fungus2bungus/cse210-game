using Raylib_cs;

class Gems : FallingObject
{
    // constructor?
    public Gems(int x, int y, int sp) : base(x,y,sp)
    {
        _x=x;
        _y=y;
        _speed=sp;
    }

    public override void Draw()
    {
        // Raylib.DrawRectangleLines(_x, _y, 20, 20, Color.Blue);
        Rectangle m = new Rectangle(_x, _y, 20, 20);
        Raylib.DrawRectangleLinesEx(m, 3, Color.Blue);
        
    }

    public override bool HitPlayer(GameObject other)
    {
        // other.Getter("x") > _x && 
        if (_x < other.Getter("x")+20 && _x+20 > other.Getter("x") && _y < other.Getter("y")+20 && _y+20 > other.Getter("y") && _speed > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}