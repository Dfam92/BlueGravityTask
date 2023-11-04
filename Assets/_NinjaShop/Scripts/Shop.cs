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
            player.ninjaClothsIds.Add(clothButtonInfo.buttonClothId);
            
        }

        public void SellCloth(ClothButtonInfo clothButtonInfo)
        {
            if(playerClothes.equippedClothes.Contains(clothButtonInfo.buttonClothId))
            {
                Debug.Log("You Can't sell equipped clothes");
                return;
            }
            int clothPrice = int.Parse(clothButtonInfo.clothPrice.text);
            player.playerCoins += clothPrice;
            clothButtonInfo.clothPrice.text = clothButtonInfo.defaultPrice;
            clothButtonInfo.sellButton.interactable = false;
            clothButtonInfo.buyButton.interactable = true;
            clothButtonInfo.alreadyPurchased.gameObject.SetActive(false);
            player.ninjaClothsIds.Remove(clothButtonInfo.buttonClothId);

        }
    }

    
}

