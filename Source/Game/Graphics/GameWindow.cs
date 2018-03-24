using System;
using Game.Timing;
using SFML.Graphics;
using SFML.Window;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        public GameWindow() : base(new VideoMode(960, 640), "Test")
        {
            this.Closed += this.GameWindow_Closed;
            this.KeyPressed += this.ProcessKeyInputs;
            this.JoystickConnected += this.JoyConnected;
            this.JoystickMoved += this.ProcessJoyInputs;
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

            if (!IgnoreInput(e.Position))
            {
                // Testing purposes
                Console.WriteLine($"{e.ToString()}");

                if(e.Axis == Joystick.Axis.X){
                    if (e.Position < -25.0f) // Move to the left
                    {
                        // Face Left
                    }

                    if (e.Position > 25.0f) // Move to the right
                    {
                        // Face right
                    }
                }
                if(e.Axis == Joystick.Axis.Y){
                    if(e.Position < - 25.0f ){ // Move up
                        // Face up
                    }
                    if(e. Position > 25.0f){ // Move down
                        // Face down
                    }
                }
            }



            return;
        }


        // Helper function to ignore inputs if the value is too low.
        private Boolean IgnoreInput(float value){
            return Math.Abs(value) < 20.0f;
        }
    }
}
