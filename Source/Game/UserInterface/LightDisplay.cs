using System.Collections.Generic;
using System.Linq;
using Game.Graphics;
using Game.Models;
using SFML.System;

namespace Game.UserInterface
{
    public class LightDisplay : UIComponent, IDrawable
    {
        public override IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = "BorderBox.png",
                Position = new Vector2f(15, 50),
                AbsolutePositioning = true,
                RenderSize = new Vector2f(100, 50)
            };

            yield return new DrawableComponent() {
                RenderText = ": " + Program.map.Girl.littleGirlInventory.items.Count(item => item as LightItem != null),
                Position = new Vector2f(65, 57),
                AbsolutePositioning = true,
                CharacterSize = 26
            };
        }
    }
}
