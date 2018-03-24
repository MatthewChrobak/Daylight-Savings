using Game.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Game.Models.Enviroment
{
    public class Tile : Position, IDrawable
    {
        public string SurfaceName { get; set; } = "grass.png";

        public Tile(float x, float y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(16, 16),
                Position = new Vector2f(this.X, this.Y)
            };
        }
    }
}
