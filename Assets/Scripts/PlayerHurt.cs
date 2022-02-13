using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    public static int Health = 1;
    public int MaxHealth = 1;
    public Collider2D Body;
    public LayerMask enemyattack;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Body.IsTouchingLayers(enemyattack))
        {
            Health -= 1;
        }
        if (Health <= 0)
        {
            SceneManager.LoadScene("Classic Mode");
        }
    }
}
