using Game.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;
using SFML.Graphics;
using System.Threading.Tasks;
using Game.Models.Enviroment;

namespace Game.Models
{
    public abstract class Monster
    {
        
    }

    public class Smoshy: Position, IDrawable
    {
        public string SurfaceName { get; set; } = "";

        public Smoshy(float x, float y) : base(x, y) {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents() {

            yield return new DrawableComponent() {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(50, 50),
                Position = new Vector2f(this.X - Tile.TILE_SIZE / 2, this.Y - Tile.TILE_SIZE / 2),
                Rect = new IntRect()
            };
        }
    }

    public class Goblin : Monster
    {

    }

    public class Zombie : Monster
    {

    }
}
