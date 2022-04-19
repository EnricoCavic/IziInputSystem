using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputImplementationExemple : MonoBehaviour
{
    private MainInputAsset inputAsset;

    public InputBuffer buffer;

    private InputProcessor inputProcessor;
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
        AnimationEventTrigger.onAnimationStarted += AcceptInput;

        inputAsset.MainMap.MainInput.started += buffer.RegisterInput;
        inputAsset.MainMap.MainInput.canceled += buffer.RegisterInput; 

        inputAsset.MainMap.DoubleTapMainInput.performed += buffer.RegisterInput;

        inputAsset.MainMap.SecondaryInput.started += buffer.RegisterInput;
        inputAsset.MainMap.SecondaryInput.canceled += buffer.RegisterInput; 



        buffer.onInputEnqueued += TryInput;

    }


    private void TryInput(InputBufferObject obj)
    {
        if(!canAcceptInput)
             return;


        buffer.FindAndConsumeInput(obj);
        DoSomethingWithInput(obj);
        

    }


    private void AcceptInput(AnimationEventTrigger _eventTrigger)
    {
        Debug.Log("Idle enter");
        InputBufferObject obj = buffer.RequestNextInput(inputAsset.MainMap.MainInput.name, InputActionPhase.Started);

        DoSomethingWithInput(obj);
    }

    private void DoSomethingWithInput(InputBufferObject obj)
    {
        if(obj == null)
            return;

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

    private bool canAcceptInput => targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Idle");


}
