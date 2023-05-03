using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    GameObject gameObject1;
    Vector3 Vector_dir;
    float plus=0;
    GameObject Prefabs;
    Heath Heath;
    private void Start()
    {
         gameObject1=GameObject.FindWithTag("Player");
         transform.position = transform.position + new Vector3(plus, 0, 0);
         huongdan();
    }

    void Update()
    {
        transform.Translate(Vector_dir  * speed * Time.deltaTime);
         
        if (transform.position.x > 6.2f|| transform.position.x<(-6f))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Va cham giua " + gameObject.name + " va " + coll.gameObject.name);

        if (coll.gameObject.GetComponent<Heath>() != null)
        {

            Heath heath = coll.gameObject.GetComponent<Heath>();
            heath.TakeDamage(3);

        }
    }
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Debug.Log("Va cham giua " + gameObject.name + " va " + coll.gameObject.name);

    //    if (coll.gameObject.GetComponent<Heath>() != null)
    //    {
            
    //            Heath heath = coll.gameObject.GetComponent<Heath>();
    //            heath.TakeDamage(3);
           
    //    }
    //}
    
    void huongdan()
    {
        if (gameObject1.transform.localScale.x > 0)
        {
            this.Vector_dir = Vector3.right;
            plus = 0.5f;
        }
        if(gameObject1.transform.localScale.x < 0)
        {
            this.Vector_dir = Vector3.left;
            plus = -0.5f;
        }
    }
    
}
