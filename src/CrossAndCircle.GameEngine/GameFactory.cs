namespace CrossAndCircle.GameEngine
{
    public static class GameFactory
    {
        /// <summary>
        /// Creates 3x3 game with give player and other player as BOT.
        /// </summary>
        public static Game CreateGameWithBot(IPlayer player)
        {
            var board = GameBoardFactory.Create(3);
            var game = new Game(
                board, 
                player, 
                new SimpleBot(player.Id.Other()),
                new DefaultGameObserver());
            return game;
        }

        /// <summary>
        /// Creates 3x3 game with give player and other player as BOT.
        /// </summary>
        public static Game CreateGameWithBot(IPlayer player, IGameStateObserver observer)
        {
            var board = GameBoardFactory.Create(3);
            var game = new Game(
                board,
                player,
                new AdvancedBot(player.Id.Other()),
                observer);
            return game;
        }

        public static Game Create1v1Game(IPlayer p1, IPlayer p2, IGameStateObserver observer)
        {
            var board = GameBoardFactory.Create(3);
            var game = new Game(
                board,
                p1,
                p2,
                observer);
            return game;
        }
    }
}
