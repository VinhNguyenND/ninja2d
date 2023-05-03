using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int Airstate=0;//duoi dat
    public bool Run = false;//chay
    public int Idle=1;//dung
    public int Attack=0;//tan cong
    public bool right=false;//di chuyen ben phai;
    public bool Unground = true;
    //
    public float vantocdichuyen=4f;
    public float speed;
    public float height_jump = 5f;
    bool isLive = true;
    Animator animator;
    Rigidbody2D rg2;
    GameObject GameObject_p;
    //
    GameObject Attack_area=default;
     bool attack1 = false;
    void Start()
    {
       rg2 =GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLive)
        {
            tranfer();
            direction_by_key();
            Attack_by_key();
        }
        animator.SetBool("Run", Run);
        animator.SetInteger("Airstate", Airstate); 
        animator.SetInteger("Idle", Idle);
        animator.SetInteger("Attack", Attack);
       // animator.SetBool("Unground", Unground);
    }
   
    void tranfer()
    {
        float phim_di_chuyen = UnityEngine.Input.GetAxis("Horizontal");
        speed = Mathf.Abs(phim_di_chuyen * vantocdichuyen);
        rg2.velocity = new Vector2(speed * phim_di_chuyen, rg2.velocity.y);
      
        if (phim_di_chuyen != 0)
        {
            this.Run = true;
        }
        if (phim_di_chuyen > 0 && right)
        {
            
            indirection();
          
        } 
        if (phim_di_chuyen < 0 && !right)
        {
            
            indirection();
         
        }
        if (phim_di_chuyen == 0)
        {
            this.Run = false;
        }
        //print(phim_di_chuyen);
    }
    void indirection()//chuyen huong
    {
        right = !right;
        Vector2 huongquay = transform.localScale;
        huongquay.x *= -1;
        transform.localScale = huongquay;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "ground" )
        {
            this.Airstate = 0;
          
        }
    }
  
    void direction_by_key()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&this.Airstate==0)//nhay
        {
            this.Airstate = 1;
            rg2.AddForce((Vector2.up) * this.height_jump);
        }
        if (this.Airstate>=1&& rg2.velocity.y<0)
        {
            this.Airstate = 2;
        }

       if(rg2.velocity.y < 0)
        {
            this.Airstate = 2;
        }
        
    }
    public void DesObject()
    {
        Destroy(GameObject_p);
    }
    void Attack_by_key()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.Run = false;
            this.Idle = 1;
            this.Attack = 1;
        }
        if (this.Attack == 1 && Input.GetKeyUp(KeyCode.Q))
        {
            this.Attack = 0;
            this.Idle = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.Run = false;
            this.Idle = 1;
            this.Attack = 2;
            SpawnObject();
        }
        if (this.Attack == 2 &&  Input.GetKeyUp(KeyCode.W))
        {
            this.Attack = 0;
            this.Idle = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
         {
            this.Run = false;
            this.Idle = 1;
            this.Attack = 3;
         }
        if (this.Attack == 3  && Input.GetKeyUp(KeyCode.E))
        {
            this.Attack = 0;
            this.Idle = 0;
        }
      
       

    }
    void SpawnObject()
    {
        GameObject game = (GameObject)Resources.Load("Prefabs/Ninja_Shuriken1_0");
        Instantiate(game,transform.GetChild(1).gameObject.transform.position, Quaternion.identity);
    }


}
