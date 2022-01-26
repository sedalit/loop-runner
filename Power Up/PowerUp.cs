using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpAction powerUpAction;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        transform.position += -Vector3.forward * (2 * Player.Instance.DistanceFactor / 2) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 1, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerUpAction.Action(other.transform.GetComponent<Player>());
            SoundManager.Play(SoundManager.Instance.PowerUpCollected);
            gameObject.SetActive(false);
        }
    }
}
