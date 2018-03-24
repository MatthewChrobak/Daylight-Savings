using Game.Models;
using Game.Models.Enviroment;
using Game.Timing;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        private float bound = 30.0f;
        private LittleGirl girl;

        private float speed = 1.0f;
        private float moveX;
        private float moveY;


        public GameWindow(Map map) : base(new VideoMode(960, 640), "Test")
        {
            this.Closed += this.GameWindow_Closed;
            this.KeyPressed += this.ProcessKeyInputs;
            this.JoystickConnected += this.JoyConnected;
            this.JoystickMoved += this.ProcessJoyInputs;
            this.KeyPressed += GameWindow_KeyPressed;
            this.MouseMoved += GameWindow_MouseMoved;
            this.MouseButtonPressed += this.GameWindow_MouseButtonPressed1;
            this.MouseButtonPressed += GameWindow_MouseButtonPressed;

            //this is the girl from MAP
            this.girl = map.Girl;
        }

        private void GameWindow_MouseButtonPressed1(object sender, MouseButtonEventArgs e)
        {
            Program.UI.OnClick(e.X, e.Y);
        }

        private void GameWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            var ButtonClick = e.Button;

            Console.WriteLine("The Button " + ButtonClick + " is clicked");
        }

        private void GameWindow_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
        }

        private void GameWindow_KeyPressed(object sender, KeyEventArgs e)
        {

            if(e.Code == Keyboard.Key.Up)
            {
                Console.WriteLine("Up is pressed");
                this.girl.girlDirection = Direction.UP;
                if(!((this.girl.Y-25) <= 0)) {
                    this.girl.Y -= 25;
                }
                Console.WriteLine(this.girl.Y);
               
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                Console.WriteLine("Down is pressed");
                this.girl.girlDirection = Direction.DOWN;
                if (!((this.girl.Y + 25) >= Map.MAX_Y*Map.TILE_SIZE)) {
                    this.girl.Y += 25;
                }
                Console.WriteLine(this.girl.Y);
            }
            else if (e.Code == Keyboard.Key.Left)
            {
                Console.WriteLine("Left is pressed");
                this.girl.girlDirection = Direction.LEFT;
                if(!((this.girl.X-25) <= 0)) {
                    this.girl.X -= 25;
                }
                Console.WriteLine(this.girl.X);
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                Console.WriteLine("Right is pressed");
                this.girl.girlDirection = Direction.RIGHT;
                if (!((this.girl.X + 25) >= Map.MAX_X*Map.TILE_SIZE)) {
                    this.girl.X += 25;
                }
                Console.WriteLine(this.girl.X);
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
                if (e.Code == Keyboard.Key.E)
                    System.Console.WriteLine("Wow");
                if (e.Code == Keyboard.Key.Escape)
                    StateSystem.GameState = States.Closed;
            }

        }

        // Method to detect if joystick is connected
        private void JoyConnected(object sender, JoystickConnectEventArgs e){
            Console.WriteLine("Joystick Connected");
        }

        // Method to process the inputs from the joystick
        private void ProcessJoyInputs(object sender, JoystickMoveEventArgs e){
            if (e.Axis == Joystick.Axis.X)
            {
                if (e.Position < -bound) // Move to the left
                {
                    moveX = -speed;
                }

                else if (e.Position > bound) // Move to the right
                {
                    // Face right
                    moveX = speed;
                }
                else{
                    moveX = 0.0f;
                }
            }
            if (e.Axis == Joystick.Axis.Y)
            {
                if (e.Position < -bound)
                { // Move up
                    // Face up
                    moveY = -speed;
                }
                else if (e.Position > bound)
                { // Move down
                    // Face down
                    moveY = speed;
                }
                else{
                    moveY = 0.0f;
                }
            }
            girl.setVelocity(moveX, moveY);
        }
    }
}
