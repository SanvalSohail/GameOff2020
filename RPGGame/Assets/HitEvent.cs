using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) //upon hitting something
    {
        print("igothit");
        if (other.tag == "bullet") {
            hp -= 10;
        }

        if (hp <= 0) {
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        
    }
}
