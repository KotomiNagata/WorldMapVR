using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRecord : MonoBehaviour
{

    GameScore gameScore;

    public GameObject objScore;
    public GameObject objEnemy;
    public GameObject objBonus;
    public GameObject objTotalScore;
    public GameObject objLankingList;
    public GameObject objLankingNo1;
    public GameObject objLankingNo2;
    public GameObject objLankingNo3;
    public GameObject objLankingNo4;
    public GameObject objLankingNo5;
    public GameObject objLankingNone;

    public int intScore;
    public int intBonus;
    public float intEnemy;
    public int intTotalScore;

    GameObject myLankingNumber; // 自分のランキング
    bool scoreCreat = true;
    bool enemyCreat = true;
    bool bonusCreat = true;
    bool totalScoreCreat = true;
    bool lanking01Creat = true;
    bool lanking02Creat = true;
    //int lankingNo1 = 5000;

    // 作動開始
    public bool calculation = false; // 結果発表についての計算開始
    public bool resultAnime = false; // 結果発表のアニメーション 

    // Bonus計算
    float BF = 1f;
    int BI;

    // Lanking
    public List<int> nowLanking;
    int lankingNo1 = 5000;
    int lankingNo2 = 4000;
    int lankingNo3 = 3000;
    int lankingNo4 = 2000;
    int lankingNo5 = 1000;

    void Start()
    {
        nowLanking = new List<int>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "3_Result")
        {
            if(calculation)
            {
                ResultNumberic();
            }
            if(resultAnime)
            {
                StartCoroutine("ResultAnime");
            }
        }
    }

    void ResultNumberic()
    {
        // Bonus計算
        BF = intEnemy / 218f * 100f;
        BF = Mathf.Floor(BF);
        BF = BF * 100f;
        BI = (int)BF;
        intBonus = BI;

        // TotalScore計算
        intTotalScore = intScore + intBonus;

        LankingChange();

        calculation = false;
    }

    void LankingChange()
    {
        nowLanking.Clear();

        // １位
        if (lankingNo1 < intTotalScore)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = lankingNo2;
            lankingNo2 = lankingNo1;
            lankingNo1 = intTotalScore;
            myLankingNumber = objLankingNo1;
        }

        // ２位
        if (intTotalScore == lankingNo1 ||
            lankingNo2 < intTotalScore && intTotalScore < lankingNo1)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = lankingNo2;
            lankingNo2 = intTotalScore;
            myLankingNumber = objLankingNo2;
        }

        // ３位
        if (intTotalScore == lankingNo2 ||
           lankingNo3 < intTotalScore && intTotalScore < lankingNo2)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = intTotalScore;
            myLankingNumber = objLankingNo3;
        }

        // ４位
        if (intTotalScore == lankingNo3 ||
           lankingNo4 < intTotalScore && intTotalScore < lankingNo3)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = intTotalScore;
            myLankingNumber = objLankingNo4;
        }

        // ５位
        if (intTotalScore == lankingNo4 ||
            intTotalScore == lankingNo5 ||
           lankingNo5 < intTotalScore && intTotalScore < lankingNo4)
        {
            lankingNo5 = intTotalScore;
            myLankingNumber = objLankingNo5;
        }

        // 圏外
        if (intTotalScore < lankingNo5)
        {
            myLankingNumber = objLankingNone;
        }

        nowLanking.Add(lankingNo1);
        nowLanking.Add(lankingNo2);
        nowLanking.Add(lankingNo3);
        nowLanking.Add(lankingNo4);
        nowLanking.Add(lankingNo5);
    }

    private IEnumerator ResultAnime()
    {
        if(scoreCreat)
        {
            Instantiate(objScore);
            scoreCreat = false;
        }

        yield return new WaitForSeconds(1f);

        if(enemyCreat)
        {
            Instantiate(objEnemy);
            enemyCreat = false;
        }

        yield return new WaitForSeconds(1f);

        if(bonusCreat)
        {
            Instantiate(objBonus);
            bonusCreat = false;
        }

        yield return new WaitForSeconds(1f);

        if(totalScoreCreat)
        {
            Instantiate(objTotalScore);
            totalScoreCreat = false;
        }

        yield return new WaitForSeconds(1f);

        if(lanking01Creat)
        {
            Instantiate(objLankingList);
            lanking01Creat = false;
        }

        yield return new WaitForSeconds(1f);

        if(lanking02Creat)
        {
            Instantiate(myLankingNumber);
            lanking02Creat = false;
        }

        resultAnime = false;
    }
}
