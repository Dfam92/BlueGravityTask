using NinjaShop.NinjaClothes;
using NinjaShop.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaShop.ShopScripts
{
    public class Shop : MonoBehaviour
    {
        public List<NinjaCloth> hoodNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> faceNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> torsoNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> pelvisNinjaClothes = new List<NinjaCloth>();
        [SerializeField] PlayerClothes playerClothes;
        [SerializeField] Player player;

        public void EquipHood(ClothButtonInfo clothButtonInfo)
        {
            if (!clothButtonInfo.wasBought) return;
            int index = hoodNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInfo.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(hoodNinjaClothes[index]);
        }

        public void BuyCloth(ClothButtonInfo clothButtonInfo)
        {
            if (clothButtonInfo.wasBought) return;
            player.playerCoins = player.playerCoins - int.Parse(clothButtonInfo.clothPrice.text);
            clothButtonInfo.wasBought = true;
        }
    }

    
}

