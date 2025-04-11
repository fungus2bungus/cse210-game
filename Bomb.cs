using Raylib_cs;

class Bomb : FallingObject
{
    private float _radius=10;
    
    public Bomb(int x, int y, int sp) :base(x,y,sp)
    {
        _x = x;
        _y=y;
        _speed=sp;
        // _radius=rad;
    }

    // TODO: Constructor?
    

    public override void Draw() //circle
    {
        Raylib.DrawCircle(_x, _y, _radius, Color.Black);

    }

    public override bool HitPlayer(GameObject other)
    {
        // other.Getter("x") > _x && 
        if (_x < other.Getter("x")+20 && _x+_radius > other.Getter("x") && _y < other.Getter("y")+20 && _y+_radius > other.Getter("y") && _speed > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}