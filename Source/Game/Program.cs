using Game.Graphics;
using Game.Models.Enviroment;
using Game.Sounds;
using Game.Timing;
using Game.UserInterface;

namespace Game
{
    public static class Program
    {
        public static UISystem UI { get; set; } = new UISystem();
        public static Map map { get; set; } = new Map();
        private static void Main(string[] args)
        {
            var graphics = new GraphicsSystem(map);
            var events = new EventSystem();


            events.GameEvents.Add(new Event(() => map.Girl.Move(), 8));
            events.GameEvents.Add(new Event(() => {
                graphics.BeginRenderFrame();

                if (StateSystem.GameState == States.InGame) {
                    graphics.RenderToFrame(map.GetDrawableComponents());
                }

                graphics.RenderToFrame(UI.GetDrawableComponents());
                graphics.EndRenderFrame();
            }, 16));
            events.GameEvents.Add(new Event(map.UpdateFogPositions, 8));
            events.GameEvents.Add(new Event(map.UpdateFogAnim, 250));
            
            MusicManager.addMusic("Theme.ogg", true);
            map.Girl.itemSurroundingCheck();
            events.GameLoop();
        }
    }
}
