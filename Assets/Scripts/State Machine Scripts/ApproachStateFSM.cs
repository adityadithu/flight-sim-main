using UnityEngine;

public class ApproachStateFSM : FlightFSM
{

    ApproachSubState currentSubState;
    private bool flag = false;

    public ApproachStateFSM(FlightStateManager stateManager) : base(stateManager)
    {
        currentSubState = ApproachSubState.ApproachRunway;
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
        if (currentSubState == ApproachSubState.ApproachSubState)
        {

        }
        else
        {
            currentSubState++;

            stateManager.approachSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {
                case ApproachSubState.ApproachRunway:
                    Debug.Log("Retract Landing Gear");
                    flag = true;
                    break;
            }
        }
    }
}
