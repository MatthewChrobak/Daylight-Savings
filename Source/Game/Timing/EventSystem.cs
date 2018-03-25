using Game.Models.Enviroment;
using System;
using System.Collections.Generic;

namespace Game.Timing {
    public class EventSystem
    {
        public static Random rnd = new Random();
        public List<Event> GameEvents { private set; get; } = new List<Event>();

        public EventSystem()
        {
            this.Clear();
        }

        private void AddRegularEvents()
        {
            lock(this.GameEvents) {
                GameEvents.Add(new Event(() => {
                    Program.Graphics.BeginRenderFrame();

                    if (StateSystem.GameState == States.InGame) {
                        Program.Graphics.RenderToFrame(Program.map.GetDrawableComponents());
                    }

                    Program.Graphics.RenderToFrame(Program.UI.GetDrawableComponents());
                    Program.Graphics.EndRenderFrame();
                }, 16, false));
            }
        }

        public void AddGameEvents()
        {
            lock (GameEvents) {
                GameEvents.Add(new Event(Program.map.Girl.Move, 8, true));
                GameEvents.Add(new Event(Program.map.UpdateBigBossAnimations, 125, true));
                GameEvents.Add(new Event(Program.map.UpdateFogPositions, 8, true));
                GameEvents.Add(new Event(Program.map.UpdateFogAnimations, 250, true));
                GameEvents.Add(new Event(Program.map.UpdateSmushyAnimations, 100, true));
                GameEvents.Add(new Event(Program.map.UpdateSmushyPositions, 1, true));
                GameEvents.Add(new Event(Program.map.UpdateGirlAnimations, 100, true));
                GameEvents.Add(new Event(Program.map.UpdateLightAnimations, 125, true));
                GameEvents.Add(new Event(Program.map.UpdateFog, 8, true));
                GameEvents.Add(new Event(Program.map.Girl.HealthLossFromFog, 100, true));
                GameEvents.Add(new Event(Program.map.Girl.CheckHealth, 100, true));

            }
        }

        public void AddTutorialEvents()
        {
            lock (GameEvents) {
                GameEvents.Add(new Event(Program.map.UpdateBigBossAnimations, 125, true));
                GameEvents.Add(new Event(Program.map.Girl.Move, 8, true));
                GameEvents.Add(new Event(Program.map.UpdateFogAnimations, 250, true));
                GameEvents.Add(new Event(Program.map.UpdateSmushyAnimations, 100, true));
                GameEvents.Add(new Event(Program.map.UpdateGirlAnimations, 100, true));
                GameEvents.Add(new Event(Program.map.UpdateLightAnimations, 125, true));
                GameEvents.Add(new Event(Program.map.UpdateFog, 8, true));
                GameEvents.Add(new Event(Program.map.Girl.HealthLossFromFog, 100, true));
                GameEvents.Add(new Event(Program.map.Girl.BringBackToLife_Tutorial, 500, true));

                GameEvents.Add(new Event(((TutorialMap)Program.map).RespawnFogs, 3000, true));
                GameEvents.Add(new Event(((TutorialMap)Program.map).RespawnPotions, 3000, true));
                GameEvents.Add(new Event(((TutorialMap)Program.map).RespawnSmushy, 3000, true));
                GameEvents.Add(new Event(((TutorialMap)Program.map).RespawnLights, 3000, true));
            }
        }

        public void GameLoop()
        {
            // While the game is running.
            while (StateSystem.GameState != States.Closed) {
                lock(this.GameEvents) {
                    for (int i = 0; i < GameEvents.Count; i++) {
                        GameEvents[i].Probe();
                    }
                }

                System.Threading.Thread.Yield();
            }
        }

        public void Clear()
        {
            lock (GameEvents) {
                this.GameEvents.Clear();
                this.AddRegularEvents();
            }
        }
    }
}
