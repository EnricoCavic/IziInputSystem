using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{

    //public List<InputResponse> inputActions;

    private List<InputObject> inputObjects = new List<InputObject>();

    [SerializeField] private InputBuffer buffer;

    void OnEnable()
    {
        // foreach (InputResponse _response in inputActions)
        //     _response.action.Enable();
    }

    private void Start() 
    {
        // foreach (InputResponse _response in inputActions)
        // {
        //     inputObjects.Add(new InputObject(_response));
        //     _response.action.started += RegisterToBuffer;
        //     _response.action.canceled += RegisterToBuffer;
        // }
    }

    void FixedUpdate() 
    {
        buffer?.TickBuffer();    
    }

    public void RegisterToBuffer(InputAction.CallbackContext _context)
    {
        InputObject inputObject = new InputObject(_context.action.name,
                                                  _context.ReadValue<float>() > float.Epsilon,
                                                  _context.startTime);
        buffer?.EnqueueInput(inputObject);
    }

    // public InputResponse GetAction(string _name)
    // {
    //     foreach (InputResponse _response in inputActions)
    //         if(_response.name == _name)
    //             return _response;

    //     return null;
    // }
    
    // private InputObject GetInputObject(InputAction _action)
    // {
    //     foreach (InputObject _obj in inputObjects)
    //         if(_obj.response.action == _action)
    //             return _obj;

    //     return null;
    // }

    void OnDisable()
    {
        // foreach (InputResponse _response in inputActions)
        //     _response.action.Disable();
    }

}
