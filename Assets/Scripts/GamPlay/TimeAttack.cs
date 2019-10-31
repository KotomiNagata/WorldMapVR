using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    public GameObject G_three;
    public GameObject G_two;
    public GameObject G_one;
    public GameObject R_three;
    public GameObject R_two;
    public GameObject R_one;
    public GameObject Text_start;
    public GameObject Text_finish;
    public GameObject Music01; // カウントダウン音
    public GameObject Music02; // Start音
    public GameObject Music03; // Finish音

    [System.NonSerialized]
    public bool G3clone = true;
    [System.NonSerialized]
    public bool G2clone = true;
    [System.NonSerialized]
    public bool G1clone = true;
    [System.NonSerialized]
    public bool R3clone = true;
    [System.NonSerialized]
    public bool R2clone = true;
    [System.NonSerialized]
    public bool R1clone = true;
    [System.NonSerialized]
    public bool startClone = true;
    [System.NonSerialized]
    public bool finishClone = true;

    float time = 65f;

    void Start()
    {

    }


    void Update()
    {
        //StartCoroutine("GameFlow");

        this.time -= Time.deltaTime;

        if (time < 63)
        {
            if (G3clone)
            {
                Instantiate(G_three);
                Instantiate(Music01);
                G3clone = false;
            }
        }
        if (time < 62)
        {
            if (G2clone)
            {
                Instantiate(G_two);
                Instantiate(Music01);
                G2clone = false;
            }
        }
        if (time < 61)
        {
            if (G1clone)
            {
                Instantiate(G_one);
                Instantiate(Music01);
                G1clone = false;
            }
        }
        if (time < 60)
        {
            if (startClone)
            {
                Instantiate(Text_start);
                Instantiate(Music02);
                startClone = false;
            }
        }
        if (time < 3)
        {
            if (R3clone)
            {
                Instantiate(R_three);
                R3clone = false;
            }
        }
        if (time < 2)
        {
            if (R2clone)
            {
                Instantiate(R_two);
                R2clone = false;
            }
        }
        if (time < 1)
        {
            if (R1clone)
            {
                Instantiate(R_one);
                R1clone = false;
            }
        }
        if (time < 0)
        {
            if (finishClone)
            {
                Instantiate(Text_finish);
                Instantiate(Music03);
                finishClone = false;
            }
        }
    }
}
