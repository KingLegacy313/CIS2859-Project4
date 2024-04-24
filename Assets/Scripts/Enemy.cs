using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    GameObject coinPrefab;
    private GameObject coin;
    public Transform coinSpawn;

    [SerializeField]
    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(coinPrefab, coinSpawn.position, transform.rotation);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            StartCoroutine(Flash());
            health--;
        }
    }
    IEnumerator Flash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
