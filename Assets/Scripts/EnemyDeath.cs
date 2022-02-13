using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EnemyDeath : MonoBehaviour
{
    public GameObject particlesystem;
    public SpriteRenderer Enemy;
    public GameObject Enemy_Object;
    public Collider2D mainbody;
    public LayerMask playerattack;


    void Start()
    {
        particlesystem.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D PlayerAttack)
    {
        if (mainbody.IsTouchingLayers(playerattack))
        {
            Instantiate(particlesystem, transform.position, transform.rotation);
            particlesystem.SetActive(true);
            Destroy(Enemy);

            StartCoroutine(Timer());
        }


    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Destroy(Enemy_Object);
    }
}
