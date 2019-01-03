namespace CrossAndCircle.GameEngine
{
    public interface IGameStateObserver
    {
        void OnStateChanged(GameState newState);
        void OnGameEnded(EndStatus status, Position[] winningPositions);
    }
}
