using Game.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;

namespace Game.UserInterface
{
    public class Marker : UIComponent
    {
        public override IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            var comp = base.GetDrawableComponents().First();
            comp.Position = new Vector2f(960 / 2 - this.Width * UISystem.Choice, 350);
            comp.AbsolutePositioning = true;

            yield return comp;
        }
    }
}
