using System;
using System.Collections.Generic;
using Game.Graphics;
using Game.Models;
using Game.Models.Entities;
using SFML.System;

namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public List<Fog> FogEntities;
        public Tile[,] Tiles;
        public const int MAX_X = 30;
        public const int MAX_Y = 15;
        public const int numLight = 10;
        public const int numFog = 10;
        public const int numSmushy = 5;

        public List<Tree> Trees;
        public LittleGirl Girl { get; set; }
        public List<Light> light;
        public List<Smushy> smushy { get; set; }
        Random rnd = new Random();

        public Map()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.Tiles = new Tile[MAX_X, MAX_Y];

            this.light = new List<Light>();
            for (int i = 0; i < numLight; i++) {
                light.Add(new Light(rnd.Next(1, MAX_X * Tile.TILE_SIZE), rnd.Next(1, MAX_Y * Tile.TILE_SIZE)));
            }
            this.Girl = new LittleGirl(700, 700);

            smushy = new List<Smushy>();
            for(int i = 0; i < numSmushy; i++) {
                smushy.Add(new Smushy(rnd.Next(1, MAX_X * Tile.TILE_SIZE), rnd.Next(1, MAX_Y * Tile.TILE_SIZE)));
            }

            for (int x = 0; x < MAX_X; x++)
            {
                for (int y = 0; y < MAX_Y; y++)
                {
                    this.Tiles[x, y] = new Tile(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
                }
            }

            FogEntities = new List<Fog>();
            for (int i = 0; i < numFog; i++) {
                FogEntities.Add(new Fog(0, 0));
            }

            Trees = new List<Tree>();
            int numTrees = rnd.Next(5, 10);
            for (int i = 0; i < numTrees; i++) {
                this.Trees.Add(new Tree() {
                    X = rnd.Next(0, MAX_X * Tile.TILE_SIZE),
                    Y = rnd.Next(0, MAX_Y) * Tile.TILE_SIZE - 1
                });
            }
        }

        public void UpdateFog()
        {
            //In case we're adding more items than just light lulz
            int positionOfLightItemInInventory = -1;

            for (int i = 0; i < Program.map.Girl.littleGirlInventory.items.Count; i++)
            {
                if (Program.map.Girl.littleGirlInventory.items[i].GetType() == typeof(LightItem))
                {
                    positionOfLightItemInInventory = i;
                    break;
                }
            }

            for (int i = 0; i < Program.map.FogEntities.Count; i++)
            {
                if (Program.map.FogEntities[i].X <= (Program.map.Girl.X + 125) && Program.map.FogEntities[i].X >= (Program.map.Girl.X - 125) && Program.map.FogEntities[i].Y <= (Program.map.Girl.Y + 62) && Program.map.FogEntities[i].Y >= (Program.map.Girl.Y - 62))
                {
                    if (positionOfLightItemInInventory >= 0)
                    {
                        Program.map.DeleteFog(i);
                        Program.map.Girl.littleGirlInventory.items.RemoveAt(positionOfLightItemInInventory);
                        positionOfLightItemInInventory = -1;
                        return;
                    }
               
                }
            }
        }


        public void UpdateFogPositions()
        {
            foreach (var fog in this.FogEntities)
            {
                fog.UpdatePosition();
            }
        }
        
        public void UpdateSmushyPositions() {
            foreach(var smushy in this.smushy) {
                smushy.UpdatePosition();
            }
        }
        public void DeleteFog(int FogToDelete)
        {
            FogEntities.RemoveAt(FogToDelete);
        }

        public void UpdateFogAnimations()
        {
            foreach (var fog in this.FogEntities)
            {
                fog.UpdateAnim();
            }
        }
        
        public void UpdateSmushyAnimations() {
            foreach (var smushy in this.smushy) {
                smushy.UpdateAnimation();
            }
        }

        public void UpdateGirlAnimations()
        {
            this.Girl.UpdateAnimation();
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {

            for (int y = -3; y < 0; y++) {
                for (int x = 0; x < MAX_X; x++) {
                    yield return new DrawableComponent() {
                        TextureName = "grass2.png",
                        Position = new Vector2f(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE),
                        RenderSize = new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE)
                    };
                }
            }
            for (int x = 0; x < MAX_X; x += 3) {
                yield return new DrawableComponent() {
                    TextureName = "top border.png",
                    Position = new Vector2f(x * Tile.TILE_SIZE, -3 * Tile.TILE_SIZE),
                    RenderSize = new Vector2f(Tile.TILE_SIZE * 3, Tile.TILE_SIZE * 3)
                };
            }

            for (int y = 0; y < MAX_Y; y++) {
                for (int x = 0; x < MAX_X; x++) {
                    foreach (var component in this.Tiles[x, y].GetDrawableComponents()) {
                        yield return component;
                    }
                }
            }

            foreach (var lightComponent in this.light) {
                foreach (var component in lightComponent.GetDrawableComponents()) {
                    yield return component;
                }
            }

            for (int y = 0; y < MAX_Y; y++) {
                for (int x = 0; x < MAX_X; x++) {
                    if (this.Girl.InRange(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE, (x + 1) * Tile.TILE_SIZE, (y + 1) * Tile.TILE_SIZE)) {
                        foreach (var component in this.Girl.GetDrawableComponents()) {
                            yield return component;
                        }
                    }

                    foreach (var fog in this.FogEntities) {
                        if (fog.InRange(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE, (x + 1) * Tile.TILE_SIZE, (y + 1) * Tile.TILE_SIZE)) {
                            foreach (var component in fog.GetDrawableComponents()) {
                                yield return component;
                            }
                        }
                    }


                    foreach (var smushy in this.smushy) {
                        if (smushy.InRange(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE, (x + 1) * Tile.TILE_SIZE, (y + 1) * Tile.TILE_SIZE)) {
                            foreach (var component in smushy.GetDrawableComponents()) {
                                yield return component;
                            }
                        }
                    }

                    foreach (var tree in this.Trees) {
                        if (tree.InRange(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE, (x + 1) * Tile.TILE_SIZE, (y + 1) * Tile.TILE_SIZE)) {
                            foreach (var component in tree.GetDrawableComponents()) {
                                yield return component;
                            }
                        }
                    }
                }
            }

            for (int y = -2; y < MAX_Y; y += 3) {
                yield return new DrawableComponent() {
                    TextureName = "left border.png",
                    Position = new Vector2f(-2 * Tile.TILE_SIZE, y * Tile.TILE_SIZE),
                    RenderSize = new Vector2f(Tile.TILE_SIZE * 3, Tile.TILE_SIZE * 3)
                };
            }

            for (int y = -2; y < MAX_Y; y += 3) {
                yield return new DrawableComponent() {
                    TextureName = "right border.png",
                    Position = new Vector2f(Map.MAX_X * Tile.TILE_SIZE - Tile.TILE_SIZE, y * Tile.TILE_SIZE),
                    RenderSize = new Vector2f(Tile.TILE_SIZE * 3, Tile.TILE_SIZE * 3)
                };
            }

            for (int x = 0; x < MAX_X; x+= 3) {
                yield return new DrawableComponent() {
                    TextureName = "bottom border.png",
                    Position = new Vector2f(x * Tile.TILE_SIZE, Map.MAX_Y * Tile.TILE_SIZE - Tile.TILE_SIZE),
                    RenderSize = new Vector2f(Tile.TILE_SIZE * 3, Tile.TILE_SIZE * 3)
                };
            }
        }
    }
}
