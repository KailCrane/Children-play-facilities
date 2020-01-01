using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disapear : MonoBehaviour
{
    public float time;
    private float timer;
    private bool isDisapear;
    public Image image;

    void Start()
    {
        isDisapear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisapear)
        {
            time += Time.deltaTime;
            image.color = new Color(1,1,1,1);
            //컬러를 빼준다 
            if (timer >= time)
            {
                isDisapear = false;
            }
        }

    }
}
