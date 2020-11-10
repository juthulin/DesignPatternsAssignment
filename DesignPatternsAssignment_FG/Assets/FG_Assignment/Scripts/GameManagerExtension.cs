public static class GameManagerExtension
{
    public static PlayerController GetMainPlayer(this GameManager gameManager)
    {
        return gameManager.Players[gameManager.MainPlayerID];
    }
}
