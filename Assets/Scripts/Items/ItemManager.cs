using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;
using TMPro;

namespace Items
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }



    public class ItemManager : Singleton<ItemManager>
    {

        public List<ItemSetup> itemSetup;

       

        private void Start()
        {
           Reset();
           LoadItemsFromSave();
        }

        private void LoadItemsFromSave()
        {
            AddByType(ItemType.COIN, (int) SaveManager.Instance.Setup.coins);
            AddByType(ItemType.LIFE_PACK, (int) SaveManager.Instance.Setup.health);
        }

        private void Reset()
        {
            foreach(var i in itemSetup)
            {
                i.soInt.value = 0;
            }
        }

        public ItemSetup GetItemByType(ItemType itemType)
        {
           return itemSetup.Find(i => i.itemType == itemType);
        }  

        public void AddByType(ItemType itemType, int amount = 1)
        {
           if (amount < 0) return;
           itemSetup.Find(i => i.itemType == itemType).soInt.value += amount;
        }  
        
        public void RemoveByType(ItemType itemType, int amount = 1)
        { 
            var item = itemSetup.Find(i => i.itemType == itemType);
            item.soInt.value -= amount;

            if (item.soInt.value < 0) item.soInt.value = 0;

        }



        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }  
        
        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK);
        }
     
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }

}
