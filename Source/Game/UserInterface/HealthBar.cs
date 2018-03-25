using Game.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Game.UserInterface {
    class HealthBar:UIComponent, IDrawable {

        public override IEnumerable<DrawableComponent> GetDrawableComponents() {

            // Background
            yield return new DrawableComponent() {
                TextureName = "0_3_HealthBar.png",
                AbsolutePositioning = true,
                Position = new Vector2f(this.X, this.Y),
                RenderSize = new Vector2f(this.Width, this.Height),
            };

            var healthPercentage = Program.map.Girl.health / Game.Program.map.Girl.health;

            // Foreground
            yield return new DrawableComponent() {
                TextureName = "Full_HealthBar.png",
                AbsolutePositioning = true,
                Position = new Vector2f(this.X, this.Y),
                RenderSize = new Vector2f(this.Width * healthPercentage, this.Height),
                Rect = new IntRect(0, 0, (int)(321 * healthPercentage), 76)
            };
        }

    }
}
