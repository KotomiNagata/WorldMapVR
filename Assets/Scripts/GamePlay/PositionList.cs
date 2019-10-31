using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionList : MonoBehaviour
{
    TimeAttack attack;

    // 乱数
    [System.NonSerialized]
    public bool reset = false;
    bool retry = false;
    int start = 0;  // 最初の場所名の数字から
    int end = 219;    // 最後の場所名の数字+1まで
    int i;
    [System.NonSerialized]
    public string posResult; // ランダムの結果、出現させる場所名
    [System.NonSerialized]
    public bool cloneOK = false;  // クローンを１回作るようにする
    float time;
    bool gamePlay = false;

    // リスト
    [System.NonSerialized]
    public List<string> FlowerList;  // 花が咲いた場所のリスト
    string[] posName =  // 全ての場所名
    {
        "Accra","Ashgabat","Asmara","Asuncion","AddisAbaba",
        "Apia","Abuja","AbuDhabi","Amsterdam","Algiers",
        "Ankara","Anchorage","Antananarivo","AndorraLaVella","Amman",
        "Islamabad","Vienna","Windhoek","Wellington","Ulaanbaatar",
        "Yerevan","Oslo","Ottawa","Cairo","Castries",
        "Kathmandu","Kabul","Caracas","Kampala","Kiev",
        "Kigali","Chisinau","Gitega","Quito","Canberra",
        "Kingstown","Kingston","Kinshasa","GuatemalaCity","KualaLumpur",
        "Kuwait","Guangzhou","CopperMine","Conakry","Copenhagen",
        "Saglouc","Zagreb","Sapporo","Sanaa","Sarajevo",
        "SanSalvador","Santiago","SantoDomingo","SaoTome","SanFrancisco",
        "SanJose","SanJose","SanMarino","Seattle","XianCity","Chicago",
        "Sydney","Djibouti","Jakarta","Shanghai","Juba",
        "Georgetown","Singapore","Sucre","Stockholm","Suva",
        "SriJayaSaldanaPracotte","Chengdu","St.George’s","St.John’s","Seoul",
        "Sophia","SaltLakeCity","Dakar","Tashkent","Dhaka",
        "Dublin","Damascus","Tarawa","Tallinn","DarEsSalaam",
        "Churchill","Tunis","Cetinje","Tirana","Dili",
        "Thimphu","Tegucigalpa","Tehran","Denver","Tokyo",
        "Dushanbe","Doha","Tbilisi","Tripoli","Tronto",
        "Nairobi","Nassau","Niamey","Nicosia","NewDelhi",
        "NewYork","Nouakchott","Nuku’alofa","Nur-Sultan","Naypyidaw",
        "Perth","Hakata","Baku","Baghdad","Basseterre",
        "Vatican","PanamaCity","Hanoi","Havana","Gaborone",
        "Bamako","Paramaribo","Harare","Paris","Palikir",
        "Khartoum","Bangui","Vancouver","Bangkok","Bansur",
        "BandarSeriBegawan","Vientiane","Victoria","Bissau","Bishkek",
        "Houston","Pyongyang","Vilnius","Vaduz","BuenosAires",
        "FortMackenzie","Bucharest","Budapest","Funafuti","PhnomPenh",
        "Praia","Brazzaville","Brasilia","Bratislava","Prague",
        "Freetown","Brisbane","BridgeTown","Brussels","SourceOfWuling",
        "PrudhoeBay","Pretoria","HayRiver","Beirut","Beijing",
        "Helsinki","Belmopan","Berlin","Bern","PortOfSpain",
        "PortVila","PortMoresby","PortLouis","Bogota","Boston",
        "Honiara","Port-au-Prince","Portonovo","Majuro","Muscat",
        "Maseru","Madrid","Manama","Managua","Manila",
        "Maputo","Malabo","Markyok","Male","Minsk",
        "Mbabane","MexicoCity","Melbourne","Mogadishu","Moscow",
        "Monaco","Moroni","Montevideo","Monrovia","Yaounde",
        "Yamoussoukro","Yaren","Rabat","Libreville","Riga",
        "Lisbon","LysolRoute","Lima","Riyadh","Ljubljana",
        "Lilongwe","Luanda","Luxembourg","Lusaka","Reykjavik",
        "LosAngeles","Roseau","Lome","London","Ouagadougou",
        "WashingtonD.C.","Warsaw","Ndjamena"
    };

    // EnemyPositionからFlowerListを追加
    [System.NonSerialized]
    public bool flowerPlus = false;
    [System.NonSerialized]
    public string flowerName;

    void Start()
    {
        attack = FindObjectOfType<TimeAttack>();

        // 敵を倒した場所をリスト化
        FlowerList = new List<string>();
    }

    void Update()
    {
        if (!attack.startClone)
        {
            gamePlay = true;

            if(!attack.R2clone)
            {
                gamePlay = false;
            }
        }

        // 約１秒ごとに処理
        time -= Time.deltaTime;
        if(time <= 0.0f && gamePlay)
        {
            reset = true;
            time = 1.0f;
        }

        // ランダムに敵を出現
        if (reset)
        {
            RandomSelectPosition();
            reset = false;
        }else{
            cloneOK = false;
        }
        if(retry)
        {
            reset = true;
            retry = false;
        }

        // 花リストに追加
        if(flowerPlus)
        {
            FlowerList.Add(flowerName);
            flowerPlus = false;
        }
    }

    // 敵を出現させる場所をランダムに選択
    void RandomSelectPosition()
    {
        i = Random.Range(start, end);
        posResult = posName[i];

        if (FlowerList.Contains(posResult))
        {
            retry = true;
        }
        else
        {
            cloneOK = true;
        }
    }


}
