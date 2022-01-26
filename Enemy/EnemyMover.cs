using UnityEngine;

public class EnemyMover : Mover
{
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveTo(movementDirection);
    }
}
