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
            Vector2f delta = col._center - this._center;
            float distance = this._radius + col._radius;

            // If Magnitude of vector delta is smaller than distance, then they have collided.
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
