using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObj_PlanetOutSide : MonoBehaviour
{
    float A = 0;

    void Update()
    {
        GameObject door = GameObject.Find("PlanetDoor");
        Vector3 d_pos = door.transform.position;

        Color color = this.gameObject.GetComponent<Renderer>().material.color;
        color.a = A;
        A = 1 - (-d_pos.z / 18f);
        Debug.Log(color.a);

        this.gameObject.GetComponent<Renderer>().material.color = color;

    }
}
