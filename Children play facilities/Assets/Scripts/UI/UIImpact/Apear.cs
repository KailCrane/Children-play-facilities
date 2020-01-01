using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apear : MonoBehaviour
{
    public float time;
    public Image image;
    private float timer;
    private bool isApear;

    void Start()
    {
        isApear = true;
    }

    void Update()
    {
        if (isApear)
        {
            timer += Time.deltaTime;
            image.color = new Color(1,1,1,1);
            //컬러를 더해준다 알파값만
            if (timer > time)
            {
                isApear = false;
            }
        }
    }
}
