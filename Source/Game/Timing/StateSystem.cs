namespace Game.Timing
{
    public static class StateSystem
    {
        public static States GameState { get; set; }

        public static void TryClose()
        {
            if (GameState == States.InGame || GameState == States.GameOver) {
                GameState = States.MainMenu;
            } else {
                GameState = States.Closed;
            }
        }

        public static void NewGame()
        {
            Program.NewGame();
            GameState = States.InGame;
        }

        public static void EndGame()
        {
            Program.Events.Clear();
            GameState = States.GameOver;
        }

        public static void NewTutorial()
        {
            Program.NewTutorial();
            GameState = States.InGame;
        }
    }

    public enum States
    {
        MainMenu,
        InGame,
        GameOver,
        Closed
    }
}
