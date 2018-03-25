using System.Collections.Generic;
using Game.Graphics;
using SFML.System;

namespace Game.Models.Entities
{
    public class Tree : Position, IDrawable
    {
        System.Random rng = new System.Random();

        private string texture;

        public Tree()
        {
            this.texture = "ftree" + rng.Next(1, 4) + ".png";
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                Position = new Vector2f(this.X - 50, this.Y - 190),
                TextureName = this.texture,
                RenderSize = new Vector2f(100, 200)
            };
        }
    }
}
