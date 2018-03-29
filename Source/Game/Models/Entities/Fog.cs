using System;
using System.Collections.Generic;
using Game.Graphics;
using Game.Models.Enviroment;
using SFML.Graphics;
using SFML.System;

namespace Game.Models.Entities
{
    public class Fog : Position, IDrawable
    {
        private static Random rng = new Random();
        public (int X, int Y) TargetPosition;
        public int animStep = 0;
        public int waitCount = 0;

        public Fog(float xPosition, float yPosition) : base(xPosition, yPosition)
        {
            this.animStep = rng.Next(0, 4);
            this.GetNewPos();
        }
        
        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = "fog.png",
                Rect = new IntRect(0, 248 * animStep, 500, 248),
                Position = new Vector2f(this.X - (48 * 2), this.Y - 90),
                RenderSize = new Vector2f(48 * 4, 96)
            };
        }

        public void UpdateAnim()
        {
            animStep += 1;
            animStep %= 4;
        }

      

        private void GetNewPos()
        {
            TargetPosition.X = (rng.Next(0, Program.map.MAX_X) * Tile.TILE_SIZE);
            TargetPosition.Y = (rng.Next(0, Program.map.MAX_Y) * Tile.TILE_SIZE);
        }

        public void UpdatePosition()
        {
            float moveSpeed = 3.5f;

            if (this.X >= TargetPosition.X - moveSpeed && this.X <= TargetPosition.X + moveSpeed) {
                if (this.Y >= TargetPosition.Y - moveSpeed
                    && this.Y <= TargetPosition.Y + moveSpeed) {
                    waitCount += 1;

                    // Did we wait long enough?
                    if (waitCount >= 25) {
                        this.GetNewPos();
                        waitCount = 0;
                    } else {
                        return;
                    }
                }
            }

            if (this.X < TargetPosition.X) {
                this.X += moveSpeed;
            } else if (this.X > TargetPosition.X) {
                this.X -= moveSpeed;
            }
            if (this.Y < TargetPosition.Y) {
                this.Y += moveSpeed;
            } else if (this.Y > TargetPosition.Y) {
                this.Y -= moveSpeed;
            }
        }
    }
}
