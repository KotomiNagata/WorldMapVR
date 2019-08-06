using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetDoor : MonoBehaviour
{
    GameSetting gameSetting;
    public float speed = 1f;
    public string sceneName;
    bool walk = true;

    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
    }

    void Update()
    {
        Vector3 pos = this.transform.position;

        if(gameSetting.advance && walk)
        {
            this.gameObject.transform.Translate( 0, 0, speed);
        }

        if (pos.z > -2f)
        {
            walk = false;
            SceneManager.LoadScene(sceneName);
        }
    }
}
