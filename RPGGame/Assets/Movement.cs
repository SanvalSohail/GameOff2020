using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public Attributes attributes;
    public hpBarScript script;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    //for framerate purposes
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        //rb.velocity = new Vector2(movement.x*2, movement.y*2);
    }

    private void OnTriggerEnter2D(Collider2D other) //upon hitting something
    {
        if (other.tag == "enemy")
        {
            print("attacked");
            attributes.GetComponent<Attributes>().takeDamage(10);
            int maximum = attributes.GetComponent<Attributes>().getMaxHP();
            int hp = attributes.GetComponent<Attributes>().getHP();
            GameObject hpbar = GameObject.FindWithTag("hpBar");
            hpbar.GetComponent<hpBarScript>().changeBar(hp, maximum);
            
        }
        else if (other.tag == "hpPack")
        {
            print("healing");
            attributes.GetComponent<Attributes>().Heal(10);
            Destroy(other.gameObject); 
        }
        else if (other.tag == "xpPack") {
            print("get xp");
            attributes.GetComponent<Attributes>().gainXP(5);
            Destroy(other.gameObject);
        }
        
    }

    void Start() //on startup
    {
            attributes = GetComponent<Attributes>();//gain access to attributes script
       //script = GetComponent<hpBarScript>();//script code
        
    }


    }
