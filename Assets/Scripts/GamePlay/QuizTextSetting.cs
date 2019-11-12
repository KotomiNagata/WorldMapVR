using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTextSetting : MonoBehaviour
{
    float posY = 0.2f;
    float rotX = 60f;
    float size = 0.2f;

    void Start()
    {
        this.transform.position = new Vector3(0, posY, 0);
        this.transform.localEulerAngles = new Vector3(rotX, 0, 0);
        this.transform.localScale = new Vector3(size, size, size);
    }
}
