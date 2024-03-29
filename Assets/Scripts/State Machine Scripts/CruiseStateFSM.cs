using UnityEngine;

public class CruiseStateFSM : FlightFSM
{
    CruiseSubState currentSubState;
    public CruiseStateFSM(FlightStateManager stateManager) : base(stateManager) 
    {
        currentSubState = CruiseSubState.Autopilot;
        stateManager.cruiseSubStateMap[currentSubState].Initialize();
        Debug.Log("Engage Autopilot");
    }

    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE CRUISE STATE");
    }

    public override void UpdateState(FlightStateManager o)
    {
       // if (o.altitude < 30000 && o.altitude >5000)
         //   o.SwitchState(State.Climb);
       // else if (o.altitude <5000)
            o.SwitchState(State.Descent);

    }
    public override void UpdateSubState()
    {
        
    }
}
