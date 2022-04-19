using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State
{
    public Action<Parameters> onInputProcessed;
    public Action<Parameters> onEnter;
    public Action<Parameters> onExit;
    public abstract void Enter();
    
    public abstract State Tick();

    public abstract State FixedTick();

    public abstract void Exit();

    public abstract void ProcessInput(Parameters _input);
}


