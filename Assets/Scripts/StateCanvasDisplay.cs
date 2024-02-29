using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class StateCanvasDisplay : MonoBehaviour
{

    [SerializeField] private Button nextBttn;
    [SerializeField] private Button prevBttn;
    [SerializeField] private TextMeshProUGUI prevBttnTxt;
    [SerializeField] private TextMeshProUGUI nextBttnTxt;
    private int stateCounter = 0;
    private int prevCan, nextCan = 1;
    List<string> StateNames = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        StateNames.Clear();
        StateNames.Add("Start State");
        StateNames.Add("Climb State");
        StateNames.Add("Landing State");
        prevCan = StateNames.Count-1;
        DisplayCanvas();
        ButtonText();
    }
    private void Awake()
    {
        nextBttn.onClick.AddListener(delegate { NextCanvas(nextCan); });
        prevBttn.onClick.AddListener(delegate { NextCanvas(prevCan); });
    }

    private void NextCanvas(int count)
    {
        GameObject temp = GameObject.Find(StateNames[stateCounter]);
        Canvas currentCanvas = temp.GetComponent<Canvas>();
        currentCanvas.enabled = false;
        stateCounter = count;
        if(stateCounter == StateNames.Count - 1) 
        {
            nextCan = 0;
        }
        else
        {
            nextCan = stateCounter+1;
        }
        if(stateCounter == 0)
        {
            prevCan = StateNames.Count - 1;
        }
        else
        {
            prevCan = stateCounter-1;
        }

        ButtonText();
        DisplayCanvas();
    }

    private void DisplayCanvas()
    {
        GameObject temp = GameObject.Find(StateNames[stateCounter]);
        Canvas currentCanvas = temp.GetComponent<Canvas>();
        currentCanvas.enabled = true;
    }
    void ButtonText()
    {
        prevBttnTxt.text = StateNames[prevCan];
        nextBttnTxt.text = StateNames[nextCan];
    }

}
