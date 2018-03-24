using System;
using Game.Models;
using Game.Models.Enviroment;
using Game.Timing;
using Game.Models;
using Game.Models.Enviroment;
using SFML.Graphics;
using SFML.Window;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        private LittleGirl girl;

        private float speed = 1.0f;


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

            Console.WriteLine("this is X: " + x);
            Console.WriteLine("this is Y: " + y);
        }

        private void GameWindow_KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Up)
            {
                Console.WriteLine("Up is pressed");
                this.girl.girlDirection = Direction.UP;
                this.girl.Y -= 25;
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                Console.WriteLine("Down is pressed");
                this.girl.girlDirection = Direction.DOWN;
                this.girl.Y += 25;
            }
            else if (e.Code == Keyboard.Key.Left)
            {
                Console.WriteLine("Left is pressed");
                this.girl.girlDirection = Direction.LEFT;
                this.girl.X -= 25;
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                Console.WriteLine("Right is pressed");
                this.girl.girlDirection = Direction.RIGHT;
                this.girl.X += 25;
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

            float moveX = 0.0f, moveY = 0.0f;


            if (!IgnoreInput(e.Position))
            {
                // Testing purposes
                //Console.WriteLine($"{e.ToString()}");
                if (e.Axis == Joystick.Axis.X)
                {
                    if (e.Position < -25.0f) // Move to the left
                    {
                        Console.WriteLine("Move Left");
                        moveX -= speed;
                    }

                    if (e.Position > 25.0f) // Move to the right
                    {
                        Console.WriteLine("Move Right");
                        // Face right
                        moveX += speed;
                    }
                }
                if (e.Axis == Joystick.Axis.Y)
                {
                    if (e.Position < -25.0f)
                    { // Move up
                        Console.WriteLine("Move Up");
                        // Face up
                        moveY -= speed;
                    }
                    if (e.Position > 25.0f)
                    { // Move down
                        Console.WriteLine("Move Down");
                        // Face down
                        moveY += speed;
                    }
                }
            }
            girl.setVelocity(moveX, moveY);
            
        }


        // Helper function to ignore inputs if the value is too low.
        private bool IgnoreInput(float value){
            
            return Math.Abs(value) < 20.0f;

        }
    }
}
