using Game.Graphics;
using System.Collections.Generic;

namespace Game.Models.Enviroment
{
    public class Tile : IDrawable
    {
        public string SurfaceName { get; set; } = "grass.png";

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = this.SurfaceName
            };
        }
    }
}
