using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().currentHealth += 1;
            Destroy(gameObject);
        }
    }
}