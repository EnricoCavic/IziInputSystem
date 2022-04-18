using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputImplementationExemple : MonoBehaviour
{
    private InputProcessor inputProcessor;
    [SerializeField] private Animator targetAnimator;


    private void Awake()
    {
        inputProcessor = GetComponent<InputProcessor>();

    }
    private void OnEnable() 
    {
        inputProcessor.buffer.onInputEnqueued += TryInput;
    }

    private void TryInput(InputObject _obj)
    {
        
    }


}
