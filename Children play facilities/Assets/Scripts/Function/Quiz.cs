using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Tooltip("문제가 무엇인지 적혀 있어야한다")]
    public Text quiz_presentbox;

    [Tooltip("선택지 텍스트")]
    public Text[] select_textbox = new Text[3];

    [Tooltip("선택지 버튼")]
    public Button[] select_btn = new Button[3];

    public List<Quizs> quiz_list = new List<Quizs>();

    public Quizs[] send_quiz = new Quizs[4];

    public Sprite select_sprite;
    //다른 페이지로 이동하면 정보를 지운다

    private int curr_quiz_num; // 현재 문제가 몇번째 문제인가?
    private Quizs curr_quiz;

    int ask = 0;

    private void Start()
    {
        //for(int i = 0;  
        //Correct_btn[]
        QuizSet();
    }

    public void QuizSet()
    {

        QuizSend();
    }

    public void QuizSend()
    {
        ask++;
        //만약 더 이상 문제가 없다면 
        if (ask > 3)
        {
            MainCtrl.instance.pagectrl.PageAbleSet(MainCtrl.instance.pages.Count);
        }
        else
        {
            curr_quiz = send_quiz[ask - 1];
            QuizVisualShow(ask-1);
        }
    }

    public void QuizVisualShow(int num)
    {
        quiz_presentbox.text = send_quiz[num].quiz_describe;
        for (int i = 0; i < select_textbox.Length; i++)
        {
            select_textbox[i].text = send_quiz[num].standout_element[i];
            try
            {
                select_btn[i].onClick.RemoveListener(Wrong);
            }
            catch
            {
                select_btn[i].onClick.RemoveListener(Correct);
            }
            if( i == curr_quiz.correct_num)
            {
                select_btn[i].onClick.AddListener(Correct);
            }
            else
            {
                select_btn[i].onClick.AddListener(Wrong);
            }
        }
    }

    public void Wrong()
    {
        // 틀림 비프음을 출력
    }

    public void Correct()
    {
        // 맞음 비프음을 출력
        QuizSend();
    }
}

[System.Serializable]
public struct Quizs
{
    public string quiz_describe;
    public string[] standout_element;
    [Range(1,4)]
    public int correct_num;
}