using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationByArray : MonoBehaviour
{
    // これでアニメーションのタイプを定義します
    public enum AnimType{
        ONCE,
        LOOP
    }

    public GameObject[] array; // これが配列
    public bool looping = true;
    public AnimType animType = AnimType.ONCE; // 一回だけ動くのをデフォルトにします
    public float AnimationWaitTime = 0.01f;
    public int activeIndex = 0;
    public GameObject cloneObj;

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
        // アニメーションのタイプで切り替えます
        if ( animType == AnimType.LOOP){
            StartCoroutine("ChangeActive");
        }else if ( animType == AnimType.ONCE){
            StartCoroutine("ChangeActiveOnce");
        }

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

    // 配列の数だけ切り替えて終了します
    private IEnumerator ChangeActiveOnce()
    {
        // Activeの切り替え
        // 最後から一つ前で終了させて最後を残す
        for (int i = 0; i < array.Length -1 ; i ++ )
        {
            yield return new WaitForSeconds(AnimationWaitTime);
            array[activeIndex].SetActive(false);

            activeIndex++;
            array[activeIndex].SetActive(true);
        }
    }
}
