using NinjaShop.NinjaClothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NinjaShop.PlayerScripts
{
    public class PlayerClothes : MonoBehaviour
    {
        [SerializeField] SpriteRenderer hoodSpriteRenderer;
        [SerializeField] SpriteRenderer faceSpriteRenderer;
        [SerializeField] SpriteRenderer torsoSpriteRenderer;
        [SerializeField] SpriteRenderer pelvisSpriteRenderer;

        public List<string> equippedClothes = new List<string>();

        public void EquipClothes(NinjaCloth cloth)
        {
            switch (cloth.clothType)
            {
                case ClothType.Hood:
                    hoodSpriteRenderer.sprite = cloth.clothSprite;
                    break;
                case ClothType.Face:
                    faceSpriteRenderer.sprite = cloth.clothSprite;
                    break;
                case ClothType.Torso:
                    torsoSpriteRenderer.sprite = cloth.clothSprite;
                    break;
                case ClothType.Pelvis:
                    pelvisSpriteRenderer.sprite = cloth.clothSprite;
                    break;
                default:
                    break;
            }
        }
    }
}

