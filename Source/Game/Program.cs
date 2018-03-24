﻿using Game.Graphics;
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


            events.GameEvents.Add(new Event(() => map.Girl.Move(), 8));
            events.GameEvents.Add(new Event(() => {
                graphics.BeginRenderFrame();

                if (StateSystem.GameState == States.InGame) {
                    graphics.RenderToFrame(map.GetDrawableComponents());
                }

                graphics.RenderToFrame(UI.GetDrawableComponents());
                graphics.EndRenderFrame();
            }, 16));

            events.GameLoop();
        }
    }
}
