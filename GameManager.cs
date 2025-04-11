using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;
    
    private List<GameObject> _gameObjects = new List<GameObject>();
    
    private int _frames;
    private int _score;
    private int _lives;
    
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
        Bomb b1 = new Bomb(600, 100, 4, 10);
        Gems g1 = new Gems(100, 100, 4);
        _gameObjects.AddRange(new List<GameObject> {p1, g1, b1});
        Raylib.DrawText("Lives: 3", 12, 12, 20, Color.Black);


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
        // _gameObjects[2].Move();
        foreach(GameObject item in _gameObjects)
        {
            item.Move();
        }
    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }

    }
}