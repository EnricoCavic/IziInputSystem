using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


// InputObjects are input representations to be stored
public class InputBufferObject
{
    public string name;
    public float value;
    public InputActionPhase phase;
    public float registeredTime;
    public bool wasProcessed;


    public int bufferPosition;


    // Creates the obj that it is stored into the buffer
    // Contains all the parameters necessary for manipulation
    public InputBufferObject(InputAction.CallbackContext _context)
    {

        name = _context.action.name;
        value = _context.ReadValue<float>();
        phase = _context.phase;
        registeredTime = Time.time;
        wasProcessed = false; 
    }


    
    // Creates a dummy obj to use the function CompareToObject()
    // Used to find and obj in the buffer with specific parameters
    public InputBufferObject(string _name, InputActionPhase _phase, bool _wasProcessed)
    {
        name = _name;
        phase = _phase;
        wasProcessed = _wasProcessed; 
    }

    // Used with the dummy obj to find objs in the buffer that meet the requirement 
    public bool CompareToObject(InputBufferObject _objToCompare)
    {
        if(_objToCompare == null)
            return false;

        return _objToCompare.name == name &&
               _objToCompare.phase == phase &&
               _objToCompare.wasProcessed == wasProcessed;
    }

}
