using Game.Graphics;
using Game.Timing;
using System.Collections.Generic;

namespace Game.UserInterface
{
    public class UISystem : IDrawable
    {
        public List<UIComponent>[] Components = new List<UIComponent>[(int)States.Closed + 1];

        public void OnClick(float x, float y)
        {
            foreach(var component in Components[(int)StateSystem.GameState]) {
                if (y >= component.Y && y <= component.Y + component.Height) {
                    if (x >= component.X && x <= component.X + component.Width) {
                        component.Click?.Invoke(x, y);
                    }
                }
            }
        }

        public void OnControllerButton(string button)
        {
            foreach (var component in Components[(int)StateSystem.GameState]) {
                component.OnControllerButton?.Invoke(button);
            }
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            foreach (var uicomponent in Components[(int)StateSystem.GameState]) {
                foreach (var drawable in uicomponent.GetDrawableComponents()) {
                    yield return drawable;
                }
            }
        }

        public UISystem()
        {
            for (int i = 0; i <= (int)States.Closed; i++) {
                this.Components[i] = new List<UIComponent>();
            }


            var mainmenu = new List<UIComponent>();

            mainmenu.Add(new UIComponent() {
                Height = 640,
                Width = 960,
                X = 0,
                Y = 0,
                SurfaceName = "background.png"
            });
            mainmenu.Add(new Button() {
                Height = 50,
                Width = 100,
                X = 100, 
                Y = 300,
                ButtonText = "Play game",
                SurfaceName = "shadowbox.png",
                Click = (x, y) => StateSystem.GameState = States.InGame
            });

            this.Components[(int)States.MainMenu] = mainmenu;
        }
    }
}
