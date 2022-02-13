using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float dietime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdowntimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }
    IEnumerator countdowntimer()
    {
        yield return new WaitForSeconds(dietime);

        die();
    }
    void die()
    {
        Destroy(gameObject);
    }
}
