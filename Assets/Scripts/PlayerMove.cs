using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.5f;

    [SerializeField]
    private float jumpForce = 12.0f;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;

    public CoinManager cm;

    [SerializeField]
    GameObject hiddenPlatPrefab;
    private GameObject hiddenPlat;

    [SerializeField]
    SpriteRenderer sprite;

    public bool isRight;

    //Vector3 local = new transform.localScale;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        isRight = true;
    }//end Start


    void Update()
    {
       

            float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }//end if

        body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }//end if

       

        MovingPlatform platform = null;

        if (hit != null)
        {
            platform = hit.GetComponent<MovingPlatform>();
        }

        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }

        anim.SetFloat("Speed", Mathf.Abs(deltaX));

        Vector3 pScale = Vector3.one;

        if (platform != null)
        {
            pScale = platform.transform.localScale;
        }

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(
                Mathf.Sign(deltaX) / pScale.x,
                 1 / pScale.y,
                1);
        }//end if

        if (transform.localScale.x == 1)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
    }//end Update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
