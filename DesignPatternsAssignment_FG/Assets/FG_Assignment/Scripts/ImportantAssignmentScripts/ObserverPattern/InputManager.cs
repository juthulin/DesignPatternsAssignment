using UnityEngine;

public class InputManager : ISubscriber
{
    private GameState        _gameState;
    private PlayerController _player;
    private GameStateManager _gameStateManager;

    public void Initialize(Dependencies dependencies)
    {
        _gameStateManager = dependencies.GameStateManager;
        _gameStateManager.Subscribe(this);
        _gameState = _gameStateManager.GameState;
    }

    public void ReceivePlayerRef(in PlayerController playerController)
    {
        _player = playerController;
    }

    /// <summary>
    /// StatePattern: The input manager uses a state pattern to change what input is checked for in
    /// different states of the game.
    /// ObserverPattern: The input manager observes the gameState manager to get notified when the
    /// game state changes. 
    /// </summary>
    public void Tick()
    {
        switch (_gameState)
        {
            case GameState.StartState:
                InputSchemeStart();
                break;
            case GameState.PlayState:
                InputSchemePlay();
                break;
            case GameState.PauseState:
                InputSchemePause();
                break;
        }
        _player?.Tick();
    }

    private void InputSchemeStart()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GameManager.Instance.StartGame();
    }

    private void InputSchemePlay()
    {
        _player.MoveLeft = Input.GetKey(KeyCode.A);
        _player.MoveRight = Input.GetKey(KeyCode.D);
        
        if(Input.GetKeyDown(KeyCode.Space)) _player.Jump();
        
        if(Input.GetMouseButtonDown(0)) _player.Attack();
        
        if(Input.GetKeyDown(KeyCode.Escape)) _gameStateManager.ChangeGameState(GameState.PauseState);
    }

    private void InputSchemePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) _gameStateManager.ChangeGameState(GameState.PlayState);
    }

    public void SubscriberUpdate(ISubject subject)
    {
        if (subject is GameStateManager manager) _gameState = manager.GameState;
    }
}
