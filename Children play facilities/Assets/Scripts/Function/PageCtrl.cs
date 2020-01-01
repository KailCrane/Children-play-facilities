using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCtrl : MonoBehaviour
{
    private int curr_page_amout;
    private int total_page_amout;

    public Text total_page_textbox;
    public Text curr_page_textbox;

    public Button next_page_btn;
    public Button previous_page_btn;

    private int able_page;

    public void Start()
    {
        next_page_btn.onClick.AddListener(NextPage);
        previous_page_btn.onClick.AddListener(PreviousPage);

        next_page_btn.enabled = false;
        previous_page_btn.enabled = false;
        curr_page_textbox.text = 0.ToString();
    }

    public void NextPage()
    {
        PageMove(1);
    }

    public void PreviousPage()
    {
        PageMove(-1);
    }
    
    public void PageMove(int num)
    {
        print(curr_page_amout);
        curr_page_amout += num;
        if(curr_page_amout > MainCtrl.instance.total_page_amount)
        {
            return;
        }
        //MainCtrl.instance.curr_page = curr_page_amout;
        // 다음 컨텐츠를 사용해되는 지 확인
        if (curr_page_amout >= able_page)
        {
            next_page_btn.enabled = false;
        }
        else
        {
            next_page_btn.enabled = true;
        }
        if(curr_page_amout == 0)
        {
            previous_page_btn.enabled = false;
        }
        else
        {
            previous_page_btn.enabled = true;
        }
        print(curr_page_amout);
        curr_page_textbox.text = curr_page_amout.ToString();
        MainCtrl.instance.PageSet(curr_page_amout);
    }

    public void PageAbleSet(int num)
    {
        if (num > able_page)
        {
            if (num < MainCtrl.instance.total_page_amount)
            {
                able_page = num;
                next_page_btn.enabled = true;
            }
        }
    }
}