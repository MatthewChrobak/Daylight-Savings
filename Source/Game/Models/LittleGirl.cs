using System.Collections.Generic;
using Game.Graphics;
using SFML.System;

namespace Game.Models
{
    public class LittleGirl : Position, IDrawable
    {
        public int health { get; set; }
        public Inventory littleGirlInventory;
        public string SurfaceName { get; set; } = "girl.png";

        // Constructor for the Little Girl, setting her position
        public LittleGirl(int x, int y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent()
            {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(25, 50),
                Position = new Vector2f(this.X - 12.5f, this.Y - 50)
            };
        }
    }
}


