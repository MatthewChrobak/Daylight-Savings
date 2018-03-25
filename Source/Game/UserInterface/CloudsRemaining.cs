using Game.Graphics;
using System.Collections.Generic;

namespace Game.UserInterface
{
    public class CloudsRemaining : UIComponent
    {
        public override IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            //yield return new DrawableComponent() {
            //    TextureName = "BorderBox.png",
            //    Position = new Vector2f(15, 50),
            //    AbsolutePositioning = true,
            //    RenderSize = new Vector2f(100, 50)
            //};

            //yield return new DrawableComponent() {
            //    RenderText = "Clouds Left: " + Program.map.Girl.littleGirlInventory.items.Count(item => item as LightItem != null),
            //    Position = new Vector2f(15, 57),
            //    AbsolutePositioning = true,
            //    CharacterSize = 26
            //};
        }
    }
}
