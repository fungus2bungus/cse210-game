using Raylib_cs;
class Player : GameObject
{
    // private string _left = "left";
    // private string _right = "right";
    // I honestly have no idea how I was supposed to use these

    public Player()
    {
        _x = 400;
        _y = 565;
        _speed = 10;
    }
    
    public override void Draw() //square
    {
        Raylib.DrawRectangle(_x, _y, 20, 20, Color.Magenta);
    }

    public void SetSpeed(bool m)
    {
        

    }

    public override void Move()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            _x=_x-_speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            _x=_x+_speed;
        }
    }

    public void MoveLeft()
    {
        _x= _x - _speed;
    }
    
    public void MoveRight()
    {
        _x= _x + _speed;
    }

}