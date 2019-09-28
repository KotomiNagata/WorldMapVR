using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Sea : MonoBehaviour
{

    public float AnimationWaitTime = 0.01f;
    public GameObject nextAnimationObject;

    void Start()
    {
        StartCoroutine("CloneMake");
    }

    /*
    void Update()
    {

    }*/

    private IEnumerator CloneMake()
    {
        yield return new WaitForSeconds(AnimationWaitTime);
        Instantiate(nextAnimationObject);
        Destroy(this.gameObject);
    }

}
