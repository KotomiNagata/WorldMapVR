using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusParticle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Playing");
    }

    private IEnumerator Playing()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
