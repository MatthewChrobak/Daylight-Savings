using System.Collections.Generic;
using Game.Graphics;
using SFML.Graphics;
using SFML.System;
using Game.Models.Enviroment;
using System;

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
                Position = new Vector2f(this.X, this.Y),
                Rect = new IntRect(0, 0, 513, 738)
            };


        }


        // Function to move the position of littlegirl
        public void setVelocity(float x, float y){
            this.velocity = new Vector2f(x, y);
        }

        public void Move() {

            // this.X += velocity.X;
            // this.Y += velocity.Y;

            //Check 0 boundaries
            if (this.Y + velocity.Y < 0) {
                setVelocity(velocity.X, 0);
            }
            if (this.X + velocity.X < 0) { 
                setVelocity(0, velocity.Y);
            }
               
            
            //check max boundaries
            if(this.Y+velocity.Y >= Map.MAX_Y * Tile.TILE_SIZE) {
                setVelocity(velocity.X, 0);
            }
                if(this.X+velocity.X>= Map.MAX_X * Tile.TILE_SIZE) {
                setVelocity(0, velocity.Y);
            }

            this.X += velocity.X;
            this.Y += velocity.Y;
            Console.WriteLine("X position: " + this.X + " Y position: " + this.Y);


        }
    }
}


