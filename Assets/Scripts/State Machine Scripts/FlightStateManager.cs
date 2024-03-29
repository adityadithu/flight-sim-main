using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Start,
    TakeOff,
    Climb,
    Cruise,
    Descent,
    Approach,
    Landing
}

public enum StartSubState
{
    FlipSwitch,
    StartEngine,
    BeaconLight,
    RightEngine,
    RightRun,
    LeftEngine,
    LeftRun,
    Avionics,
    Flaps
}

public enum TakeOffSubState
{
    Lights,
    MoveToRunway,
    IncreaseAlt
}

public enum ClimbSubState
{
    PullThrottle,
    RetractLandingGear
}

public enum CruiseSubState
{
    Autopilot,
    DisengageAutopilot
}

public enum DescentSubState
{
    DecreaseAlt
}

public enum ApproachSubState
{
    EngageLandingGear,
    ApproachRunway
}

public enum LandingSubState
{
    ControlPlane
}
public class FlightStateManager : MonoBehaviour
{

    public float altitude;
    [SerializeField] Slider slider;
    [SerializeField] Button upbtn;
    [SerializeField] Button dwnbtn;
    public TextMeshProUGUI prompts;

    State currentState;
    FlightFSM currentStateScript;

    StartStateFSM StartState;
    TakeOffStateFSM TakeOffState;
    ClimbState ClimbState;
    CruiseStateFSM CruiseState;
    DescentStateFSM DescentState;
    ApproachStateFSM ApproachState;
    LandingStateFSM LandingState;

    public Dictionary<State, FlightFSM> stateMap;

    public Dictionary<StartSubState, Interactable> startSubStateMap = new Dictionary<StartSubState, Interactable>();
    public Dictionary<TakeOffSubState, Interactable> takeoffSubStateMap = new Dictionary<TakeOffSubState, Interactable>();
    public Dictionary<ClimbSubState, Interactable> climbSubStateMap = new Dictionary<ClimbSubState, Interactable>();
    public Dictionary<CruiseSubState, Interactable> cruiseSubStateMap = new Dictionary<CruiseSubState, Interactable>();
    public Dictionary<DescentSubState, Interactable> descentSubStateMap = new Dictionary<DescentSubState, Interactable>();
    public Dictionary<ApproachSubState, Interactable> approachSubStateMap = new Dictionary<ApproachSubState, Interactable>();
    public Dictionary<LandingSubState, Interactable> landingSubStateMap = new Dictionary<LandingSubState, Interactable>();

    void Start()
    {
        InitializeStateScripts();
        InitializeDictionary();
        SwitchState(State.Start);

        altitude = slider.value;
    }

    void InitializeStateScripts()
    {
        StartState = new StartStateFSM(this);
        TakeOffState = new TakeOffStateFSM(this);
        ClimbState = new ClimbState(this);
        CruiseState = new CruiseStateFSM(this);
        DescentState = new DescentStateFSM(this);
        ApproachState = new ApproachStateFSM(this);
        LandingState = new LandingStateFSM(this);
    }

    void InitializeDictionary()
    {
        stateMap = new Dictionary<State, FlightFSM>();

        stateMap[State.Start] = StartState;
        stateMap[State.TakeOff] = TakeOffState;
        stateMap[State.Climb] = ClimbState;
        stateMap[State.Cruise] = CruiseState;
        stateMap[State.Descent] = DescentState;
        stateMap[State.Approach] = ApproachState;
        stateMap[State.Landing] = LandingState;
    }

    void Update()
    {
        altitude = slider.value;
        currentStateScript.UpdateState(this);
    }

    public void SwitchState(State nextState)
    {
        currentState = nextState;

        currentStateScript = stateMap[currentState];
        currentStateScript.InitState(this);
    }

}
