using NinjaShop.NinjaClothes;
using NinjaShop.ShopScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace NinjaShop.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject shopUIGameObject;
        [SerializeField] GameObject inventoryUIGameObject;
        [SerializeField] TextMeshProUGUI playerCoinsHUD;
        public Animator playerAnimator;
        public int playerCoins = 0;
        public List<string> ninjaClothsIdsPurchased = new List<string>();
        private bool canInteract = false;

        private void Update()
        {
            ActiveOrDesactiveInventory();
            ActiveOrDesactiveShopMenu();
        }

        private void ActiveOrDesactiveInventory()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!inventoryUIGameObject.activeInHierarchy)
                {
                    inventoryUIGameObject.SetActive(true);
                }
                else
                {
                    inventoryUIGameObject.SetActive(false);
                }
            }
        }

        private void ActiveOrDesactiveShopMenu()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canInteract)
                {
                    if (!shopUIGameObject.activeInHierarchy)
                    {
                        shopUIGameObject.SetActive(true);
                    }
                    else
                    {
                        shopUIGameObject.SetActive(false);
                    }
                }

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("ShopKeeper"))
            {
                Debug.Log("can Interact");
                canInteract = true;
                
            }

                        
            if (collision.gameObject.CompareTag("Coin"))
            {
                playerCoins += collision.GetComponent<Coin>().coinValue;
                playerCoinsHUD.text = playerCoins.ToString();
                Destroy(collision.gameObject);
                
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ShopKeeper"))
            {
                Debug.Log("can not interact");
                canInteract = false;

            }
        }
    }
}

