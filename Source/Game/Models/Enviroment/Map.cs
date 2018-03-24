﻿using System.Collections.Generic;
using Game.Graphics;

namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public Tile[,] Tiles;
        public const int MAX_X = 10;
        public const int MAX_Y = 10;

        public Map()
        {
            this.Tiles = new Tile[MAX_X, MAX_Y];

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile();
                }
            }
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
        }
    }
}
