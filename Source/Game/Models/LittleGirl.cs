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
        public Inventory littleGirlInventory = new Inventory();
        public string SurfaceName { get; set; } = "girl.png";
        public Direction girlDirection;

        public int animStep = 0;
        public bool halfStep = false;

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
                Rect = new IntRect(513 * (int)girlDirection, 738 * animStep, 513, 738)
            };
        }


        // Function to move the position of littlegirl
        public void setVelocity(float x, float y){
            this.velocity = new Vector2f(x, y);
        }

        public void Move() {

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




            this.girlDirection = Direction.DOWN;

            if (Math.Abs(velocity.Y) < Math.Abs(velocity.X)) {
                if (velocity.Y > 0) {
                    girlDirection = Direction.DOWN;
                } else if (velocity.Y < 0) {

                } else {

                }
            }

            if (Math.Abs(velocity.X) > Math.Abs(velocity.Y)) {
                if (velocity.X > 0) {
                    girlDirection = Direction.RIGHT;
                } else if (velocity.X < 0) {
                    girlDirection = Direction.LEFT;
                }
            }
        }
        public void UpdateAnimation()
        {
            if (this.velocity.X == 0 && this.velocity.Y == 0) {
                this.animStep = 0;
                return;
            }
            
            if (Math.Abs(this.velocity.X) < 1.5f && Math.Abs(this.velocity.Y) < 1.5f) {
                if (!this.halfStep) {
                    this.halfStep = true;
                    return;
                } else {
                    this.halfStep = false;
                }
            }

            this.animStep += 1;
            this.animStep %= 8;

            this.itemSurroundingCheck();
        }

        public void itemSurroundingCheck() {

            int range = 30;

            for (int i = 0; i < Game.Program.map.light.Count; i++) {

                if ((Game.Program.map.light[i].X + range >= this.X && this.X >= Game.Program.map.light[i].X - range) 
                    && (Game.Program.map.light[i].Y + range >= this.Y && this.Y >= Game.Program.map.light[i].Y - range)) {
                    Program.map.Girl.littleGirlInventory.items.Add(new LightItem());
                    Program.map.light.RemoveAt(i);
                }
            }
                /*
                 * debugging purpose
                 * Console.WriteLine("X is: " + i.X + " Y is: " + i.Y); 
                 */
   
        }
    }
}


