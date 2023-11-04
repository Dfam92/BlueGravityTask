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
        private float sellDepreciation = 0.5f;


        public void EquipHood(ClothButtonInfo clothButtonInfo)
        {
            int index = hoodNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInfo.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(hoodNinjaClothes[index]);
        }

        public void BuyCloth(ClothButtonInfo clothButtonInfo)
        {
            
            int clothPrice = int.Parse(clothButtonInfo.clothPrice.text);
            if (player.playerCoins < clothPrice)
            {
                Debug.Log("You Don't have enought money");
                return;
            }
            player.playerCoins = player.playerCoins - clothPrice;
            clothButtonInfo.clothPrice.text = (clothPrice * sellDepreciation).ToString();
            clothButtonInfo.sellButton.interactable = true;
            clothButtonInfo.buyButton.interactable = false;
            clothButtonInfo.alreadyPurchased.gameObject.SetActive(true);
            
        }

        public void SellCloth(ClothButtonInfo clothButtonInfo)
        {
            int clothPrice = int.Parse(clothButtonInfo.clothPrice.text);
            player.playerCoins += clothPrice;
            clothButtonInfo.clothPrice.text = clothButtonInfo.defaultPrice;
            clothButtonInfo.sellButton.interactable = false;
            clothButtonInfo.buyButton.interactable = true;
            clothButtonInfo.alreadyPurchased.gameObject.SetActive(false);

        }
    }

    
}

