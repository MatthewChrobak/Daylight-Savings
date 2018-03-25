using Game.Graphics;
using Game.Models.Enviroment;
using Game.Sounds;
using Game.Timing;
using Game.UserInterface;
using System;

namespace Game
{
    public static class Program
    {
        public static UISystem UI { get; set; } = new UISystem();
        public static Map map = new Map();

        private static void Main(string[] args)
        {

            void updateFog()
            {
                for (int i = 0; i < map.FogEntities.Count; i++)
                {
                    Console.Write(map.FogEntities[i].X);
                    if (map.FogEntities[i].X == map.Girl.X)
                    {
                        map.DeleteFog(i);

                    }
                }
            }

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


            events.GameEvents.Add(new Event(updateFog, 8));

            MusicManager.addMusic("Theme.ogg", true);

            events.GameLoop();
        }
    }
}
