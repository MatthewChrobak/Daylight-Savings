﻿using Game.Graphics;
using Game.Timing;
using System.Collections.Generic;
using Game.Sounds;

namespace Game.UserInterface
{
    public class UISystem : IDrawable
    {
        public static float MouseX = 0;
        public static float MouseY = 0;

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

        public void OnMouseMove(float x, float y)
        {
            MouseX = x;
            MouseY = y;
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
            var gameUI = new List<UIComponent>();


            //HealthBar Components
            gameUI.Add(new HealthBar() {
                X = 0,
                Y = 0,
                Height = 50,
                Width = 200,
                SurfaceName = "Full_HealthBar.png"
            });

            // Mainmenu Components
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
                Click = (x, y) => StateSystem.NewGame(),
                OnControllerButton = (code) => {
                    if (code == "7") {
                        StateSystem.NewGame();
                    }
                }
            });

            this.Components[(int)States.MainMenu] = mainmenu;
            this.Components[(int)States.InGame] = gameUI;
        }
    }
}
