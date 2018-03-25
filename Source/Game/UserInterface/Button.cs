using System.Collections.Generic;
using Game.Graphics;

namespace Game.UserInterface
{
    public class Button : UIComponent
    {
        public string ButtonText = "";

        public override IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                RenderText = ButtonText,
                Position = new SFML.System.Vector2f(this.X, this.Y),
                AbsolutePositioning = true
            };

            foreach (var component in base.GetDrawableComponents()) {
                yield return component;
            }
        }
    }
}
