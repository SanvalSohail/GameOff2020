using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBarScript : MonoBehaviour
{
    Renderer rend;
    public Transform bar;
    private Vector3 scaleChange, positionChange;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
        gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Particles/Standard Unlit");
        /*
        scaleChange = new Vector3(-2f, 0f, 0f);
        float a = (float)(2 / 2);
        float b = (float)(2 - a);
        positionChange = new Vector3(-b, 0f, 0f);
        bar.transform.localScale += scaleChange;
        bar.transform.position += positionChange;
        */
    }


    public void changeBar(int hp, int maxhp)
    {
        float ratio = (float)hp / (float)maxhp;
        float barLength = ratio * 4;
        float changeAmount = 4 - barLength;
        scaleChange = new Vector3(-changeAmount, 0f, 0f);
        float halvesLength = (float)(barLength / 2f);
        float shiftAmount = (float)(2 - halvesLength);
        positionChange = new Vector3(-shiftAmount, 0f, 0f);
        bar.transform.localScale = new Vector3(4f, 0.8070798f, 1f);//reset
        bar.transform.position = new Vector3(10f, 4.2f, 0f);//reset

        bar.transform.localScale += scaleChange;
        bar.transform.position += positionChange;
    }

    void Update()
    {

    }
}
