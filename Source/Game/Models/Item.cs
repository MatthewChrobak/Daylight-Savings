using Game.Graphics;
using System;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using Game.Models.Enviroment;

namespace Game.Models
{
    public abstract class Item
    {

    }

    public class LightItem : Item {
        static int i = 1;
        public LightItem(){
            Console.WriteLine("I am the " + i + " Light");
            i++;         
        }
    }

    public class Light : Position, IDrawable
    {
        private static Random rng = new Random();
        public (int X, int Y) TargetPosition;
        public int animStep = 0;
        public int waitCount = 0;

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent()
            {
                TextureName = "light.png",
                Rect = new IntRect(0, 500 * animStep, 500, 500),
                Position = new Vector2f(this.X - Tile.TILE_SIZE / 2, this.Y - Tile.TILE_SIZE / 2),
                RenderSize = new Vector2f(50, 50)
            };
        }

        public void UpdateAnim()
        {
            animStep += 1;
            if(animStep == 8)
            {
                animStep = 0;
            }
        }


        public string SurfaceName { get; set; } = "Items.png";

        public Light(float x, float y) : base(x,y){

        }
    }

    public class Potion : Position, IDrawable
    {

        public string SurfaceName { get; set; } = "potions.png";

        public Potion(float x, float y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {

            yield return new DrawableComponent()
            {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(50, 50),
                Position = new Vector2f(this.X - Tile.TILE_SIZE / 2, this.Y - Tile.TILE_SIZE / 2),
                Rect = new IntRect(0, 125, 125, 125)
            };
        }
    }

}

