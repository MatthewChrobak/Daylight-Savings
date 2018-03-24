using SFML.Graphics;
using SFML.System;

namespace Game.Graphics
{
    public class Camera : View
    {
        public Camera() : base(new Vector2f(960/2, 640/2), new Vector2f(960, 640))
        {

        }
    }
}
