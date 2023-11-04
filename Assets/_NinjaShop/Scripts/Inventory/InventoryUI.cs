using NinjaShop.NinjaClothes;
using NinjaShop.PlayerScripts;
using NinjaShop.ShopScripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace NinjaShop.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public List<Button> allClothButtons = new List<Button>();
        public List<Button> hoodNinjaButtons = new List<Button>();
        public List<Button> faceNinjaButtons = new List<Button>();
        public List<Button> torsoNinjaButtons = new List<Button>();
        public List<Button> pelvisNinjaButtons = new List<Button>();

        [SerializeField] PlayerClothes playerClothes;
        [SerializeField] Shop shop;
        [SerializeField] Player player;
        

        private void Start()
        {
            SetButtonInfo(hoodNinjaButtons, shop.hoodNinjaClothes);
            SetButtonInfo(faceNinjaButtons, shop.faceNinjaClothes);
            SetButtonInfo(torsoNinjaButtons, shop.torsoNinjaClothes);
            SetButtonInfo(pelvisNinjaButtons, shop.pelvisNinjaClothes);
        }

        private void OnEnable()
        {
            CheckInventory(player.ninjaClothsIds);
        }

        //Muste be in each button of inventory
        public void EquipHoodCloth( ClothButtonInventory clothButtonInventory)
        {
            int index = shop.hoodNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInventory.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(shop.hoodNinjaClothes[index]);
            clothButtonInventory.selectedImage.gameObject.SetActive(true);
        }
        public void EquipFaceCloth(ClothButtonInventory clothButtonInventory)
        {
            int index = shop.faceNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInventory.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(shop.faceNinjaClothes[index]);
            clothButtonInventory.selectedImage.gameObject.SetActive(true);
        }

        public void EquipTorsoCloth(ClothButtonInventory clothButtonInventory)
        {
            int index = shop.torsoNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInventory.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(shop.torsoNinjaClothes[index]);
            clothButtonInventory.selectedImage.gameObject.SetActive(true);
        }

        public void EquipPelvisCloth(ClothButtonInventory clothButtonInventory)
        {
            int index = shop.pelvisNinjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInventory.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(shop.pelvisNinjaClothes[index]);
            clothButtonInventory.selectedImage.gameObject.SetActive(true);
        }

        private void SetButtonInfo(List<Button> buttons, List<NinjaCloth> ninjaClothes)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                var buttonInfo = buttons[i].GetComponent<ClothButtonInventory>();
                buttonInfo.buttonClothId = ninjaClothes[i].clothId;
                buttons[i].image.sprite = ninjaClothes[i].clothSprite;
            }
        }

        public void CheckInventory(List<string> ninjaClothesIds)
        {
            for (int i = 0; i < allClothButtons.Count; i++)
            {
                var buttonInfo = allClothButtons[i].GetComponent<ClothButtonInventory>();
                if(ninjaClothesIds.Contains(buttonInfo.buttonClothId))
                {
                    allClothButtons[i].interactable = true;
                }
                
            }

        }
    }
}

