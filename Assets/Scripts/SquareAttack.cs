using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareAttack : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.F))
        {
            print("F");
            anim.Play("SquareAttack");
        }
    }
}
