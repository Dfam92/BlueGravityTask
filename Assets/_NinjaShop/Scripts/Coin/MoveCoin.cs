using UnityEngine;
using DG.Tweening;

public class MoveCoin : MonoBehaviour
{
    [SerializeField] float moveDistance = 1f;
    [SerializeField] float moveDuration = 0.5f;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + moveDistance, moveDuration).SetLoops(-1, LoopType.Yoyo);
    }
}
