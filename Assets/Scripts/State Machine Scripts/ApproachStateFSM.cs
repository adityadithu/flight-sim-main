using UnityEngine;

public class ApproachStateFSM : FlightFSM
{

    ApproachSubState currentSubState;

    public ApproachStateFSM(FlightStateManager stateManager) : base(stateManager)
    {
        currentSubState = ApproachSubState.EngageLandingGear;
        stateManager.approachSubStateMap[currentSubState].Initialize();
        Debug.Log("FLIP");
    }
    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE APPROACH STATE");
    }

    public override void UpdateState(FlightStateManager o)
    {
        if (o.altitude < 10000)
            o.SwitchState(State.Landing);
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
