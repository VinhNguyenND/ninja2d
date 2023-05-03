using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public bool attack=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            attack=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ronin")
        {
            print("va cham voi ronin");
            if (attack==true)
            {
                Heath heath = collision.gameObject.GetComponent<Heath>();
                heath.TakeDamage(3);
            }
        }
    }

}
