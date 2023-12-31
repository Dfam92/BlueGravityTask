using DG.Tweening;
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
        [SerializeField] CanvasGroup infoPanel;
        [SerializeField] GameObject quitGamePanel;
        [SerializeField] TextMeshProUGUI playerCoinsHUD;
        [SerializeField] TextMeshProUGUI playerCoinsCollectedCount;
        [SerializeField] TextMeshProUGUI allCoinsCount;
        [SerializeField] List<GameObject> allCoins;
        [SerializeField] SpriteRenderer shopKeeperInteraction;
        [SerializeField] SfxAudioManager sfxAudioManager;
        public Animator playerAnimator;
        public int playerCoins = 0;
        public int playerCoinsCollected = 0;
        public List<string> ninjaClothsIdsPurchased = new List<string>();
        private bool canInteract = false;

        private void Start()
        {
            playerCoinsCollectedCount.text = playerCoinsCollected.ToString();
            allCoinsCount.text = allCoins.Count.ToString();

        }

        private void Update()
        {
            ActiveOrDesactiveInventory();
            ActiveOrDesactiveShopMenu();
            ActiveOrDesactiveQuitMenu();
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

        private void ActiveOrDesactiveQuitMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                {
                    if (!quitGamePanel.activeInHierarchy)
                    {
                        quitGamePanel.SetActive(true);
                    }
                    else
                    {
                        quitGamePanel.SetActive(false);
                    }
                }

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("ShopKeeper"))
            {
                canInteract = true;
                shopKeeperInteraction.DOFade(1, 0.5f);
                
            }

                        
            if (collision.gameObject.CompareTag("Coin"))
            {
                playerCoinsCollected += 1;
                playerCoinsCollectedCount.text = playerCoinsCollected.ToString();
                playerCoins += collision.GetComponent<Coin>().coinValue;
                playerCoinsHUD.text = playerCoins.ToString();
                sfxAudioManager.PlayCoinCollect();
                Destroy(collision.gameObject);
                
            }

            if(collision.gameObject.CompareTag("InfoPanel"))
            {
                infoPanel.DOFade(1, 0.5f);
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ShopKeeper"))
            {
                canInteract = false;
                shopKeeperInteraction.DOFade(0, 0.5f);

            }

            if (collision.gameObject.CompareTag("InfoPanel"))
            {
                infoPanel.DOFade(0, 0.5f);
            }
        }
    }
}

