using System;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    /// <summary>
    /// FactoryPattern: this player factory is a simple factory that only creates one thing,
    /// but it could easily be expanded to create different kind of player depending on some condition.
    /// </summary>
    private PlayerFactorySettings _playerFactorySettings;
    private GameManager           _gameManager;

    public void Initialize(Dependencies dependencies)
    {
        _gameManager = dependencies.GameManager;
        _playerFactorySettings = dependencies.PlayerFactorySettings;
    }

    public void CreateMainPlayer()
    {
        GameObject playerPrefab = GameObject.Instantiate(_playerFactorySettings.playerPrefab,
            _playerFactorySettings.spawnTransform.position,
            _playerFactorySettings.spawnTransform.rotation);
        
        Guid             mainPlayerID = Guid.NewGuid();
        PlayerController mainPlayer   = playerPrefab.GetComponent<PlayerController>();

        mainPlayer.ObjectID = mainPlayerID;
        _gameManager.MainPlayerID = mainPlayerID;
        
        mainPlayer.Initialize();
        
        _gameManager.Players.Add(_gameManager.MainPlayerID, mainPlayer);
    }
}