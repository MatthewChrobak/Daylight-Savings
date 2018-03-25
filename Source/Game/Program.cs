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
        public static Map map { get; set; } = new Map();
        public static GraphicsSystem Graphics = new GraphicsSystem();
        public static EventSystem Events;

        private static void Main(string[] args)
        {
            Events = new EventSystem();
            MusicManager.addMusic("Theme.ogg", true, 30);
            Events.GameLoop();
        }

        public static void NewTutorial()
        {
            if (Program.map.Girl != null) {
                Graphics.RemoveCameraFocus();
            }
            Program.map = new TutorialMap();
            
            Program.map.Reset();
            Events.AddTutorialEvents();
            Graphics.SetCameraFocus(Program.map.Girl);
        }

        public static void NewGame()
        {
            if (Program.map.Girl != null) {
                Graphics.RemoveCameraFocus();
            }
            Program.map = new Map();

            Program.map.Reset();
            Events.AddGameEvents();
            Graphics.SetCameraFocus(Program.map.Girl);
        }
    }
}
