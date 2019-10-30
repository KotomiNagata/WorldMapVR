using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Map : MonoBehaviour
{
    FadeObject fade;
    public GameObject fadeInObj;
    public string sceneName;
    bool creatObj = true;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0.1f, 0));

        if(Input.GetKey("joystick button 17") && creatObj)
        {
            Instantiate(fadeInObj);
            fade = FindObjectOfType<FadeObject>();
            fade.nextSceneName = sceneName;
            creatObj = false;
        }
    }
}
