abstract class FallingObject: GameObject
{
    public FallingObject(int x, int y, int sp)
    {
        _x=x;
        _y=y;
        _speed=sp;
    }
    
    public abstract bool HitPlayer(GameObject other);
    
    public override void Move()
    {
        _y = _y + _speed;
        if(_y >= 800)
        {
            _speed =0;
        }
    }
}