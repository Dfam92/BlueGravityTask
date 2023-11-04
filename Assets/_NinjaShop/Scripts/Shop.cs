using NinjaShop.NinjaClothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaShop.Shop
{
    public class Shop : MonoBehaviour
    {
        public List<NinjaCloth> hoodNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> faceNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> torsoNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> pelvisNinjaClothes = new List<NinjaCloth>();
        [SerializeField] PlayerClothes playerClothes;

        public void EquipHood(ClothButtonInfo clothButtonInfo)
        {
            int index = hoodNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInfo.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(hoodNinjaClothes[index]);
        }

    }

    
}

