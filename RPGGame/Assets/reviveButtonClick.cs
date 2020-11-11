using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reviveButtonClick : MonoBehaviour
{
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        print("i have clicked the button");
        SceneManager.LoadScene("second");
       // attributes.GetComponent<Attributes>().refillHP();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
