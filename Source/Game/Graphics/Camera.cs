using Game.Models;
using SFML.Graphics;
using SFML.System;

namespace Game.Graphics
{
    public class Camera : View, IObserver
    {
        private GameWindow windowCopy;

        public Camera(GameWindow window) : base(new Vector2f(960/2, 640/2), new Vector2f(960, 640))
        {
            this.windowCopy = window;
        }

        public void Notify(Observable obj)
        {
            var position = obj as Position;

            if (position != null) {
                var diffx = position.X - this.Center.X;
                var diffy = position.Y - this.Center.Y;
                this.Move(new Vector2f(diffx, diffy));

                windowCopy.SetView(this);
            }
        }
    }
}
