using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Attributes attributes;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //for framerate purposes
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //rb.velocity = new Vector2(movement.x*2, movement.y*2);
    }

    private void OnTriggerEnter2D(Collider2D other) //upon hitting something
    {
        if (other.tag == "enemy")
        {
            print("attacked");
            attributes.GetComponent<Attributes>().takeDamage(10);
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
        
    }


    }
