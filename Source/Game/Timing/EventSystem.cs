using System.Collections.Generic;

namespace Game.Timing
{
    public class EventSystem
    {
        public List<Event> GameEvents { private set; get; } = new List<Event>();

        public void GameLoop()
        {
            // While the game is running.
            while (true) {
                foreach (var @event in GameEvents) {
                    @event.Probe();
                }
            }
        }
    }
}
