namespace Game.Models
{
    public abstract class Position : Observable
    {
        public float X
        {
            get
            {
                return this.X;
            }
            set
            {
                this.X = value;
                this.NotifyAll();
            }
        }
        public float Y
        {

            get
            {
                return this.Y;
            }
            set
            {
                this.Y = value;
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
