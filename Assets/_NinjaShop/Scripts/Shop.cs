using DG.Tweening;
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
        [SerializeField] ShopUI shopUI;
        private float sellDepreciation = 0.5f;

        private void Start()
        {
            UpdateCoins();
        }

        private void OnEnable()
        {
            UpdateCoins();
        }

        public void BuyCloth(ClothButtonInfo clothButtonInfo)
        {
            
            int clothPrice = int.Parse(clothButtonInfo.clothPrice.text);
            if (player.playerCoins < clothPrice)
            {
                shopUI.FadeWarningText(ShopUI.DontHaveMoney);
                return;
            }
            player.playerCoins = player.playerCoins - clothPrice;
            UpdateCoins();
            clothButtonInfo.clothPrice.text = (clothPrice * sellDepreciation).ToString();
            clothButtonInfo.sellButton.interactable = true;
            clothButtonInfo.buyButton.interactable = false;
            clothButtonInfo.alreadyPurchased.gameObject.SetActive(true);
            player.ninjaClothsIdsPurchased.Add(clothButtonInfo.buttonClothId);
            
        }

        public void SellCloth(ClothButtonInfo clothButtonInfo)
        {
            if(playerClothes.equippedClothes.Contains(clothButtonInfo.buttonClothId))
            {
                shopUI.FadeWarningText(ShopUI.CantSellEquipped);
                return;
            }
            int clothPrice = int.Parse(clothButtonInfo.clothPrice.text);
            player.playerCoins += clothPrice;
            UpdateCoins();
            clothButtonInfo.clothPrice.text = clothButtonInfo.defaultPrice;
            clothButtonInfo.sellButton.interactable = false;
            clothButtonInfo.buyButton.interactable = true;
            clothButtonInfo.alreadyPurchased.gameObject.SetActive(false);
            player.ninjaClothsIdsPurchased.Remove(clothButtonInfo.buttonClothId);

        }

        public void UpdateCoins()
        {
            shopUI.playerCurrentCoins.text = player.playerCoins.ToString();
            shopUI.playerCurrentCoinsHUD.text = player.playerCoins.ToString();
        }
    }

    

    
}

