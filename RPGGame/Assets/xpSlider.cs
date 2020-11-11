using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Slider slider = GetComponent<Slider>();
        //slider.value = 0.6f;
    }
    public void changeBar(float xp, float maxxp)
    {
        Slider slider = GetComponent<Slider>();
        float ratio = xp / maxxp;
        slider.value = ratio;
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
