using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// InputObjects are input representations to be stored
public class InputObject
{
    public string name;
    public bool isPressing;

    public double registeredTime;
    public bool wasProcessed;


    // Creates the obj that it is stored into the buffer
    // Contains all the parameters necessary for manipulation
    public InputObject(string _name, bool _isPressing, double _registeredTime)
    {
        name = _name;
        isPressing = _isPressing;
        registeredTime = _registeredTime;
        wasProcessed = false; 
    }


    
    // Creates a dummy obj to use the function CompareToObject()
    // Used to find and obj in the buffer with specific parameters
    public InputObject(string _name, bool _isPressing, bool _wasProcessed)
    {
        name = _name;
        isPressing = _isPressing;
        wasProcessed = _wasProcessed; 
    }

    // Used with the dummy obj to find objs in the buffer that meet the requirement 
    public bool CompareToObject(InputObject _objToCompare)
    {
        if(_objToCompare == null)
            return false;

        return _objToCompare.name == name &&
               _objToCompare.isPressing == isPressing &&
               _objToCompare.wasProcessed == wasProcessed;
    }

}
