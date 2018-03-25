using System.Collections.Generic;
using Game.Graphics;
using Game.Models.Collision;
using Game.Models.Entities;

namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public List<Fog> FogEntities = new List<Fog>();
        public Tile[,] Tiles;
        public const int MAX_X = 10;
        public const int MAX_Y = 10;

        public List<Collider> _Colliders = new List<Collider>();
        public CircleShape testCircle = new CircleShape(new SFML.System.Vector2f(110.0f,110.0f), 20f);
        public LittleGirl Girl { get; set; }

        public Map()
        {
            this._Colliders.Add(testCircle);
            this.Tiles = new Tile[MAX_X, MAX_Y];

            this.Girl = new LittleGirl(new SFML.System.Vector2f(100.0f,100.0f),10f);

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
                }
            }

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

        public void UpdateFogAnim()
        {
            foreach (var fog in this.FogEntities) {
                fog.UpdateAnim();
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

            foreach (var component in this.Girl.GetDrawableComponents()) {
                yield return component;
            }

            foreach (var fog in this.FogEntities) {
                foreach (var component in fog.GetDrawableComponents()) {
                    yield return component;
                }
            }
            foreach (var component in this.testCircle.GetDrawableComponents())
            {
                yield return component;
            }

        }
    }
}
