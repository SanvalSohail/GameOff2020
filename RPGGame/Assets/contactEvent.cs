using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //upon hitting something
    {
        if (other.tag == "enemy") //if it hits enemy, the bullet is destroyed
        {
            Destroy(gameObject);
        }
       

    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }


}
