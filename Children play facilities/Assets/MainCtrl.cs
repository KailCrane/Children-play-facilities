using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCtrl : MonoBehaviour
{
    public delegate void OnPauseEvent();
    public static event OnPauseEvent OnPause;
    public delegate void OnPlayEvent();
    public static event OnPlayEvent OnPlay;

    public static MainCtrl instance;
    public float timer;
    private bool isTimeFlow;

    public Button playBtn;
    //public Button stopBtn; 현재로서는 스탑 버튼은 존재하지 않는다
    public Button pauseBtn;
    public Button rewindBtn;

    private List <Content> contents = new List<Content>();
    public List<Page> pages =new List<Page>();

    [HideInInspector]
    public Page curr_page;

    public List <Sequence> sequence = new List<Sequence>();

    public Button previouse_btn;
    public Button next_btn;

    private int page_count;
    private int curr_page_count;
    [HideInInspector]
    public int total_page_amount;

    public Text total_page_textbox;

    public PageCtrl pagectrl;

    //public List<Content> pages = new List<Content>();

    private ProgressBar progress;
    private Timer _timer;

    private void Awake()
    {
        instance = this;
        progress = GetComponent<ProgressBar>();
        _timer = GetComponent<Timer>();
    }

    void Start()
    {
        pauseBtn.onClick.AddListener(Pause);
        playBtn.onClick.AddListener(Play);
        rewindBtn.onClick.AddListener(Rewind);

        isTimeFlow = false;
        previouse_btn.enabled = false;
        next_btn.enabled = false;
        page_count = 1;
        pagectrl = GetComponent<PageCtrl>();
        PageSet(0);
        total_page_amount = pages.Count;
        total_page_textbox.text = total_page_amount.ToString();
    }

    void Update()
    {
        TimeFlower();
    }

    public void PageSet(int num)
    {
        timer = 0f;
        curr_page = pages[num];
        curr_page_count = num + 1;

        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].gameObject.SetActive(false);
            curr_page = pages[num];
            curr_page.gameObject.SetActive(true);
            contents = curr_page.contents;
        }

        for (int i = 0; i < contents.Count; i++)
        {
            contents[i].gameObject.SetActive(false);
        }

        progress.Setting(contents[contents.Count - 1].disapear_time - 1);
        _timer.Setting(contents[contents.Count - 1].disapear_time - 1);

        //contents[num].gameObject.SetActive(true);
        isTimeFlow = true;
    }

    public void Pause()
    {
        isTimeFlow = false;
        OnPause();
    }

    public void Play()
    {
        isTimeFlow = true;
        OnPlay();
    }

    public void Rewind()
    {
        if (timer - 5f >= 0)
        {
            timer = timer -= 5f;
        }
        else
        {
            timer = 0f;
        }

        for (int i = 0; i < contents.Count; i++)
        {
            if (contents[i].apear_time >= timer && contents[i].disapear_time < timer)
            {
                contents[i].gameObject.SetActive(true);
            }
            else
            {
                contents[i].gameObject.SetActive(false);
            }
        }

    }

    public void TimeFlower()
    {
        //만약 컨텐츠가 퀴즈일 경우 시간이 흐르지 않는다;
        if (isTimeFlow)
        {
            if(contents[0].type == Content.Type.Quiz)
            {
                isTimeFlow = false;
                return;
            }

            progress.VisualShow(timer);
            _timer.VisualShow(timer);
            //만약 시간이 흐르고 있음 이라면
            timer += Time.deltaTime;
            //시간을 흐르게 한다

            for (int i = 0; i < contents.Count; i++)
            {
                if (contents[i].apear_time <= timer && contents[i].disapear_time > timer)
                {
                    if (contents[i].gameObject.activeInHierarchy == false)
                    {
                        contents[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (contents[i].gameObject.activeInHierarchy == true)
                    {
                        print("Work" + timer);
                        contents[i].gameObject.SetActive(false);
                    }
                }
            }

            if(contents[contents.Count-1].disapear_time -1 <= timer) //페이지 전체 재생 확인
            {
                pagectrl.PageAbleSet(curr_page_count);
                isTimeFlow = false;
            }
        }
    }
}


[System.Serializable]
public struct Sequence
{
    public string name;
    public float start_time;
    public float end_time;
    public int index;
}

[System.Serializable]
public struct Condition
{
    public enum Type{video,quiz}
    public Type type;
}