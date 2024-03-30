using UnityEngine;

public class LandingStateFSM : FlightFSM
{

    LandingSubState currentSubState;
    private bool flag = false;

    public LandingStateFSM(FlightStateManager stateManager) : base(stateManager) 
    {
        currentSubState = LandingSubState.ControlPlane;
        stateManager.landingSubStateMap[currentSubState].Initialize();
        Debug.Log("FLIP");
    }

    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE LANDING STATE");
    }

    public override void UpdateState(FlightStateManager o)
    {

    }
    public override void UpdateSubState()
    {
        if (currentSubState == LandingSubState.ControlPlane)
        {

        }
        else
        {
            currentSubState++;

            stateManager.landingSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {
                case LandingSubState.ControlPlane:
                    Debug.Log("Retract Landing Gear");
                    flag = true;
                    break;
            }
        }
    }
}