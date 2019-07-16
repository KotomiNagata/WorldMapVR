using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    GameSetting gameSetting;

    //public bool on = false;
    bool one = false;
    

    private void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
        particle.Stop();
    }


    private void Update()
    {
        if(gameSetting.advance)
        {
            if(one)
            {
                particle.Play();
                one = false;
            }
        }
        if(!gameSetting.advance)
        {
            if(!one)
            {
                particle.Stop();
                one = true;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            on = !on;
            one = true;
        }

        if(one)
        {
            if (on)
            {
                particle.Play();
            }
            else
            {
                particle.Stop();
            }
            one = false;
        }*/
    }
}
