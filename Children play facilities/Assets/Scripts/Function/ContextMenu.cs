using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public Text curr_sequnce_textbox;
    public Text total_sequnce_textbox;
    private MainCtrl mainctrl;
    private List<Sequence> sequences = new List<Sequence>();

    void Start()
    {
        mainctrl = MainCtrl.instance;
        sequences = mainctrl.sequence;
        curr_sequnce_textbox.text = 0.ToString();
        total_sequnce_textbox.text = mainctrl.sequence.Count.ToString();
    }

    void Update()
    {

    }
}
