using System.Collections.Generic;
using Game.Graphics;
using SFML.Graphics;
using SFML.System;

namespace Game.Models
{
    public class LittleGirl : Position, IDrawable
    {
        public Vector2f velocity { get; set; }
        public int health { get; set; }
        public Inventory littleGirlInventory;
        public string SurfaceName { get; set; } = "girl.png";
        public Direction girlDirection;

        // Constructor for the Little Girl, setting her position
        public LittleGirl(int x, int y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent()
            {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(70, 104),
                Position = new Vector2f(this.X - 35, this.Y - 100),
                Rect = new IntRect(0, 0, 513, 738)
            };
        }


        // Function to move the position of littlegirl
        public void setVelocity(float x, float y){
            this.velocity = new Vector2f(x, y);
        }

        public void Move(){
            this.X += velocity.X;
            this.Y += velocity.Y;
        }
    }
}


