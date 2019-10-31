using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRecord : MonoBehaviour
{

    public GameObject objScore;
    public GameObject objEnemy;
    public GameObject objBonus;
    public GameObject objTotalScore;
    public GameObject objLankingList01;
    public GameObject objLankingList02;
    public GameObject objLankingNo1;
    public GameObject objLankingNo2;
    public GameObject objLankingNo3;
    public GameObject objLankingNo4;
    public GameObject objLankingNo5;
    public GameObject objLankingNone;

    [System.NonSerialized]
    public int intScore;
    [System.NonSerialized]
    public int intBonus;
    [System.NonSerialized]
    public float intEnemy;
    [System.NonSerialized]
    public int intTotalScore;

    GameObject myLankingNumber; // 自分のランキング
    GameObject lankParent;      // ランキング
    GameObject lankPos;         // ランキングを置く場所
    bool scoreCreat = true;
    bool enemyCreat = true;
    bool bonusCreat = true;
    bool totalScoreCreat = true;
    bool lanking01Creat = true;
    bool lanking02Creat = true;
    bool lanking03Creat = true;
    //int lankingNo1 = 5000;

    // 作動開始
    [System.NonSerialized]
    public bool calculation = false; // 結果発表についての計算開始
    [System.NonSerialized]
    public bool resultAnime = false; // 結果発表のアニメーション 

    // Bonus計算
    float BF = 1f;
    int BI;

    // Lanking
    [System.NonSerialized]
    public List<int> nowLanking;
    int lankingNo1 = 5000;
    int lankingNo2 = 4000;
    int lankingNo3 = 3000;
    int lankingNo4 = 2000;
    int lankingNo5 = 1000;
    bool calEnd = false;   // 計算終了合図

    void Awake()
    {
        // シーン移行しても消えない
        DontDestroyOnLoad(this);
    }

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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    void ResultNumberic()
    {
        lankParent = GameObject.FindGameObjectWithTag("LankingParent");
        lankPos = GameObject.FindGameObjectWithTag("LankingPosition");

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
        if (lankingNo1 < intTotalScore && !calEnd)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = lankingNo2;
            lankingNo2 = lankingNo1;
            lankingNo1 = intTotalScore;
            myLankingNumber = objLankingNo1;
            calEnd = true;
        }

        // ２位
        if (intTotalScore == lankingNo1 && !calEnd ||
            lankingNo2 < intTotalScore && intTotalScore < lankingNo1 && !calEnd)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = lankingNo2;
            lankingNo2 = intTotalScore;
            myLankingNumber = objLankingNo2;
            calEnd = true;
        }

        // ３位
        if (intTotalScore == lankingNo2 && !calEnd ||
           lankingNo3 < intTotalScore && intTotalScore < lankingNo2 && !calEnd)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = lankingNo3;
            lankingNo3 = intTotalScore;
            myLankingNumber = objLankingNo3;
            calEnd = true;
        }

        // ４位
        if (intTotalScore == lankingNo3 && !calEnd ||
           lankingNo4 < intTotalScore && intTotalScore < lankingNo3 && !calEnd)
        {
            lankingNo5 = lankingNo4;
            lankingNo4 = intTotalScore;
            myLankingNumber = objLankingNo4;
            calEnd = true;
        }

        // ５位
        if (intTotalScore == lankingNo4 && !calEnd ||
            intTotalScore == lankingNo5 && !calEnd ||
           lankingNo5 < intTotalScore && intTotalScore < lankingNo4 && !calEnd)
        {
            lankingNo5 = intTotalScore;
            myLankingNumber = objLankingNo5;
            calEnd = true;
        }

        // 圏外
        if (intTotalScore < lankingNo5 && !calEnd)
        {
            myLankingNumber = objLankingNone;
            calEnd = true;
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
            var parent = lankParent.transform;
            Instantiate(objScore, parent);
            scoreCreat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if(enemyCreat)
        {
            var parent = lankParent.transform;
            Instantiate(objEnemy, parent);
            enemyCreat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if(bonusCreat)
        {
            var parent = lankParent.transform;
            Instantiate(objBonus, parent);
            bonusCreat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if(totalScoreCreat)
        {
            var parent = lankParent.transform;
            Instantiate(objTotalScore, parent);
            totalScoreCreat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if(lanking01Creat)
        {
            var parent = lankParent.transform;
            Instantiate(objLankingList01, parent);
            lanking01Creat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if (lanking02Creat)
        {
            var parent = lankParent.transform;
            Instantiate(objLankingList02, parent);
            lanking02Creat = false;
        }

        yield return new WaitForSeconds(0.5f);

        if(lanking03Creat)
        {
            var parent = lankPos.transform;
            Instantiate(myLankingNumber,parent);
            lanking03Creat = false;
        }

        resultAnime = false;
    }

    // ゲーム終了
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}
