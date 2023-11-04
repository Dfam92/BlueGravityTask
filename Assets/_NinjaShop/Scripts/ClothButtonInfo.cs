using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaShop.ShopScripts

{
    public class ClothButtonInfo : MonoBehaviour
    {
        public string buttonClothId;
        public TextMeshProUGUI clothPrice;
        public string defaultPrice;
        public Button buyButton;
        public Button sellButton;
        public Image alreadyPurchased;

    }
}

