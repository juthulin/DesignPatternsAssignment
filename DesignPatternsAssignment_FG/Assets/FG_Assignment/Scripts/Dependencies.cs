public struct Dependencies
{
    public GameManager           GameManager;
    public GameStateManager      GameStateManager;
    public CommandFactory        CommandFactory;
    public Commander             Commander;
    public InputManager          InputManager;
    public PlayerFactory         PlayerFactory;
    public PlayerFactorySettings PlayerFactorySettings;

    public Dependencies(
        GameManager gameManager,
        GameStateManager gameStateManager,
        CommandFactory commandFactory,
        Commander commander,
        InputManager inputManager,
        PlayerFactory playerFactory,
        PlayerFactorySettings playerFactorySettings
    )
    {
        this.GameManager = gameManager;
        this.GameStateManager = gameStateManager;
        this.CommandFactory = commandFactory;
        this.Commander = commander;
        this.InputManager = inputManager;
        this.PlayerFactory = playerFactory;
        this.PlayerFactorySettings = playerFactorySettings;
    }
}