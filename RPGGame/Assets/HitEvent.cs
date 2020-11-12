using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (other.tag == "bullet") {
            hp -= 10;
            SceneManager.LoadScene(0);
        }

        if (hp <= 0) {   //this enemy died
            Destroy(gameObject);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Attributes>().gainXP(5);
        }
        
    }
    void Update()
    {
        
    }
}
