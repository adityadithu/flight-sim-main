using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DisplayCheckList : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI checkListDisplay;
    private int stateCounter = 0;
    private Dictionary<int, Dictionary<string, string[]>> stateList = new Dictionary<int, Dictionary<string, string[]>>();
    private string[] nonEssentialChecks;
    private string[] essentialChecks;
    private string stateName;
    // Start is called before the first frame update
    void Start()
    {
        AddStates();
        DisplayChecks();
    }
    private void AddStates()
    {
        Dictionary<string, string[]> Startstate = new Dictionary<string, string[]>();
        Startstate.Add("non essential checks", new string[] { "a", "b", "c" });
        Startstate.Add("essential checks", new string[] { "d", "e", "f" });

        Dictionary<string, string[]> Climbstate = new Dictionary<string, string[]>();
        Climbstate.Add("non essential checks", new string[] { "g", "h", "i" });
        Climbstate.Add("essential checks", new string[] { "j", "k", "l" });

        Dictionary<string, string[]> Descentstate = new Dictionary<string, string[]>();
        Descentstate.Add("non essential checks", new string[] { "m", "n", "o" });
        Descentstate.Add("essential checks", new string[] { "p", "q", "r" });

        stateList.Add(0, Startstate);
        stateList.Add(1, Climbstate);
        stateList.Add(2, Descentstate);

    }
    private void DisplayChecks()
    {
        //stateName = stateList[stateCounter].Keys;
        nonEssentialChecks = stateList[stateCounter]["non essential checks"];
        essentialChecks = stateList[stateCounter]["essential checks"];

        string message="";
        foreach (string s in nonEssentialChecks)
            message += "<#f00>" + s + "</color>\n";
        foreach (string s in essentialChecks)
            message += "<#0f0>" + s +  "</color>\n";

        checkListDisplay.text = message;
    }
}
