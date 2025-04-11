abstract class FallingObject: GameObject
{
    public FallingObject()
    {
        
    }
    
    public abstract void HitPlayer(GameObject other);
    
    public override void Move()
    {
        _y = _y + _speed;
    }
}