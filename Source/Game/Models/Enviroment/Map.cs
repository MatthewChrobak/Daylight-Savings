﻿using System;
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

        public LittleGirl Girl { get; set; }
        public List<Light> light;
        public Smushy smushy { get; set; }
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

            this.smushy = new Smushy(100, 100);

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
                }
            }

            FogEntities = new List<Fog>();
            for (int i = 0; i < 10; i++) {
                FogEntities.Add(new Fog(0, 0));
            }

           
        }

        public void UpdateFogPositions()
        {
            foreach (var fog in this.FogEntities) {
                fog.UpdatePosition();
            }
        }

        public void UpdateSmushyPositions() {
            this.smushy.UpdatePosition();
        }

        public void UpdateFogAnimations()
        {
            foreach (var fog in this.FogEntities) {
                fog.UpdateAnim();
            }
        }

        public void UpdateSmushyAnimations() {
            this.smushy.UpdateAnimation();
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


            for (int i = 0; i < light.Count; i++) {
                foreach (var component in light[i].GetDrawableComponents()) {
                    yield return component;
                }
            }
            foreach (var component in this.Girl.GetDrawableComponents()) {
                yield return component;
            }


            foreach (var fog in this.FogEntities) {
                foreach (var component in fog.GetDrawableComponents()) {
                    yield return component;
                }
            }
            foreach (var component in this.smushy.GetDrawableComponents()) {
                yield return component;
            }
        }
    }
}
