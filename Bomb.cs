using Raylib_cs;

class Bomb : FallingObject
{
    private float _radius;
    
    public Bomb(int x, int y, int speed, float rad)
    {
        _x = x;
        _y=y;
        _speed=speed;
        _radius=rad;
    }

    // TODO: Constructor?
    

    public override void Draw() //circle
    {
        Raylib.DrawCircle(_x, _y, _radius, Color.Black);

    }

    public override void HitPlayer(GameObject other)
    {

        

    }
}