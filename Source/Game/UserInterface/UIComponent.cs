using System;
using System.Collections.Generic;
using Game.Graphics;

namespace Game.UserInterface
{
    public class UIComponent : IDrawable
    {
        public string SurfaceName { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Action<float, float> Click { get; set; }
        public Action<string> OnControllerButton { get; set; }

        public virtual IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                Position = new SFML.System.Vector2f(X, Y),
                TextureName = SurfaceName,
                RenderSize = new SFML.System.Vector2f(Width, Height)
            };
        }
    }
}
