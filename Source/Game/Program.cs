using Game.Graphics;
using Game.Timing;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphics = new GraphicsSystem();
            var events = new EventSystem();

            events.GameEvents.Add(new Event(graphics.Render, 16));


            events.GameLoop();
        }
    }
}
