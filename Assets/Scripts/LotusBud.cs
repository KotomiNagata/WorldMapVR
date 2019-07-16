using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusBud : MonoBehaviour
{
    public GameObject lotusBud;       // 子オブジェクトの蕾
    public GameObject lotusBloom;     // 花が咲くアニメーションのObj
    public GameObject lotusFlowerObj; // LotusFlowerをClone生成
    public GameObject lotusParticle;  // パーティクル 
    public bool bloomEnd = false;     // LotusBloomから合図する
    bool seedTrigger = false;         // Seedと連動したか
    bool one = true;                  // クローンを1回のみ生成

    // Update is called once per frame
    void Update()
    {
        // あとでここを「連動」のコードを入れる
        if(Input.GetKeyDown(KeyCode.A) && one)
        {
            seedTrigger = true;
        }

        if(seedTrigger)
        {
            if(one)
            {
                var parent = this.transform;
                Instantiate(lotusBloom, this.transform.position, Quaternion.identity, parent);
                Destroy(lotusBud.gameObject);
                one = false;
            }

        }
        if(bloomEnd)
        {
            Instantiate(lotusFlowerObj, this.transform.position, Quaternion.identity);
            Instantiate(lotusParticle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
