using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationByArray : MonoBehaviour
{
    public GameObject[] array; // これが配列
    public bool looping = true;
    public float AnimationWaitTime = 0.01f;
    public int activeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 子供のゲームオブジェクトの数分だけ配列に入れます
        array = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i ++ ){
            array[i] = gameObject.transform.GetChild(i).gameObject;
        }

        // 最初の一つだけ表示させます
        for (int i = 0; i < array.Length; i++)
        {
            if (i == activeIndex) {
                array[i].SetActive(true);
            }else{
                array[i].SetActive(false);
            }
        }
        StartCoroutine("ChangeActive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeActive()
    {
        // Activeの切り替え
        while ( looping){
            yield return new WaitForSeconds(AnimationWaitTime);
            array[activeIndex].SetActive(false);
            if ( activeIndex == array.Length -1 ){
                activeIndex = 0;
            }else{
                activeIndex++;
            }
            array[activeIndex].SetActive(true);
        }
    }
}
