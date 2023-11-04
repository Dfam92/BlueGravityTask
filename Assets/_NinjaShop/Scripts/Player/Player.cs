using NinjaShop.NinjaClothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NinjaShop.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public int playerCoins = 0;
        public List<string> ninjaClothsIds = new List<string>();
        public List<NinjaCloth> hoodNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> faceNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> torsoNinjaClothes = new List<NinjaCloth>();
        public List<NinjaCloth> pelvisNinjaClothes = new List<NinjaCloth>();

    }
}

