using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTextParent : MonoBehaviour
{
    // Battery_gameに入れてある

    GameSystem system;

    [System.NonSerialized]
    public int numberMiddle;
    [System.NonSerialized]
    public int numberRight;
    [System.NonSerialized]
    public int numberLeft;
    int numberLeave;

    bool numberChange1 = true;
    bool numberChange2 = true;

    [System.NonSerialized]
    public List<int> threeSelectList;  // 三選択を収納
    [System.NonSerialized]
    public int answer;                 // 答えの番号
    [System.NonSerialized]
    public string cityList;            // Switchにてまとめている
    [System.NonSerialized]
    public bool numberMatch;           // 答えが正解かどうか
    bool selectNumberChange = false;

    // 00 = 無地
    // 01 = ア
    // 02 = イ
    // 03 = キ
    // 04 = ク
    // 05 = サ
    // 06 = シ
    // 07 = ス
    // 08 = タ
    // 09 = ト
    // 10 = ナ
    // 11 = ハ
    // 12 = マ
    // 13 = リ
    // 14 = ル
    // 15 = ロ
    // 16 = ン

    void Start()
    {
        system = FindObjectOfType<GameSystem>();

        numberMiddle = 0;
        numberRight = 0;
        numberLeft = 0;

        threeSelectList = new List<int>();
    }


    void Update()
    {
        if(!system.decision)
        {
            OperationScript();
        }

        // クイズ開始時の選択肢表示
        if (system.quizStart)
        {
            if(selectNumberChange && system.selectEnemy)
            {
                cityList = system.enemyName;
                CityAnswerSelect();
                BattertTextSend();
                selectNumberChange = false;
            }
        }
        if(!system.quizStart)
        {
            selectNumberChange = true;
            cityList = "None";
            numberMiddle = 0;
            numberRight = 0;
            numberLeft = 0;
        }
    }

    void OperationScript()
    {
        // 右と入れ替え
        if (system.rightText && !system.leftText)
        {
            if (numberChange1)
            {
                numberLeave = numberMiddle;
                numberMiddle = numberRight;
                numberRight = numberLeave;
                numberChange1 = false;
            }
        }
        if (!system.rightText)
        {
            numberChange1 = true;
        }

        // 左と入れ替え
        if (system.leftText && !system.rightText)
        {
            if (numberChange2)
            {
                numberLeave = numberMiddle;
                numberMiddle = numberLeft;
                numberLeft = numberLeave;
                numberChange2 = false;
            }
        }
        if (!system.leftText)
        {
            numberChange2 = true;
        }
    }

    void BattertTextSend()
    {
        numberLeft = threeSelectList[0];
        numberMiddle = threeSelectList[1];
        numberRight = threeSelectList[2];
    }

    void CityAnswerSelect()
    {
        switch(cityList)
        {
            case "Accra":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(4);
                threeSelectList.Add(7);
                answer = 4;
                break;
            case "Ashgabat":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Asmara":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Asuncion":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(6);
                threeSelectList.Add(7);
                answer = 6;
                break;
            case "AddisAbaba":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 1;
                break;
            case "Apia":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer =1;
                break;
            case "Abuja":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(13);
                answer = 1;
                break;
            case "AbuDhabi":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                answer = 8;
                break;
            case "Amsterdam":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Algiers":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Ankara":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(5);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Anchorage":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(7);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Antananarivo":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(10);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "AndorraLaVella":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Amman":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Islamabad":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                answer = 7;
                break;
            case "Vienna":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Windhoek":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Wellington":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Ulaanbaatar":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Yerevan":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(9);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Oslo":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Ottawa":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(15);
                answer = 8;
                break;
            case "Cairo":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 2;
                break;
            case "Castries":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Kathmandu":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 12;
                break;
            case "Kabul":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Caracas":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                answer = 7;
                break;
            case "Kampala":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Kiev":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(4);
                threeSelectList.Add(7);
                answer = 3;
                break;
            case "Kigali":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Chisinau":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                answer = 10;
                break;
            case "Gitega":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(8);
                answer = 3;
                break;
            case "Quito":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 9;
                break;
            case "Canberra":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 3;
                break;
            case "Kingstown":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "Kingston":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 9;
                break;
            case "Kinshasa":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                answer = 5;
                break;
            case "GuatemalaCity":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 12;
                break;
            case "KualaLumpur":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(9);
                threeSelectList.Add(15);
                answer = 4;
                break;
            case "Kuwait":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Guangzhou":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 6;
                break;
            case "CopperMine":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Conakry":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                answer = 10;
                break;
            case "Copenhagen":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(8);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Saglouc":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 4;
                break;
            case "Zagreb":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                answer = 4;
                break;
            case "Sapporo":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 5;
                break;
            case "Sanaa":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 1;
                break;
            case "Sarajevo":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(7);
                threeSelectList.Add(11);
                answer = 5;
                break;
            case "SanSalvador":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 5;
                break;
            case "Santiago":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 1;
                break;
            case "SantoDomingo":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 9;
                break;
            case "SaoTome":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "SanFrancisco":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(6);
                threeSelectList.Add(8);
                answer = 6;
                break;
            case "SanJose":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 5;
                break;
            case "SanMarino":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                answer = 13;
                break;
            case "Seattle":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 1;
                break;
            case "XianCity":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 6;
                break;
            case "Chicago":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(6);
                threeSelectList.Add(8);
                answer = 6;
                break;
            case "Sydney":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Djibouti":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(6);
                threeSelectList.Add(8);
                answer = 6;
                break;
            case "Jakarta":
                threeSelectList.Clear();
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Shanghai":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Juba":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                answer = 6;
                break;
            case "Georgetown":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(6);
                threeSelectList.Add(7);
                answer = 6;
                break;
            case "Singapore":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Sucre":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "Stockholm":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Suva":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(13);
                answer = 7;
                break;
            case "SriJayaSaldanaPracotte":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                answer = 10;
                break;
            case "Chengdu":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 2;
                break;
            case "St.George’s":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "St.John’s":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Seoul":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(8);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Sophia":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(5);
                threeSelectList.Add(12);
                answer = 1;
                break;
            case "SaltLakeCity":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(4);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "Dakar":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Tashkent":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 6;
                break;
            case "Dhaka":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 8;
                break;
            case "Dublin":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 8;
                break;
            case "Damascus":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 12;
                break;
            case "Tarawa":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 8;
                break;
            case "Tallinn":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 8;
                break;
            case "DarEsSalaam":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "Churchill":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Tunis":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(7);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "Cetinje":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(2);
                threeSelectList.Add(16);
                answer = 2;
                break;
            case "Tirana":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(10);
                threeSelectList.Add(16);
                answer = 10;
                break;
            case "Dili":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 13;
                break;
            case "Thimphu":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(9);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Tegucigalpa":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Tehran":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Denver":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Tokyo":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 3;
                break;
            case "Dushanbe":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 6;
                break;
            case "Doha":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Tbilisi":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                answer = 9;
                break;
            case "Tripoli":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 13;
                break;
            case "Tronto":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(13);
                threeSelectList.Add(15);
                answer =15;
                break;
            case "Nairobi":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Nassau":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                threeSelectList.Add(15);
                answer = 10;
                break;
            case "Niamey":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(15);
                threeSelectList.Add(16);
                answer = 1;
                break;
            case "Nicosia":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                answer = 1;
                break;
            case "NewDelhi":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(10);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "NewYork":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 4;
                break;
            case "Nouakchott":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 1;
                break;
            case "Nuku’alofa":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Nur-Sultan":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                answer = 7;
                break;
            case "Naypyidaw":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Perth":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 7;
                break;
            case "Hakata":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 8;
                break;
            case "Baku":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(8);
                threeSelectList.Add(10);
                answer = 4;
                break;
            case "Baghdad":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "Basseterre":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Vatican":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "PanamaCity":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(14);
                threeSelectList.Add(15);
                answer = 12;
                break;
            case "Hanoi":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 2;
                break;
            case "Havana":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                answer = 10;
                break;
            case "Gaborone":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Bamako":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 12;
                break;
            case "Paramaribo":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Harare":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(11);
                threeSelectList.Add(12);
                answer = 11;
                break;
            case "Paris":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Palikir":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 3;
                break;
            case "Khartoum":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "Bangui":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 3;
                break;
            case "Vancouver":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                answer = 4;
                break;
            case "Bangkok":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "Bansur":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "BandarSeriBegawan":
                threeSelectList.Clear();
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                threeSelectList.Add(15);
                answer = 13;
                break;
            case "Vientiane":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Victoria":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 9;
                break;
            case "Bissau":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(15);
                answer = 5;
                break;
            case "Bishkek":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(6);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "Houston":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 9;
                break;
            case "Pyongyang":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Vilnius":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 13;
                break;
            case "Vaduz":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 9;
                break;
            case "BuenosAires":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 1;
                break;
            case "FortMackenzie":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(7);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Bucharest":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "Budapest":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "Funafuti":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                threeSelectList.Add(15);
                answer = 10;
                break;
            case "PhnomPenh":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Praia":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                answer = 1;
                break;
            case "Brazzaville":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 5;
                break;
            case "Brasilia":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                answer = 1;
                break;
            case "Bratislava":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(8);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "Prague":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(11);
                threeSelectList.Add(12);
                answer = 11;
                break;
            case "Freetown":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 8;
                break;
            case "Brisbane":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(7);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "BridgeTown":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 6;
                break;
            case "Brussels":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "SourceOfWuling":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "PrudhoeBay":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 2;
                break;
            case "Pretoria":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 9;
                break;
            case "HayRiver":
                threeSelectList.Clear();
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 13;
                break;
            case "Beirut":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(6);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Beijing":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                answer = 3;
                break;
            case "Helsinki":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 3;
                break;
            case "Belmopan":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Berlin":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(7);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Bern":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "PortOfSpain":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 2;
                break;
            case "PortVila":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "PortMoresby":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(7);
                threeSelectList.Add(16);
                answer = 7;
                break;
            case "PortLouis":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(12);
                threeSelectList.Add(16);
                answer = 2;
                break;
            case "Bogota":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 8;
                break;
            case "Boston":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(15);
                answer = 9;
                break;
            case "Honiara":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(4);
                threeSelectList.Add(11);
                answer = 1;
                break;
            case "Port-au-Prince":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Portonovo":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                answer = 9;
                break;
            case "Majuro":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Muscat":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Maseru":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Madrid":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Manama":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(10);
                threeSelectList.Add(16);
                answer = 10;
                break;
            case "Managua":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                answer = 10;
                break;
            case "Manila":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Maputo":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Malabo":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 12;
                break;
            case "Markyok":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Male":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                answer = 12;
                break;
            case "Minsk":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(15);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "Mbabane":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(11);
                answer = 11;
                break;
            case "MexicoCity":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(8);
                threeSelectList.Add(16);
                answer = 3;
                break;
            case "Melbourne":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 14;
                break;
            case "Mogadishu":
                threeSelectList.Clear();
                threeSelectList.Add(3);
                threeSelectList.Add(6);
                threeSelectList.Add(13);
                answer = 6;
                break;
            case "Moscow":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(4);
                threeSelectList.Add(8);
                answer = 4;
                break;
            case "Monaco":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(15);
                threeSelectList.Add(16);
                answer = 10;
                break;
            case "Moroni":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Montevideo":
                threeSelectList.Clear();
                threeSelectList.Add(10);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Monrovia":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(6);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Yaounde":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Yamoussoukro":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Yaren":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Rabat":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(9);
                threeSelectList.Add(16);
                answer = 9;
                break;
            case "Libreville":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Riga":
                threeSelectList.Clear();
                threeSelectList.Add(11);
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                answer = 13;
                break;
            case "Lisbon":
                threeSelectList.Clear();
                threeSelectList.Add(6);
                threeSelectList.Add(7);
                threeSelectList.Add(9);
                answer = 7;
                break;
            case "LysolRoute":
                threeSelectList.Clear();
                threeSelectList.Add(5);
                threeSelectList.Add(9);
                threeSelectList.Add(12);
                answer = 9;
                break;
            case "Lima":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 12;
                break;
            case "Riyadh":
                threeSelectList.Clear();
                threeSelectList.Add(12);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 13;
                break;
            case "Ljubljana":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(5);
                threeSelectList.Add(10);
                answer = 10;
                break;
            case "Lilongwe":
                threeSelectList.Clear();
                threeSelectList.Add(9);
                threeSelectList.Add(13);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Luanda":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(8);
                threeSelectList.Add(14);
                answer = 1;
                break;
            case "Luxembourg":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(4);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "Lusaka":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                answer = 5;
                break;
            case "Reykjavik":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 4;
                break;
            case "LosAngeles":
                threeSelectList.Clear();
                threeSelectList.Add(13);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Roseau":
                threeSelectList.Clear();
                threeSelectList.Add(11);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "Lome":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(12);
                threeSelectList.Add(15);
                answer = 15;
                break;
            case "London":
                threeSelectList.Clear();
                threeSelectList.Add(7);
                threeSelectList.Add(13);
                threeSelectList.Add(16);
                answer = 16;
                break;
            case "Ouagadougou":
                threeSelectList.Clear();
                threeSelectList.Add(4);
                threeSelectList.Add(5);
                threeSelectList.Add(8);
                answer = 4;
                break;
            case "WashingtonD.C.":
                threeSelectList.Clear();
                threeSelectList.Add(8);
                threeSelectList.Add(9);
                threeSelectList.Add(14);
                answer = 9;
                break;
            case "Warsaw":
                threeSelectList.Clear();
                threeSelectList.Add(2);
                threeSelectList.Add(14);
                threeSelectList.Add(16);
                answer = 14;
                break;
            case "Ndjamena":
                threeSelectList.Clear();
                threeSelectList.Add(1);
                threeSelectList.Add(4);
                threeSelectList.Add(16);
                answer = 16;
                break;
        }
    }
}
