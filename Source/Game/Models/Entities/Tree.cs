using System.Collections.Generic;
using Game.Graphics;
using SFML.System;

namespace Game.Models.Entities
{
    public class Tree : Position, IDrawable
    {
        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                Position = new Vector2f(this.X - 50, this.Y - 190),
                TextureName = "ftree1.png",
                RenderSize = new Vector2f(100, 200)
            };
        }
    }
}
