using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerMover : Mover
{
    [Header("Jump settings")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpDuration;
    [Header("Rotation settings")]
    [SerializeField] private float stepSize;
    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationSpeed;

    private bool isCanChangeRoad = true;
    private bool isCrouch = false;
    private int currentRoad;

    private Sequence currentSequence;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        currentRoad = 0;
    }

    private void Update()
    {
        IsGrounded();
    }

    private void FixedUpdate()
    {
        MoveTo(movementDirection);
    }

    public virtual void TryJump()
    {
        if (isGrounded != true) return;
        isGrounded = false;
        currentSequence = DOTween.Sequence();
        currentSequence.Append(transform.DOMoveY(jumpSpeed, jumpDuration).SetLoops(2, LoopType.Yoyo));
        currentSequence.Insert(0, transform.DORotate(new Vector3(180, 0), 1).SetLoops(2, LoopType.Yoyo));
        currentSequence.OnComplete(OnJumpComplete);
    }

    public void TryMoveRight()
    {
        if (isCanChangeRoad != true) return;
        if (currentRoad + 1 > 1) return;
        isCanChangeRoad = false;
        currentRoad++;
        RotateOnNextRoad(-currentRoad, rotationAngle);
    }

    public void TryMoveLeft()
    {
        if (isCanChangeRoad != true) return;
        if (currentRoad - 1 < -1) return;
        isCanChangeRoad = false;
        currentRoad--;
        RotateOnNextRoad(currentRoad, -rotationAngle);
    }

    public void TrySeat()
    {
        if (isCrouch) return;
        if (isGrounded == false)
        {
            transform.DOMove(new Vector3(transform.position.x, 0.89f, transform.position.z), 0.2f).OnComplete(OnJumpComplete);
            return;
        }
        isCrouch = true;
        transform.DOScale(0.25f, 1f).SetLoops(2, LoopType.Yoyo).OnComplete(OnCrouchComplete);
    }

    private void RotateOnNextRoad(int road, float angle)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(currentRoad * stepSize, rotationSpeed));
        sequence.Insert(0, transform.DORotate(new Vector3(0, 0, road * angle), rotationSpeed));
        sequence.OnComplete(OnChangeRoadComplete);
    }

    private void OnJumpComplete()
    {
        currentSequence.Complete();
        currentSequence = null;
        isGrounded = true;
    }

    private void OnChangeRoadComplete()
    {
        isCanChangeRoad = true;
    }

    private void OnCrouchComplete()
    {
        isCrouch = false;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
    public void AddMovementSpeed(float bonus)
    {
        movementSpeed += bonus;
    }
}

