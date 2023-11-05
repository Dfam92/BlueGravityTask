using NinjaShop.NinjaClothes;
using NinjaShop.PlayerScripts;
using NinjaShop.ShopScripts;
using System;
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
            CheckInventory(player.ninjaClothsIds);
        }

        private void OnEnable()
        {
            CheckInventory(player.ninjaClothsIds);
        }

        private void DisableOtherSelection(List<Button> clothesButtons, int index, List<NinjaCloth> ninjaClothes)
        {
            foreach (var button in clothesButtons)
            {
                ClothButtonInventory buttonInventory = button.GetComponent<ClothButtonInventory>();
                if (buttonInventory.buttonClothId == ninjaClothes[index].clothId) continue;
                else
                {
                    buttonInventory.selectedImage.gameObject.SetActive(false);
                    playerClothes.equippedClothes.Remove(buttonInventory.buttonClothId);
                }
            }
        }

        public void EquipHoodCloth(ClothButtonInventory clothButtonInventory)
        {
            EquipCloth(clothButtonInventory, shop.hoodNinjaClothes, hoodNinjaButtons);
        }

        public void EquipFaceCloth(ClothButtonInventory clothButtonInventory)
        {
            EquipCloth(clothButtonInventory, shop.faceNinjaClothes, faceNinjaButtons);
        }

        public void EquipTorsoCloth(ClothButtonInventory clothButtonInventory)
        {
            EquipCloth(clothButtonInventory, shop.torsoNinjaClothes, torsoNinjaButtons);
        }

        public void EquipPelvisCloth(ClothButtonInventory clothButtonInventory)
        {
            EquipCloth(clothButtonInventory, shop.pelvisNinjaClothes, pelvisNinjaButtons);
        }

        private void EquipCloth(ClothButtonInventory clothButtonInventory, List<NinjaCloth> ninjaClothes, List<Button> buttonList)
        {
            int index = ninjaClothes.FindIndex(clothId => clothId.clothId == clothButtonInventory.buttonClothId);
            if (index < 0) return;
            playerClothes.EquipClothes(ninjaClothes[index]);
            clothButtonInventory.selectedImage.gameObject.SetActive(true);
            playerClothes.equippedClothes.Add(clothButtonInventory.buttonClothId);
            DisableOtherSelection(buttonList, index, ninjaClothes);
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
                else
                {
                    allClothButtons[i].interactable = false;
                    buttonInfo.selectedImage.gameObject.SetActive(false);
                }
                
            }

        }
    }
}

