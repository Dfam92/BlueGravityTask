using UnityEngine;
using UnityEngine.InputSystem;

namespace NinjaShop.PlayerScripts
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] Player player;
        public float moveSpeed = 5f;
        Vector2 moveInput;

        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
            player.playerAnimator.SetBool("isWalking", true);
            if (moveInput.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (moveInput.x > 0)
            {
                transform.rotation = Quaternion.identity;
            }
            if(moveInput.x == 0 && moveInput.y == 0) {
                player.playerAnimator.SetBool("isWalking", false);

            }
        }

        

        void FixedUpdate()
        {
            Vector2 movement = moveInput * moveSpeed * Time.fixedDeltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
    }
}

