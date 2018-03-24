namespace Game.Timing
{
    public static class StateSystem
    {
        public static States GameState { get; set; }
    }

    public enum States
    {
        Running,
        Closed
    }
}
