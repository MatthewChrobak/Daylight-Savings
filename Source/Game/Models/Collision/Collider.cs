using System;
using SFML.System;
using Game.Graphics;
using System.Collections.Generic;

namespace Game.Models.Collision
{
    public class Collider : Position, IDrawable
    {
        private Vector2f _center { get; set; }
        private float _radius { get; set; }

        public Collider(Vector2f center, float radius) : base(center.X, center.Y)
        {
            this._center = center;
            this._radius = radius;
        }

        public bool CollidedWith(Collider col, float push){
            Vector2f objectCenter = new Vector2f(this.X, this.Y);
            Console.WriteLine(objectCenter);
            Vector2f colCenter = new Vector2f(col.X, col.Y);
            Vector2f delta = colCenter - objectCenter;
            float distance = this._radius + col._radius;
            // If Magnitude of vector delta is smaller than distance, then they have collided.
            Console.WriteLine(MagnitudeOfVector(delta));
            Console.WriteLine(distance);


            if(push > 0.0f && MagnitudeOfVector(delta) < distance){
                float unitvectorX = (objectCenter.X - colCenter.X) / (float)MagnitudeOfVector(objectCenter - colCenter);
                float unitvectorY = (objectCenter.Y - colCenter.Y) / (float)MagnitudeOfVector(objectCenter - colCenter);

                Vector2f unitVector = new Vector2f(unitvectorX, unitvectorY);
                this.X = col.X + unitvectorX * (col._radius + this._radius + 1.0f);
                this.Y = col.Y + unitvectorY * (col._radius + this._radius + 1.0f);
            }
            return (MagnitudeOfVector(delta) < distance);

        }
        public double MagnitudeOfVector(Vector2f vect){
            return  Math.Sqrt(vect.X * vect.X + vect.Y * vect.Y);
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent()
            {
                TextureName = "pos.png",
                Position = new Vector2f(this.X, this.Y),
            };
        }
    }
}
