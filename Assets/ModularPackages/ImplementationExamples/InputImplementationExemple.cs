using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputProcessor))]
public class InputImplementationExemple : MonoBehaviour
{
    private MainInputAsset inputAsset;

    private InputProcessor inputProcessor;
    [SerializeField] private Animator targetAnimator;

    private void Awake()  
    {
        inputAsset = new MainInputAsset();
        inputProcessor = GetComponent<InputProcessor>();
    }

    private void OnEnable() 
    {
        inputAsset.MainMap.Enable();    
    }

    private void Start() 
    {
        inputAsset.MainMap.MainInput.started += inputProcessor.RegisterToBuffer; 
        inputAsset.MainMap.MainInput.canceled += inputProcessor.RegisterToBuffer; 
        
        inputAsset.MainMap.SecondaryInput.started += inputProcessor.RegisterToBuffer; 
        inputAsset.MainMap.SecondaryInput.canceled += inputProcessor.RegisterToBuffer; 

    }

    private void OnDisable() 
    {
        inputAsset.MainMap.Disable();    
    }


}
