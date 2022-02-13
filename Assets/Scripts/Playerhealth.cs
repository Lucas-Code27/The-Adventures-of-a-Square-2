using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    public Text HealthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = PlayerHurt.Health.ToString("Health: ") + PlayerHurt.Health;
    }
}
