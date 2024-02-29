using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartState : MonoBehaviour 
{

    private string[] nonEssentialChecks = {"a","b","c"};
    private string[] essentialChecks = {"d","e","f"};

    public string[] sendNE()
    {
        return nonEssentialChecks;
    }

    public string[] sendE() 
    { 
        return essentialChecks;
    }
    
}
