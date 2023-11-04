using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaShop.NinjaClothes
{
    public class NinjaCloth : MonoBehaviour
    {
        public string clothId;
        public ClothType clothType;
        public Sprite clothSprite;
        public int clothPrice;
 
    }

   

}
public enum ClothType
{
    Hood,
    Face,
    Torso,
    Pelvis
}