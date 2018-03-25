using Game.Graphics;
using Game.Models.Enviroment;
using SFML.System;
using System.Collections.Generic;

namespace Game.UserInterface
{
    public class CloudsRemaining : UIComponent
    {
        public override IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = "shadowbox.png",
                Position = new Vector2f(960 - (this.Width), 0),
                AbsolutePositioning = true,
                RenderSize = new Vector2f(this.Width, this.Height)
            };

            yield return new DrawableComponent() {
                RenderText = "Clouds Left: " + System.Math.Max(Program.map.winningCondition - Program.map.numOfCloud, 0),
                Position = new Vector2f(960 - this.Width, 25),
                AbsolutePositioning = true,
                CharacterSize = 14
            };
        }
    }
}
