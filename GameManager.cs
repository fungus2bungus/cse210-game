using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;
    
    private List<GameObject> _gameObjects = new List<GameObject>();
    
    private int _score = 0;
    private int _lives = 3;
    
    public GameManager()
    {
        _title = "CSE 210 Game";
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        Player p1 = new Player();
        Bomb b1 = new Bomb(600, 100, 4);
        Gems g1 = new Gems(100, 100, 4);
        _gameObjects.AddRange(new List<GameObject> {p1, g1, b1});
        
        // I think I need to somehow make a fuction that infinitely loop and creates bombs and gems at different postions, but how?
        // well step 1 would be randrange? step 2 would be 
        // wait I'd have to call it somwhere else...
        

    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {
        // _gameObjects[0].Move();

    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        foreach(GameObject item in _gameObjects)
        {
            item.Move();
        }
        
        // foreach(FallingObject item in _gameObjects.Skip(1))
        // {
        //     if(item.HitPlayer(_gameObjects[0]) == true)
        //     {
        //         // _gameObjects.Remove(_gameObjects[2]);
        //         _gameObjects.RemoveAll(item);
        //         _lives--;
        //         Raylib.DrawText($"Lives: {_lives}", 12, 12, 20, Color.Black);
        //     }
        // }
        for(int i = _gameObjects.Count-1; i>=0; i--)
        {
            if(_gameObjects[i] is FallingObject fallingObject)
            {
                if(fallingObject.HitPlayer(_gameObjects[0]) == true)
                {
                    _gameObjects.RemoveAt(i);
                    if(fallingObject is Bomb b)
                    {
                        _lives--;
                        if (_lives == 0)
                        {
                            _gameObjects.RemoveAt(0);
                        }
                    }
                    
                    if (fallingObject is Gems g)
                    {
                        _score++;
                    }
                }
                else if(fallingObject.Getter("y") > 600)
                {
                    _gameObjects.RemoveAt(i);
                }

            }


        }
    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        Raylib.DrawText($"Lives: {_lives}", 12, 12, 20, Color.Black);
        Raylib.DrawText($"Score: {_score}", 130, 12, 20, Color.Blue);
        // I'd probably call that "makeobjects" function here I guess?
        // wait I don't need a while loop, I just need it to make stuff here
        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }
        if (_lives > 0)
        {
            MakeObjects();

        }
    }
// okay, this more or less works... except for the fact that it runs on every single frame...
    private void MakeObjects()
    {
        float st = 0f;
        float si = 0.016889f;
        float dt = Raylib.GetFrameTime();
        st+=dt;
        Random random = new Random();
        int randr = random.Next(19, 720);
        int randr2 = random.Next(19, 720);
        int randsp = random.Next(2, 10);
        int randsp2 = random.Next(2, 10);
        // Console.WriteLine(st);

        if (st > si)
        {
            st = 0f;

            Bomb b2 = new Bomb(randr, 70, randsp);
            _gameObjects.Add(b2);
            Gems g2 = new Gems(randr2, 70, randsp2);
            _gameObjects.Add(g2);
        }
    }

    
}