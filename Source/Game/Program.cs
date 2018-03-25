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
        public static EventSystem Events = new EventSystem();

        private static void Main(string[] args)
        {
            MusicManager.addMusic("Theme.ogg", true, 30);
            map.Girl.itemSurroundingCheck();
            Events.GameLoop();
        }

        public static void NewGame()
        {
            Program.map.Reset();
            Graphics.SetCameraFocus(Program.map.Girl);
        }
    }
}
