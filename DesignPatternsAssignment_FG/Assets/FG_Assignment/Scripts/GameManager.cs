using System;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-50)]
public class GameManager : MonoBehaviour
{
    private readonly GameStateManager _gameStateManager = new GameStateManager();
    private readonly CommandFactory   _commandFactory   = new CommandFactory();
    private readonly InputManager     _inputManager     = new InputManager();
    private readonly PlayerFactory    _playerFactory    = new PlayerFactory();
    private          Dependencies     _dependencies;

    [SerializeField] private PlayerFactorySettings playerFactorySettings;

    public readonly Commander Commander = new Commander();
    public Dictionary<Guid, PlayerController> Players = new Dictionary<Guid, PlayerController>();
    public Guid MainPlayerID;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        _dependencies = new Dependencies(
            this,
            _gameStateManager,
            _commandFactory,
            Commander,
            _inputManager,
            _playerFactory,
            playerFactorySettings
        );

        InitializeComponents(_dependencies);
    }

    private void Update()
    {
        _inputManager.Tick();
    }

    private void InitializeComponents(in Dependencies dependencies)
    {
        Commander.Initialize(dependencies);
        _inputManager.Initialize(dependencies);
        _playerFactory.Initialize(dependencies);
    }

    public void StartGame()
    {
        _playerFactory.CreateMainPlayer();
        
        _inputManager.ReceivePlayerRef(this.GetMainPlayer());
        
        _gameStateManager.ChangeGameState(GameState.PlayState);
    }

    public void GameOver()
    {
        _gameStateManager.ChangeGameState(GameState.StartState);
        Debug.Log("Game Over!");
    }
}