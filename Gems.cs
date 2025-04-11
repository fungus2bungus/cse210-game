using Raylib_cs;

class Gems : FallingObject
{
    // constructor?
    public Gems(int x, int y, int sp)
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

    public override void HitPlayer(GameObject other)
    {

    }
}