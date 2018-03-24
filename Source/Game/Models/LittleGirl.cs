using System.Collections.Generic;
using Game.Graphics;
using SFML.System;

namespace Game.Models
{
    public class LittleGirl : Position, IDrawable
    {
        // Direction the little girl is facing
        enum direction
        {
            LEFT, RIGHT, UP, DOWN
        };


        // Constructor for the Little Girl, setting her position
        public LittleGirl(int x, int y) : base(x, y)
        {

        }


        public int health { get; set; }
        public Inventory littleGirlInventory;

        //public string SurfaceName { get; set; } = "grass.png";

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent()
            {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(16, 16),
                Position = new Vector2f(this.X, this.Y)
            };
        }

        IEnumerable<DrawableComponent> IDrawable.GetDrawableComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}


