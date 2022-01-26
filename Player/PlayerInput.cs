using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover playerMover;

    private void Start()
    {
        playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerSwipe += OnSwipe;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= OnSwipe;
    }

    public void OnSwipe(LeanFinger finger)
    {
        SoundManager.Play(SoundManager.Instance.TapSound);
        if (finger.SwipeScreenDelta.normalized.x >= 0.9f)
        {
            playerMover.TryMoveRight();
            return;
        }
        if (finger.SwipeScreenDelta.normalized.x <= -0.9f)
        {
            playerMover.TryMoveLeft();
            return;
        }
        if (finger.SwipeScreenDelta.normalized.y >= 0.9f)
        {
            playerMover.TryJump();
            return;
        }
        if (finger.SwipeScreenDelta.normalized.y <= -0.9f)
        {
            playerMover.TrySeat();
            return;
        }
    }
}
