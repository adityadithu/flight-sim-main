using Unity.VisualScripting;
using UnityEngine;

public class TakeOffStateFSM : FlightFSM
{
    TakeOffSubState currentSubState;
    private bool flag = false;
    public TakeOffStateFSM(FlightStateManager stateManager) : base(stateManager)
    {
        currentSubState = TakeOffSubState.Lights;
        stateManager.takeoffSubStateMap[currentSubState].Initialize();
        Debug.Log("turn on lights");
    }

    public override void InitState(FlightStateManager o)
    {
        Debug.Log("INSIDE TAKEOFF STATE");

    }

    public override void UpdateState(FlightStateManager o)
    {
        if (currentSubState == TakeOffSubState.IncreaseAlt && flag)
            o.SwitchState(State.Climb);
    }
    public override void UpdateSubState()
    {
        if (currentSubState == TakeOffSubState.IncreaseAlt)
        {

        }
        else
        {
            currentSubState++;

            stateManager.takeoffSubStateMap[currentSubState].Initialize();

            switch (currentSubState)
            {
                case TakeOffSubState.MoveToRunway:
                    Debug.Log("Move to Runway");
                    break;
                case TakeOffSubState.IncreaseAlt:
                    Debug.Log("Increase Altitude");
                    flag = true;
                    break;
            }
        }
    }
}
