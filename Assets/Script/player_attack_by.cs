using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack_by : MonoBehaviour
{
    GameObject attackArea;
    int attacking;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            atttack();
        }   
    }
    void atttack()
    {
        attacking = 1;
        attackArea.SetActive(true);
    }
}
