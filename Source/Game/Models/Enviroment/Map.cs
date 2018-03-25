using System.Collections.Generic;
using Game.Graphics;
using Game.Models.Collision;

namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public Tile[,] Tiles;
        public const int MAX_X = 10;
        public const int MAX_Y = 10;

        public List<Collider> _Colliders = new List<Collider>();
        public CircleShape testCircle = new CircleShape(new SFML.System.Vector2f(101.0f,101.0f), 0.5f);
        public LittleGirl Girl { get; set; }

        public Map()
        {
            this._Colliders.Add(testCircle);
            this.Tiles = new Tile[MAX_X, MAX_Y];

            this.Girl = new LittleGirl(new SFML.System.Vector2f(100.0f,100.0f),0.5f);

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
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

            foreach (var component in this.Girl.GetDrawableComponents()) {
                yield return component;
            }
            foreach (var component in this.testCircle.GetDrawableComponents())
            {
                yield return component;
            }

        }
    }
}
