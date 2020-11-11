using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelText : MonoBehaviour
{
    //TextMeshProUGUI textmeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //textmeshPro = GetComponent<TextMeshProUGUI>();
        //textmeshPro.text = "Player Level: 1";
    }

    public void levelUp(int level)
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "Player Level: " + level.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
