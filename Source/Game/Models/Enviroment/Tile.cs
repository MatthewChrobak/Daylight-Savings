﻿using Game.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Game.Models.Enviroment
{
    public class Tile : Position, IDrawable
    {
        public string SurfaceName { get; set; } = "grass.png";
        public const int TILE_SIZE = 48;

        public Tile(float x, float y) : base(x, y)
        {

        }

        public IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            yield return new DrawableComponent() {
                TextureName = this.SurfaceName,
                RenderSize = new Vector2f(TILE_SIZE, TILE_SIZE),
                Position = new Vector2f(this.X, this.Y)
            };
        }
    }
}
