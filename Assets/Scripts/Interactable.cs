using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] State state;
    [SerializeField] StartSubState startSubState;

    [SerializeField] FlightStateManager stateManager;

    void Start()
    {
        switch(state)
        {
            case State.Start:
                stateManager.startSubStateMap[startSubState] = this;
                break;
        }
    }

    public void Initialize()
    {
        // Glow
    }

    public void Deglow()
    {
        // Deglow
    }

    public void OnInteracted()
    {
        Deglow();

        stateManager.stateMap[state].UpdateSubState();
    }

}
