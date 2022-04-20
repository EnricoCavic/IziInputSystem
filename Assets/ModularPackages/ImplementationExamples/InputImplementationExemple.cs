using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputImplementationExemple : MonoBehaviour
{
    private MainInputAsset inputAsset;

    public InputBuffer buffer;

    [SerializeField] private Animator targetAnimator;

    private void Awake()  
    {
        inputAsset = new MainInputAsset();
    }

    private void OnEnable() 
    {
        inputAsset.MainMap.Enable();    
    }

    private void Start() 
    {
        AnimationEventTrigger.onAnimationEnded += CheckForInputsStored;

        inputAsset.MainMap.MainInput.started += buffer.RegisterInput;
        inputAsset.MainMap.MainInput.canceled += buffer.RegisterInput; 

        inputAsset.MainMap.SecondaryInput.started += buffer.RegisterInput;
        inputAsset.MainMap.SecondaryInput.canceled += buffer.RegisterInput; 

        inputAsset.MainMap.DoubleTapMainInput.performed += buffer.RegisterInput;



        buffer.onInputEnqueued += TryInput;

    }


    private void TryInput(InputBufferObject obj)
    {
        if(!canReceiveInput)
             return;


        buffer.FindAndConsumeInput(obj);
        DoSomethingWithInput(obj);
        

    }


    private void CheckForInputsStored(AnimationEventTrigger _eventTrigger)
    {
        Debug.Log("Checking buffer...");
        InputBufferObject obj = buffer.RequestNextInputByPriority(InputActionPhase.Started);

        DoSomethingWithInput(obj);
    }

    private void DoSomethingWithInput(InputBufferObject obj)
    {
        if(obj == null)
            return;

        // separating different actions per state
        string currentState = GetCurrentState();
        switch(currentState)
        {
            case "Idle":
                if(obj.phase == InputActionPhase.Canceled)
                    return;

                break;
        }

        // can be any aplication of the input, changing the animation is just an exemple
        targetAnimator.SetTrigger(obj.name + obj.phase);
    }

    private void FixedUpdate() 
    {
        buffer.TickBuffer();    
    }

    private void OnDisable() 
    {
        inputAsset.MainMap.Disable();    
    }

    private bool canReceiveInput => targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Idle");
    private string GetCurrentState() => targetAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;


}
