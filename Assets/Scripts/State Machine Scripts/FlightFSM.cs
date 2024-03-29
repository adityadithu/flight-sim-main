using System.Collections.Generic;
using UnityEngine;

public class FlightFSM
{

    protected FlightStateManager stateManager;

    public FlightFSM(FlightStateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public virtual void InitState(FlightStateManager obj)
    {

    }

    public virtual void UpdateState(FlightStateManager obj)
    {

    }

    public virtual void UpdateSubState()
    {

    }


}