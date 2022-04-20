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
        AnimationEventTrigger.onAnimationEnded += CheckBuffer;

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


    private void CheckBuffer(AnimationEventTrigger _eventTrigger)
    {
        Debug.Log("Checking buffer...");
        InputBufferObject obj = buffer.RequestNextInput(InputActionPhase.Started);

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

    private bool canReceiveInput => targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Idle");


}
