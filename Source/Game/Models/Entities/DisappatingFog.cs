using Game.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models.Entities
{
    public class DisappatingFog : Fog, IDrawable
    {
        public DisappatingFog(float xPosition, float yPosition) : base(xPosition, yPosition)
        {
            this.animStep = 0;
        }

        public new IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            var baseComponent = base.GetDrawableComponents().First();
            baseComponent.TextureName = "fog-d.png";
            yield return baseComponent;
        }
    }
}
