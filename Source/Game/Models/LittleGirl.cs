using System.Collections.Generic;
using Game.Graphics;
using SFML.Graphics;
using SFML.System;
using Game.Models.Collision;
using Game.Models.Enviroment;
using System;
using Game.Sounds;
using Game.Timing;
namespace Game.Models
{
    public class LittleGirl : Position, IDrawable
    {

        public const float MaxHealth = 10;

        public Vector2f velocity { get; set; }
        public float health { get; set; } = MaxHealth;
        public Inventory littleGirlInventory = new Inventory();
        public string SurfaceName { get; set; } = "girl.png";
        public Direction girlDirection;

        public int animStep = 0;
        public bool halfStep = false;
        public int flagForHitCounter = 0;

        // Constructor for the Little Girl, setting her position
        public LittleGirl(int x, int y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            var comp = new DrawableComponent()
            {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(70, 104),
                Position = new Vector2f(this.X - 35, this.Y - 100),
                Rect = new IntRect(513 * (int)girlDirection, 800 * animStep, 513, 800)
            };

            if (this.flagForHitCounter > 0) {

                if (this.flagForHitCounter < 5) {
                    comp.Color = Color.Red;
                } else {
                    if (this.flagForHitCounter % 10 < 5) {
                        comp.Color = new Color(50, 255, 255);
                    }
                }
                
                this.flagForHitCounter += 1;
                this.flagForHitCounter %= 75;
            }

            yield return comp;
        }


        // Function to move the position of littlegirl
        public void setVelocity(float x, float y)
        {
            this.velocity = new Vector2f(x, y);
        }

        public void Move()
        {
            foreach (var smushy in Program.map.smushy) {
                smushy.SmushyDamage(this.X, this.Y);
            }

            //Check 0 boundaries
            if (this.Y + velocity.Y < 0)
            {
                setVelocity(velocity.X, 0);
            }
            if (this.X + velocity.X < 0)
            {
                setVelocity(0, velocity.Y);
            }


            //check max boundaries
            if (this.Y + velocity.Y >= Program.map.MAX_Y * Tile.TILE_SIZE)
            {
                setVelocity(velocity.X, 0);
            }
            if (this.X + velocity.X >= Program.map.MAX_X * Tile.TILE_SIZE)
            {
                setVelocity(0, velocity.Y);
            }

            this.girlDirection = Direction.DOWN;

            if (Math.Abs(velocity.Y) > Math.Abs(velocity.X))
            {
                if (velocity.Y > 0)
                {
                    girlDirection = Direction.DOWN;
                }
                else if (velocity.Y < 0)
                {
                    girlDirection = Direction.UP;
                }
            }

            if (Math.Abs(velocity.X) > Math.Abs(velocity.Y))
            {
                if (velocity.X > 0)
                {
                    girlDirection = Direction.RIGHT;
                }
                else if (velocity.X < 0)
                {
                    girlDirection = Direction.LEFT;
                }
            }



            float nextX = this.X + velocity.X;
            float nextY = this.Y + velocity.Y;
            float range = 10;

            foreach (var tree in Program.map.Trees)
            {
                if (tree.InRange(nextX - range, nextY - range, nextX + range, nextY + range))
                {
                    return;
                }
            }

            this.X = nextX;
            this.Y = nextY;
        }

        public void BringBackToLife_Tutorial()
        {
            if (Program.map.Girl.health < 0) {
                Program.map.Girl.health = LittleGirl.MaxHealth;
            }
        }

        public void HealthLossFromFog()
        {
            if (Program.map.Girl.flagForHitCounter != 0) {
                return;
            }
            for (int i = 0; i < Program.map.FogEntities.Count; i++)
            {
                if (Program.map.FogEntities[i].X <= (Program.map.Girl.X + 125) && Program.map.FogEntities[i].X >= (Program.map.Girl.X - 125) 
                    && Program.map.FogEntities[i].Y <= (Program.map.Girl.Y + 62) && Program.map.FogEntities[i].Y >= (Program.map.Girl.Y - 62))
                {
                    Program.map.Girl.health -= 1;
                    Program.map.Girl.flagForHitCounter = 1;
                    return;
                }
            }
        }

        public void CheckHealth()
        {
            if (Program.map.Girl.health <= 0)
            {
                StateSystem.EndGame();
            }
        }

        public void UpdateAnimation()
        {
            if (this.velocity.X == 0 && this.velocity.Y == 0)
            {
                this.animStep = 0;
                return;
            }

            if (Math.Abs(this.velocity.X) < 1.5f && Math.Abs(this.velocity.Y) < 1.5f)
            {
                if (!this.halfStep)
                {
                    this.halfStep = true;
                    return;
                }
                else
                {
                    this.halfStep = false;
                }
            }

            this.animStep += 1;
            this.animStep %= 8;

            if (this.animStep % 4 == 1)
            {
                SoundManager.addSound("footstep.ogg");
            }

            this.itemSurroundingCheck();
        }

        public void itemSurroundingCheck()
        {

            int range = 30;

            for (int i = 0; i < Game.Program.map.light.Count; i++)
            {

                if ((Game.Program.map.light[i].X + range) >= this.X && this.X >= (Game.Program.map.light[i].X - range)
                    && (Game.Program.map.light[i].Y + range) >= this.Y && this.Y >= (Game.Program.map.light[i].Y - range))
                {
                    Program.map.Girl.littleGirlInventory.items.Add(new LightItem());
                    Program.map.light.RemoveAt(i);
                    SoundManager.addSound("chime.ogg");
                }
            }

            for (int i = 0; i < Game.Program.map.potion.Count; i++)
            {
                if (Program.map.potion[i].X <= (Program.map.Girl.X + range) && Program.map.potion[i].X >= (Program.map.Girl.X - range)
                    && Program.map.potion[i].Y <= (Program.map.Girl.Y + range) && Program.map.potion[i].Y >= (Program.map.Girl.Y - range))
                {
                    if (Program.map.Girl.health < MaxHealth)
                    {
                        Program.map.Girl.health += 1;
                        Program.map.potion.RemoveAt(i);
                    }
                }
            }
        }
    }
}


