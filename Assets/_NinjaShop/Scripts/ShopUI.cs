using DG.Tweening;
using NinjaShop.NinjaClothes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaShop.ShopScripts
{
    public class ShopUI : MonoBehaviour
    {
        public List<Button> hoodNinjaButtons = new List<Button>();
        public List<Button> faceNinjaButtons = new List<Button>();
        public List<Button> torsoNinjaButtons = new List<Button>();
        public List<Button> pelvisNinjaButtons = new List<Button>();
        public TextMeshProUGUI warningMessages;
        public static string DontHaveMoney = "You Don't have enought money";
        public static string CantSellEquipped = "You Can't sell equipped clothes";
        [SerializeField] Shop shop;

        private void Start()
        {
            SetButtonInfo(hoodNinjaButtons, shop.hoodNinjaClothes);
            SetButtonInfo(faceNinjaButtons, shop.faceNinjaClothes);
            SetButtonInfo(torsoNinjaButtons, shop.torsoNinjaClothes);
            SetButtonInfo(pelvisNinjaButtons, shop.pelvisNinjaClothes);
        }

        private void SetButtonInfo(List<Button> buttons, List<NinjaCloth> ninjaClothes)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                var buttonInfo = buttons[i].GetComponent<ClothButtonInfo>();
                buttonInfo.buttonClothId = ninjaClothes[i].clothId;
                buttonInfo.clothPrice.text = ninjaClothes[i].clothPrice.ToString();
                buttonInfo.defaultPrice = buttonInfo.clothPrice.text;
                buttons[i].image.sprite = ninjaClothes[i].clothSprite;
            }
        }

        public void FadeWarningText(string message)
        {
            warningMessages.text = message;
            warningMessages.DOFade(1, 1).OnComplete(() =>
            {
                warningMessages.DOFade(0, 2);
            });
        }


    }
}

