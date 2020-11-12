using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public Attributes attributes;
    private bool dash = false;
    private float dashTimer = 0;

    //public TMPro health;
    // Start is called before the first frame update

        
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        print(movement.x);
        print(movement.y);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown("space") && dashTimer <= 0)
        {
            dash = true;
        }
        if(dashTimer >= 0) {
            dashTimer -= Time.deltaTime; //decrement
        }
        
    }

    //for framerate purposes
    void FixedUpdate()
    {
        if (dash == true) {
            movement.x *= 7;
            movement.y *= 7;
            dash = false;
            dashTimer = .5f;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position; //mouse position
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //rotation
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other) //upon hitting something
    {
        if (other.tag == "enemy")
        {
            attributes.GetComponent<Attributes>().takeDamage(10);
            
        }
        else if (other.tag == "hpPack")
        {
            attributes.GetComponent<Attributes>().Heal(10);
            Destroy(other.gameObject); 
        }
        else if (other.tag == "xpPack") {
            attributes.GetComponent<Attributes>().gainXP(5);
            Destroy(other.gameObject);
        }
        
    }

    void Start() //on startup
    {
            attributes = GetComponent<Attributes>();
        
    }


    }
