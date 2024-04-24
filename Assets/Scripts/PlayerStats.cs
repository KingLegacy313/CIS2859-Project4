using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;

    [SerializeField]
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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
