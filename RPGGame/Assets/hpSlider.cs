using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        //Slider slider = GetComponent<Slider>();
        //slider.value = 0.6f;
    }
    public void changeBar(float hp, float maxhp)
    {
        Slider slider = GetComponent<Slider>();
        float ratio = hp / maxhp;
        slider.value = ratio;
        print(ratio);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
