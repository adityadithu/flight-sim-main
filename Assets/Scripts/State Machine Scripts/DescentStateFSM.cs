using UnityEngine;

public class DescentStateFSM : FlightFSM
{
    DescentSubState currentSubState;
    private bool flag = false;
    public DescentStateFSM(FlightStateManager stateManager) : base(stateManager) 
    {
        currentSubState = DescentSubState.DecreaseAlt;
        stateManager.descentSubStateMap[currentSubState].Initialize();
        Debug.Log("FLIP");
    }

    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE DESCENT STATE");
    }

    public override void UpdateState(FlightStateManager o)
    {
        for (int i = 0; i < 1000; i++) ;
        o.SwitchState(State.Approach);
    }
    public override void UpdateSubState()
    {
        if (currentSubState == DescentSubState.DecreaseAlt)
        {

        }
        else
        {
            currentSubState++;

            stateManager.descentSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {
                case DescentSubState.DecreaseAlt:
                    Debug.Log("slowly decrease the altitude ");
                    flag = true;
                    break;
            }
        }
    }
}