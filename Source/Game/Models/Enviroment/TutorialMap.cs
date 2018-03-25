namespace Game.Models.Enviroment
{
    public class TutorialMap : Map
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
    }
}
