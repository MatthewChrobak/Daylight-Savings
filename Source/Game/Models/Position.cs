namespace Game.Models
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
        public Position(float xPosition, float yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }
    }
}
