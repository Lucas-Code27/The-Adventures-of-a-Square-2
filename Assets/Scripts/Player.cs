using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    public Vector2 eyeOffset;
    public Transform eyesTransform;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = new Vector3(0, 0, -.012f); ;

        
        if (rigidbody2D.velocity.x >= 3)
            eyePosition.x = eyeOffset.x;
        else if (rigidbody2D.velocity.x <= -3)
            eyePosition.x = -eyeOffset.x;
        else
            eyesTransform.localPosition = new Vector3(0, -.14f, -.012f);

        
        if (rigidbody2D.velocity.y >= 1)
            eyePosition.y = eyeOffset.y;
        else if (rigidbody2D.velocity.y <= -1)
            eyePosition.y = -eyeOffset.y;
        else
            eyesTransform.localPosition = new Vector3(0, -0.08f, -.012f);

        eyesTransform.localPosition = eyePosition;


    }
}
