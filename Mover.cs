using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public abstract class Mover : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] protected Vector3 movementDirection;
    [SerializeField] protected float movementSpeed;

    protected Rigidbody rigidBody;
    protected bool isGrounded = true;
    protected BoxCollider boxCollider;

    public float MovementSpeed => movementSpeed;

    public virtual void MoveTo(Vector3 direction)
    {
        rigidBody.velocity = direction * (MovementSpeed * Player.Instance.GetMovementSpeed() * Player.Instance.DistanceFactor/2) * Time.fixedDeltaTime;
    }

    protected void IsGrounded()
    {
        if (isGrounded != true) return;
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.3f, Vector3.down * 2, out hit) == false)
        {
            isGrounded = false;
            transform.DOMoveY(-Vector3.right.x * 4.81f, 0.75f).OnComplete(Player.Instance.Die);
        }
    }

}
