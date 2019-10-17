using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public float time;

    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
