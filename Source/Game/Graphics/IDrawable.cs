using SFML.System;
using System.Collections.Generic;

namespace Game.Graphics
{
    public interface IDrawable
    {
        IEnumerable<DrawableComponent> GetDrawableComponents();
    }

    public class DrawableComponent
    {
        public string TextureName { get; set; }
        public Vector2f RenderSize { get; set; }
    }
}
