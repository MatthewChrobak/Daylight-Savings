namespace Game.Timing
{
    public static class StateSystem
    {
        public static States GameState { get; set; }

        public static void TryClose()
        {
            if (GameState == States.InGame) {
                GameState = States.MainMenu;
            } else {
                GameState = States.Closed;
            }
        }
    }

    public enum States
    {
        MainMenu,
        InGame,
        Closed
    }
}
