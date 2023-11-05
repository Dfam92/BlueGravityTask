using NinjaShop.NinjaClothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NinjaShop.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject shopUIGameObject;
        [SerializeField] GameObject inventoryUIGameObject;
        public Animator playerAnimator;
        public int playerCoins = 0;
        public List<string> ninjaClothsIdsPurchased = new List<string>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUIGameObject.SetActive(true);
            }

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("ShopKeeper"))
            {
                Debug.Log("Im Colliding");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    shopUIGameObject.SetActive(true);
                }
            }
        }
    }
}

