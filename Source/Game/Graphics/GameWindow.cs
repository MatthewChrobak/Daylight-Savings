using Game.Models;
using Game.Models.Enviroment;
using Game.Timing;
using SFML.Graphics;
using SFML.Window;
using System;
using Game.Sounds;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        private float bound = 15.0f;

        private float speed = 4.0f;

        private float moveX;
        private float moveY;


        public GameWindow() : base(new VideoMode(1200, 900), "Daylight Savings", Styles.Fullscreen)
        {
            this.Closed += this.GameWindow_Closed;
            this.KeyPressed += this.ProcessKeyInputs;
            this.JoystickConnected += this.JoyConnected;
            this.JoystickMoved += this.ProcessJoyInputs;
            this.JoystickButtonPressed += this.GameWindow_JoystickButtonPressed;
            this.KeyPressed += GameWindow_KeyPressed;
            this.MouseMoved += GameWindow_MouseMoved;
            this.MouseButtonPressed += this.GameWindow_MouseButtonPressed1;
            this.MouseButtonPressed += GameWindow_MouseButtonPressed;
        }

        private void GameWindow_JoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {
            Program.UI.OnControllerButton(e.Button.ToString());

            if (e.Button == 6) {
                StateSystem.TryClose();
            }
        }

        private void GameWindow_MouseButtonPressed1(object sender, MouseButtonEventArgs e)
        {
            //Program.UI.OnClick(e.X, e.Y);
        }

        private void GameWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            var ButtonClick = e.Button;
        }

        private void GameWindow_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
        }

        private void GameWindow_KeyPressed(object sender, KeyEventArgs e)
        {
            return;
            Game.Program.map.Girl.itemSurroundingCheck();
            if (e.Code == Keyboard.Key.Up)
            {
                Program.map.Girl.girlDirection = Direction.UP;
                if(((Program.map.Girl.Y-25) <= 0)) {
                    Program.map.Girl.Y = 0;
                }
                else {
                    Program.map.Girl.Y -= 25;
                }
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                Program.map.Girl.girlDirection = Direction.DOWN;
                if (!((Program.map.Girl.Y + 25) >= Program.map.MAX_Y*Tile.TILE_SIZE)) {
                    Program.map.Girl.Y += 25;
                }
            }
            else if (e.Code == Keyboard.Key.Left)
            {
                Program.map.Girl.girlDirection = Direction.LEFT;
                if (((Program.map.Girl.X - 25) <= 0)) {
                    Program.map.Girl.X = 0;
                }
                else {
                    Program.map.Girl.X -= 25;
                }
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                Program.map.Girl.girlDirection = Direction.RIGHT;
                if (!((Program.map.Girl.X + 25) >= Program.map.MAX_X*Tile.TILE_SIZE)) {
                    Program.map.Girl.X += 25;
                }
            }
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {
            StateSystem.TryClose();
        }

        // Method to process inputs from keyboard
        private void ProcessKeyInputs(object sender, KeyEventArgs e){

            Window window = sender as Window;

            if (window != null)
            {
                if (e.Code == Keyboard.Key.Escape)
                    StateSystem.TryClose();
            }

        }

        // Method to detect if joystick is connected
        private void JoyConnected(object sender, JoystickConnectEventArgs e){

        }

        // Method to process the inputs from the joystick
        private void ProcessJoyInputs(object sender, JoystickMoveEventArgs e){
            if (StateSystem.GameState != States.InGame) {
                return;
            }

            if (e.Axis == Joystick.Axis.X)
            {
                if(Math.Abs(e.Position) > bound){
                    moveX = speed * (e.Position / 100);
                }
                else{
                    moveX = 0.0f;
                }
            }
            if (e.Axis == Joystick.Axis.Y)
            {
                if (Math.Abs(e.Position) > bound){
                    moveY = speed * (e.Position / 100);                   
                }
                else{
                    moveY = 0.0f;
                }
            }
            Program.map.Girl.setVelocity(moveX, moveY);
        }
    }
}
