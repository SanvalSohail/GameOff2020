using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DungeonControl : MonoBehaviour
{

    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Loading level with build index
            SceneManager.LoadScene(index);

            //Loading level with scene name
            //SceneManager.LoadScene(levelName);

            //Restart 1v1
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
