using System.Collections.Generic;
using Game.Graphics;

namespace Game.Models.Enviroment
{
    public class Map : IDrawable
    {
        public Tile[,] Tiles;
        public const int MAX_X = 10;
        public const int MAX_Y = 10;
        public const int TILE_SIZE = 16;

        public LittleGirl Girl { get; set; }

        public Map()
        {
            this.Tiles = new Tile[MAX_X, MAX_Y];

            this.Girl = new LittleGirl(100, 100);

            for (int x = 0; x < MAX_X; x++) {
                for (int y = 0; y < MAX_Y; y++) {
                    this.Tiles[x, y] = new Tile(x * TILE_SIZE, y * TILE_SIZE);
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

                    if (this.Girl.X >= x * TILE_SIZE && this.Girl.X <= (x + 1) * TILE_SIZE) {
                        if (this.Girl.Y >= y * TILE_SIZE && this.Girl.Y <= (y + 1) * TILE_SIZE) {
                            foreach (var component in this.Girl.GetDrawableComponents()) {
                                yield return component;
                            }
                        }
                    }
                }
            }
        }
    }
}
