using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateScript : MonoBehaviour
{

    HoldCheckListStart hcls;
    private string[] nonEssentialChecks;
    private string[] essentialCheck;
    private string[] nonEssentialChecksValues;
    private string[] essentialCheckValues;
    [SerializeField] GameObject rowVal;
    ChangeText ct;
    [SerializeField] private Transform contentPanel;
    [SerializeField] string stateName;
    // Start is called before the first frame update
    void Start()
    {
        hcls = GameObject.Find(stateName).GetComponent<HoldCheckListStart>();
        nonEssentialChecks = hcls.nonEC;
        essentialCheck = hcls.EC;
        nonEssentialChecksValues = hcls.nonECV;
        essentialCheckValues = hcls.ECV;
        Popu();
    }



    void Popu()
    {
        for(int i = 0; i < nonEssentialChecks.Length; i++)
        {
            GameObject row = Instantiate(rowVal,contentPanel);
            ct =  row.GetComponent<ChangeText>();          
            ct.changeText(nonEssentialChecks[i], nonEssentialChecksValues[i]);

        }
    }
    
}
