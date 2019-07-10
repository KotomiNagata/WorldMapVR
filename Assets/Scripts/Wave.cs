using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public bool isPlaying;
    [SerializeField] ParticleSystem particle;
    /*
    public void Switch()
    {
        if (isPlaying)
        {
            particle.Play(true);
        }
        else
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        isPlaying = !isPlaying;
    }*/


    //private ParticleSystem part;
    public bool on = false;

    private void Start()
    {
        //part = this.GetComponent<ParticleSystem>();
        particle.Stop();
    }


    private void Update()
    {

        if(on)
        {
            particle.Play();
        }else{
            particle.Stop();
        }
    }
}
