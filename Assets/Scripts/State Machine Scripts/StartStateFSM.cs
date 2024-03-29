using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStateFSM : FlightFSM
{

    StartSubState currentSubState;
    private bool flag = false;

    public StartStateFSM(FlightStateManager stateManager) : base(stateManager)
    {
        currentSubState = StartSubState.FlipSwitch;
        stateManager.startSubStateMap[currentSubState].Initialize();
        Debug.Log("flip switch");
    }


    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE START STATE.");
    }

    public override void UpdateState(FlightStateManager o)
    {
        if (currentSubState == StartSubState.Flaps && flag)
            o.SwitchState(State.TakeOff);
    }

    public override void UpdateSubState()
    {
        if (currentSubState == StartSubState.Flaps)
        {

        }
        else
        {
            currentSubState++;

            stateManager.startSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {               
                case StartSubState.StartEngine:
                    Debug.Log("start engine");
                    break;
                case StartSubState.BeaconLight:
                    Debug.Log("Turn on beacon lights");
                    break;
                case StartSubState.RightEngine:
                    Debug.Log("Switch on right engine");
                    break;
                case StartSubState.RightRun:
                    Debug.Log("click right run");
                    break;
                case StartSubState.LeftEngine:
                    Debug.Log("switch on left engine");
                    break;
                case StartSubState.LeftRun:
                    Debug.Log("click left run");
                    break;
                case StartSubState.Avionics:
                    Debug.Log("turn on avionics");
                    break;
                case StartSubState.Flaps:
                    Debug.Log("turn on flaps");
                    flag = true;
                    break;
            }
        }
    }

}

