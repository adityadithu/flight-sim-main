using UnityEngine;

public class LandingStateFSM : FlightFSM
{

    LandingSubState currentSubState;

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
        if (currentSubState == ClimbSubState.RetractLandingGear)
        {

        }
        else
        {
            currentSubState++;

            stateManager.climbSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {
                case ClimbSubState.RetractLandingGear:
                    Debug.Log("Retract Landing Gear");
                    flag = true;
                    break;
            }
        }
    }
}