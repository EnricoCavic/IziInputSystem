using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{

    //public List<InputResponse> inputActions;

    private List<InputBufferObject> inputObjects = new List<InputBufferObject>();

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
        //     inputObjects.Add(new InputBufferObject(_response));
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
        // InputBufferObject inputObject = new InputBufferObject(_context);
        // buffer?.EnqueueInput(inputObject);
    }

    // public InputResponse GetAction(string _name)
    // {
    //     foreach (InputResponse _response in inputActions)
    //         if(_response.name == _name)
    //             return _response;

    //     return null;
    // }
    
    // private InputBufferObject GetInputObject(InputAction _action)
    // {
    //     foreach (InputBufferObject _obj in inputObjects)
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
