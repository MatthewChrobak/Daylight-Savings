using System.Collections.Generic;
using System;
using Game.Models;
using Game.Models.Enviroment;

namespace Game.Timing
{
    public class EventSystem
    {
        public static Random rnd = new Random();
        public List<Event> GameEvents { private set; get; } = new List<Event>();

        public EventSystem()
        {
            GameEvents.Add(new Event(() => Program.map.Girl.Move(), 8, true));
            GameEvents.Add(new Event(() => {
                Program.Graphics.BeginRenderFrame();

                if (StateSystem.GameState == States.InGame) {
                    Program.Graphics.RenderToFrame(Program.map.GetDrawableComponents());
                }

                Program.Graphics.RenderToFrame(Program.UI.GetDrawableComponents());
                Program.Graphics.EndRenderFrame();
            }, 16, false));

            GameEvents.Add(new Event(Program.map.UpdateBigBossAnimations, 50, true));
            GameEvents.Add(new Event(Program.map.TimerIncrementor, 1, true));
            GameEvents.Add(new Event(Program.map.UpdateFogPositions, 8, true));
            GameEvents.Add(new Event(Program.map.UpdateFogAnimations, 250, true));
            GameEvents.Add(new Event(Program.map.UpdateSmushyAnimations, 100, true));
            GameEvents.Add(new Event(Program.map.UpdateSmushyPositions, 1, true));
            GameEvents.Add(new Event(Program.map.SmushySpawning, 1000 * 12, true));
            GameEvents.Add(new Event(Program.map.LightSpawning, 1000 * 15, true));
            GameEvents.Add(new Event(Program.map.CloudSpawning, 1000 * 15, true));
            GameEvents.Add(new Event(Program.map.ItemSpawning, 1000 * 60, true));
            GameEvents.Add(new Event(Program.map.UpdateGirlAnimations, 100, true));
            GameEvents.Add(new Event(Program.map.UpdateLightAnimations, 125, true));
            GameEvents.Add(new Event(Program.map.UpdateFog, 8, true));
            GameEvents.Add(new Event(Program.map.Girl.HealthLossFromFog, 100, true));
           
        }

        public void GameLoop()
        {
            // While the game is running.
            while (StateSystem.GameState != States.Closed) {
                foreach (var @event in GameEvents) {
                    @event.Probe();
                }
                System.Threading.Thread.Yield();
            }
        }

        public void Clear()
        {
            this.GameEvents.Clear();
        }
    }
}
