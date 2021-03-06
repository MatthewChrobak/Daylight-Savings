﻿namespace Game.Models
{
    public abstract class Position : Observable
    {
        private float _x;
        private float _y;

        public float X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
                this.NotifyAll();
            }
        }
        public float Y
        {

            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
                this.NotifyAll();
            }
        }

        public Position(){
            X = 0;
            Y = 0;
        }

        public Position(float xPosition, float yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }

        public bool InRange(float xLb, float yLb, float xUb, float yUb)
        {
            return (xLb <= this.X && this.X <= xUb) && (yLb <= this.Y && this.Y <= yUb);
        }
    }
}
