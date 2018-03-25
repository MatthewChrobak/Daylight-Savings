using System;


namespace Game.Models
{
    public class Inventory
    {
        public Item[] littleGirlInventory { get; set; } = new Item[10];


        //Functions to add and remove items
        public void addItemIntoInventory(Item item)
        {
            for (int i=0;i<this.littleGirlInventory.Length;i++)
            {
                if (this.littleGirlInventory[i] == null)
                {
                    this.littleGirlInventory[i] = item;
                    break;
                }
            }
        }

        public void removeItemFromInventory (Item item)
        {
            for (int i = 0; i < this.littleGirlInventory.Length; i++)
            {
                if (this.littleGirlInventory[i] == item)
                {
                    this.littleGirlInventory[i] = null;
                    break;
                }
            }
        }

        public void viewItemFromInventory()
        {
            foreach(Item i in littleGirlInventory)
            {
                Console.WriteLine(i);
            }
        }
    }

}
