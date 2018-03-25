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

        private static void Main(string[] args)
        {
            Map map = new Map();
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
            events.GameEvents.Add(new Event(map.UpdateFogAnimations, 250));
            events.GameEvents.Add(new Event(map.UpdateGirlAnimations, 100));
            
            MusicManager.addMusic("Theme.ogg", true);

            events.GameLoop();
        }
    }
}
