using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI : MonoBehaviour
{
    public float bulletspeed;
    public float firerate;
    public Transform player;
    private float disttoplayer;
    public float range;
    public float walkspeed;
    public bool Patroling;
    public bool mustFlip;
    public bool canshoot;
    public Rigidbody2D rb;
    public Transform groundchecker;
    public LayerMask groundlayer;
    public Collider2D Body;
    public LayerMask wall;
    public Transform Shootpos;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        canshoot = true;
        rb = GetComponent<Rigidbody2D>();
        Patroling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Patroling)
        {
            Patrol();
        }

        disttoplayer = Vector2.Distance(transform.position, player.position);

        if (disttoplayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            Patroling = false;
            rb.velocity = Vector2.zero;
            if (canshoot)
            {
                StartCoroutine(Shoot());
            }
            
        }
        else
        {
            Patroling = true;
        }
    }
    void FixedUpdate()
    {
        if (Patroling)
        {
            mustFlip = !Physics2D.OverlapCircle(groundchecker.position, 0.1f, groundlayer);
        }
    }
    void Patrol()
    {
        if (mustFlip || Body.IsTouchingLayers(wall))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        Patroling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        Patroling = true;
    }

    IEnumerator Shoot()
    {
        canshoot = false;
        yield return new WaitForSeconds(firerate);

        GameObject newBullet = Instantiate(Bullet, Shootpos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed * walkspeed * Time.fixedDeltaTime, 0f);
        canshoot = true;
    }
}
