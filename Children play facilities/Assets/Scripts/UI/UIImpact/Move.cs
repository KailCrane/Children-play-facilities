using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float time;
    private float timer;
    private bool isMove;

    void Start()
    {
        
    }

    public void MoveOn()
    {
        isMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            //
        }
    }
}
