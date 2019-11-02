using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizText : MonoBehaviour
{

    // 都市名などの文字まとめ

    public enum AnimType
    {
        QUIZ,
        ANSWER
    }
    public AnimType animType;
    GameSystem system;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
    }

    void Update()
    {
        if(animType == AnimType.QUIZ)
        {
            QuizScript();
        }

        if(animType == AnimType.ANSWER)
        {
            AnswerScript();
        }
    }

    void QuizScript()
    {
        if(system.quizEnd)
        {
            Destroy(this.gameObject);
        }
    }

    void AnswerScript()
    {
        if(!system.quizEnd)
        {
            Destroy(this.gameObject);
        }
    }
}
