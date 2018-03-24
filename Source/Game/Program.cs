using Game.Graphics;
using Game.Models.Enviroment;
using Game.Timing;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();
            var graphics = new GraphicsSystem(map);
            var events = new EventSystem();

            events.GameEvents.Add(new Event(() => graphics.RenderFrame(map.GetDrawableComponents()), 16));

            events.GameLoop();
        }
    }
}
