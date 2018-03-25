using Game.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Game.Models.Enviroment
{
    public class TutorialMap : Map, IDrawable
    {
        public TutorialMap()
        {
            this.MAX_X = 12;
            this.MAX_Y = 10;

            this.numStartFog = 0;
            this.numStartLight = 0;
            this.numStartSmushy = 0;
            this.numStartTrees = 0;
            this.numStartPotions = 0;

            this.LittleGirlStartX = 5 * Tile.TILE_SIZE;
            this.LittleGirlStartY = 5 * Tile.TILE_SIZE;
        }

        public void RespawnFogs()
        {
            if (this.FogEntities.Count != 1) {
                this.FogEntities.Add(new Entities.Fog(3 * Tile.TILE_SIZE, 2.5f * Tile.TILE_SIZE));
            }
        }

        public void RespawnPotions()
        {
            if (this.potion.Count != 1) {
                this.potion.Add(new Potion(9 * Tile.TILE_SIZE, 2.5f * Tile.TILE_SIZE));
            }
        }

        public void RespawnSmushy()
        {
            if (this.smushy.Count != 1) {
                this.smushy.Add(new Smushy(9 * Tile.TILE_SIZE, 7.5f * Tile.TILE_SIZE));
            }
        }

        public void RespawnLights()
        {
            if (this.light.Count != 1) {
                this.light.Add(new Light(3 * Tile.TILE_SIZE, 7.5f * Tile.TILE_SIZE));
            }
        }

        public new IEnumerable<DrawableComponent> GetDrawableComponents()
        {
            foreach (var component in base.GetDrawableComponents()) {
                yield return component;
            }

            yield return new DrawableComponent() {
                TextureName = "fogexpl.png",
                Position = new Vector2f(-1 * Tile.TILE_SIZE, -2 * Tile.TILE_SIZE),
                RenderSize = new Vector2f(150, 150)
            };

            yield return new DrawableComponent() {
                TextureName = "potionsexpl.png",
                Position = new Vector2f((MAX_X - 2)* Tile.TILE_SIZE, -2 * Tile.TILE_SIZE),
                RenderSize = new Vector2f(150, 150)
            };

            yield return new DrawableComponent() {
                TextureName = "lightexpl.png",
                Position = new Vector2f(-1 * Tile.TILE_SIZE, (MAX_Y - 2) * Tile.TILE_SIZE),
                RenderSize = new Vector2f(150, 150)
            };

            yield return new DrawableComponent() {
                TextureName = "smushyexpl.png",
                Position = new Vector2f((MAX_X - 2) * Tile.TILE_SIZE, (MAX_Y - 2) * Tile.TILE_SIZE),
                RenderSize = new Vector2f(150, 150)
            };
        }
    }
}
