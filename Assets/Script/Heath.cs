using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{

    // Start is called before the first frame update
    public int maxheath = 10;
    int currentHeath;
    void Start()
    {
        currentHeath = maxheath;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        print("mau hien tai la :"+currentHeath);
        if (currentHeath <= 0 )
        {
            die();
        }
    }
  
    void die()
    {
        Destroy(gameObject);
    }
}
