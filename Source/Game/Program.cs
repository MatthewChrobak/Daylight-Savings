using Game.Graphics;
using Game.Models.Enviroment;
using Game.Timing;
using Game.UserInterface;

namespace Game
{
    public static class Program
    {
        public static Map Map { get; set; }
        public static UISystem UI { get; set; } = new UISystem();

        private static void Main(string[] args)
        {
            Map = new Map();
            var graphics = new GraphicsSystem();
            var events = new EventSystem();

            events.GameEvents.Add(new Event(() => {
                graphics.BeginRenderFrame();

                if (StateSystem.GameState == States.InGame) {
                    graphics.RenderToFrame(Map.GetDrawableComponents());
                }

                graphics.RenderToFrame(UI.GetDrawableComponents());
                graphics.EndRenderFrame();
            }, 16));

            events.GameLoop();
        }
    }
}
