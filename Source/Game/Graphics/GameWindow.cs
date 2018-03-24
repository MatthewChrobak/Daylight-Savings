using System;
using SFML.Graphics;
using SFML.Window;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        public GameWindow() : base(new VideoMode(960, 640), "Test")
        {
            this.Closed += this.GameWindow_Closed;
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {

        }
    }
}
