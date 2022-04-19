using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharState
{
    Idle,
    Attacking
}

public class StateHandler : StateMachineBusiness<State>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void InitializeStates()
    {
        base.InitializeStates();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
