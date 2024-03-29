using UnityEngine;

public class ClimbState : FlightFSM
{
    ClimbSubState currentSubState;
    private bool flag = false;
    public ClimbState(FlightStateManager stateManager) : base(stateManager) 
    {
        currentSubState = ClimbSubState.PullThrottle;
        stateManager.climbSubStateMap[currentSubState].Initialize();
        Debug.Log("pull throttle");
    }

    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE CLIMB STATE");
    }

    public override void UpdateState(FlightStateManager o)
    {
        if (o.altitude >= 42000 && currentSubState == ClimbSubState.RetractLandingGear && flag)
            o.SwitchState(State.Cruise);
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
