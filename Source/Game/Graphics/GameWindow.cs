using System;
using SFML.Graphics;
using SFML.Window;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        public GameWindow() : base(new VideoMode(960, 640), "Test")
        {

        }
    }
}
