using System;

namespace Game.Models
{
    public class LittleGirl
    {
        enum direction
        {
            left, right, up, down
        };

        public int health { get; set; }
        public Inventory littleGirlInventory;
    }
}


