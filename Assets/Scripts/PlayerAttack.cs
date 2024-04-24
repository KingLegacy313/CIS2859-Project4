using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    

    [SerializeField]
    GameObject fireballPrefab;
    private GameObject fireball;
    public Transform shootFireball;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Attack();
            StartCoroutine(Go());
            
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
    
    IEnumerator Go()
    {
        
            yield return new WaitForSeconds(.25f);
            Instantiate(fireballPrefab, shootFireball.position, transform.rotation);
        
    }
}
