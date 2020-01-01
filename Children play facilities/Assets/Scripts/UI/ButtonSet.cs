using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSet : MonoBehaviour
{
    private Button button;
    private GameObject connect_obj;

    public void Initialize(GameObject _connect_obj)
    {
        button = this.gameObject.AddComponent<Button>();
        button.onClick.AddListener(Press);
        connect_obj = _connect_obj;
    }

    public void Press()
    {
        //연결된 오브젝트에 프레스 했음을 전달
        //프레스 했을 때의 행동은 메인에서 한다
    }

    //무엇이랑 연결되어 있는가
    //버튼 추가
    //버튼 행동 추가
    //조건 추가가 자동으로 되야함

}
