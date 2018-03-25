namespace Game.Timing
{
    public static class StateSystem
    {
        public static States GameState { get; private set; }

        public static void TryClose()
        {
            Program.Events.Clear();
            if (GameState == States.InGame || GameState == States.GameOver || GameState == States.Win) {
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

        public static void WinGame()
        {
            Program.Events.Clear();
            GameState = States.Win;
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
        Win,
        Closed
    }
}
