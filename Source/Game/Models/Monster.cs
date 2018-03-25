using Game.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;
using SFML.Graphics;
using System.Threading.Tasks;
using Game.Models.Enviroment;

namespace Game.Models
{
    public abstract class Monster
    {
        
    }


    public class Smushy: Position, IDrawable
    {
        private static Random rnd = new Random();
        public (int X, int Y) TargetPosition;
        public int animationStep = 0;
        public int waitCount = 0;

        public Smushy(float x, float y) : base(x, y) {
            this.animationStep = 0;
            this.GetNewPos();
        }

        public void SmushyDamage(float x, float y) {
            int range = 20;

            for (int i = 0; i < Game.Program.map.smushy.Count; i++) {

                if ((Game.Program.map.smushy[i].X + range) >= x && x >= (Game.Program.map.smushy[i].X - range)
                    && (Game.Program.map.smushy[i].Y + range) >= y && y >= (Game.Program.map.smushy[i].Y - range)) {
                    Game.Program.map.Girl.health -= (float)0.01;
                    Program.map.Girl.flagForHitCounter = 1;
                }
            }
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents() {

            yield return new DrawableComponent() {
                TextureName = "smushy.png",
                RenderSize = new Vector2f(25, 50),
                Position = new Vector2f(this.X - 11, this.Y - 37),
                Rect = new IntRect(22 * animationStep, 0, 22, 43)
            };
        }

        public void GetNewPos() {
            TargetPosition.X = rnd.Next(0, Program.map.MAX_X * Tile.TILE_SIZE);
            TargetPosition.Y = rnd.Next(0, Program.map.MAX_Y * Tile.TILE_SIZE);
        }

        public void UpdateAnimation() {
            animationStep += 1;
            animationStep %= 8;
        }

        public void UpdatePosition() {
            {
                float moveSpeed = 1.0f;

                if (this.X >= TargetPosition.X && this.X <= TargetPosition.X + Tile.TILE_SIZE) {
                    if (this.Y >= TargetPosition.Y && this.Y <= TargetPosition.Y + Tile.TILE_SIZE) {
                        waitCount += 1;

                        // Did we wait long enough?
                        if (waitCount >= 100) {
                            this.GetNewPos();
                            waitCount = 0;
                        }
                    }
                }

                if (this.X < TargetPosition.X) {
                    this.X += moveSpeed;
                }
                else if (this.X > TargetPosition.X) {
                    this.X -= moveSpeed;
                }
                if (this.Y < TargetPosition.Y) {
                    this.Y += moveSpeed;
                }
                else if (this.Y > TargetPosition.Y) {
                    this.Y -= moveSpeed;
                }
            }
        }
    }
}
