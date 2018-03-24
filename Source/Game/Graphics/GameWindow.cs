using System;
using Game.Timing;
using Game.Models;
using Game.Models.Enviroment;
using SFML.Graphics;
using SFML.Window;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        private float bound = 15.0f;
        private LittleGirl girl;

        private float speed = 2.0f;
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
            this.MouseButtonPressed += GameWindow_MouseButtonPressed;

            this.girl = map.Girl;
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

            Console.WriteLine("this is X: " + x);
            Console.WriteLine("this is Y: " + y);
        }

        private void GameWindow_KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Up)
            {
                Console.WriteLine("Up is pressed");
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                Console.WriteLine("Down is pressed");
            }
            else if (e.Code == Keyboard.Key.Left)
            {
                Console.WriteLine("Left is pressed");
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                Console.WriteLine("Right is pressed");
            } 
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {
            StateSystem.GameState = States.Closed;
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
            girl.setVelocity(moveX, moveY);
        }
    }
}
