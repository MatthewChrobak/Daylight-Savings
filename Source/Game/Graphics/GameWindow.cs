﻿using Game.Models;
using Game.Models.Collision;
using Game.Models.Enviroment;
using Game.Timing;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Game.Graphics
{
    public class GameWindow : RenderWindow
    {
        private float bound = 15.0f;
        private LittleGirl girl;

        private float speed = 2.0f;

        private float moveX;
        private float moveY;

        private List<Collider> _allColliders;


        public GameWindow(Map map) : base(new VideoMode(960, 640), "Test")
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


            _allColliders = map._Colliders;
            //this is the girl from MAP
            this.girl = map.Girl;
        }

        private void GameWindow_JoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {
            Console.WriteLine(e.Button);
            Program.UI.OnControllerButton(e.Button.ToString());

            if (e.Button == 6) {
                StateSystem.TryClose();
            }
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
            foreach(var col in _allColliders)
            {
                if (this.girl.CollidedWith(col, 1.0f))
                {
                    return;
                }
            }
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
            foreach (var col in _allColliders)
            {
                if (this.girl.CollidedWith(col, 1.0f))
                {
                    Console.WriteLine("Collided");
                    girl.setVelocity(0.0f, 0.0f);
                    return;
                }
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
            girl.setVelocity(moveX, moveY);
        }

    }
}
