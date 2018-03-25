using System;
using System.Collections.Generic;
using Game.Graphics;
using Game.Models;
using Game.Models.Entities;


namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public List<Fog> FogEntities;
        public Tile[,] Tiles;
        public const int MAX_X = 30;
        public const int MAX_Y = 15;

        public List<Tree> Trees;
        public LittleGirl Girl { get; set; }
        public List<Light> light;
        Random rnd = new Random();

        public Map()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.Tiles = new Tile[MAX_X, MAX_Y];

            this.light = new List<Light>();
            for (int i = 0; i < 10; i++) {
                light.Add(new Light(rnd.Next(1, MAX_X * Tile.TILE_SIZE), rnd.Next(1, MAX_Y * Tile.TILE_SIZE)));
            }
            this.Girl = new LittleGirl(rnd.Next(1, MAX_X * Tile.TILE_SIZE), rnd.Next(1, MAX_Y * Tile.TILE_SIZE));

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
                }
            }

            FogEntities = new List<Fog>();
            for (int i = 0; i < 10; i++) {
                FogEntities.Add(new Fog(0, 0));
            }

            Trees = new List<Tree>();
            int numTrees = rnd.Next(5, 10);
            for (int i = 0; i < numTrees; i++) {
                this.Trees.Add(new Tree() {
                    X = rnd.Next(0, MAX_X * Tile.TILE_SIZE),
                    Y = rnd.Next(0, MAX_Y * Tile.TILE_SIZE)
                });
            }
        }

        public void UpdateFogPositions()
        {
            foreach (var fog in this.FogEntities) {
                fog.UpdatePosition();
            }
        }

        public void UpdateFogAnimations()
        {
            foreach (var fog in this.FogEntities) {
                fog.UpdateAnim();
            }
        }

        public void UpdateGirlAnimations()
        {
            this.Girl.UpdateAnimation();
        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
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

                    foreach (var tree in this.Trees) {
                        if (tree.InRange(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE, (x + 1) * Tile.TILE_SIZE, (y + 1) * Tile.TILE_SIZE)) {
                            foreach (var component in tree.GetDrawableComponents()) {
                                yield return component;
                            }
                        }
                    }
                }
            }
        }
    }
}
