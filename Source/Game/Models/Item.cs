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

    public class Light : Position, IDrawable
    {

        public string SurfaceName { get; set; } = "Items.png";

        public Light(float x, float y) : base(x,y){

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents() {

            yield return new DrawableComponent() {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(50, 50),
                Position = new Vector2f(this.X - Tile.TILE_SIZE / 2, this.Y - Tile.TILE_SIZE / 2),
                Rect = new IntRect(96, 80, 16, 16)
            };
        }
    }
}

