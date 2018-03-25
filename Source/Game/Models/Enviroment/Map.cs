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
            this.Girl = new LittleGirl(700, 700);

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

        public void UpdateFog()
        {
            //In case we're adding more items than just light lulz
            int positionOfLightItemInInventory = -1;

            for(int i = 0; i < Program.map.Girl.littleGirlInventory.items.Count; i++)
            {
                if(Program.map.Girl.littleGirlInventory.items[i].GetType() == typeof(LightItem))
                {
                    positionOfLightItemInInventory = i;
                    break;
                }
            }
            
            if (positionOfLightItemInInventory >= 0) { 
                
                for (int i = 0; i < Program.map.FogEntities.Count; i++)
                {
                    if (Program.map.FogEntities[i].X <= (Program.map.Girl.X + 125) && Program.map.FogEntities[i].X >= (Program.map.Girl.X - 125) && Program.map.FogEntities[i].Y <= (Program.map.Girl.Y + 62) && Program.map.FogEntities[i].Y >= (Program.map.Girl.Y - 62))
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
            foreach (var fog in this.FogEntities) {
                fog.UpdatePosition();
            }
        }

        public void DeleteFog(int FogToDelete)
        {
            FogEntities.RemoveAt(FogToDelete);
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
        }
    }
}
