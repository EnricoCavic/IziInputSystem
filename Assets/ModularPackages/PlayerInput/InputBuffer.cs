using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[Serializable]
public class InputBuffer
{
    private List<InputBufferObject> inputQueue = new List<InputBufferObject>();
    [SerializeField] private float inputTimeout;

    [SerializeField] private InputActionReference[] inputActionPriority;


    /// <summary>
    /// Event called the moment an input is first enqueued to the buffer
    /// <para> Subscribe to this event and check if your script can use that input </para>
    /// </summary>
    public Action<InputBufferObject> onInputEnqueued;

    public void RegisterInput(InputAction.CallbackContext _context)
    {
        InputBufferObject bufferObject = new InputBufferObject(_context);
        inputQueue.Add(bufferObject);
        onInputEnqueued?.Invoke(bufferObject);
        //Debug.Log("Input enqueued " + bufferObject.name + " / " + bufferObject.phase + " / " + bufferObject.registeredTime);

    }

    public void TickBuffer()
    {
        if(inputQueue.Count <= 0)
            return;

        if(Time.time - PeekInput().registeredTime > inputTimeout)
        {
            InputBufferObject _obj = DequeueInput();
            //Debug.Log("Input dequeued " + _obj.name + " / " + _obj.phase + " / " + _obj.wasProcessed + " / " + Time.time);  
        }
        
    }

    /// <summary>
    /// Find the and consume the first specified input found in the buffer
    /// </summary>
    /// <param name="_obj"> The input to be found in the buffer </param>
    public InputBufferObject FindAndConsumeInput(InputBufferObject _obj)
    {
        if(inputQueue.Count <= 0)
            return null;
        
        InputBufferObject foundObj = FindNext(_obj);
        if(foundObj != null)
        {

            Debug.Log("Input used instantly: "+ foundObj.name + " / " + foundObj.phase+ " / " + Time.time);
            foundObj.wasProcessed = true;
            return foundObj;
        }
            
        return null;
    }
    public InputBufferObject RequestNextInputByPriority(InputActionPhase _phase)
    {
        if(inputQueue.Count <= 0)
            return null;

        InputBufferObject objToCompare;

        for(int i = 0; i < inputActionPriority.Length; i++)
        {
            objToCompare = new InputBufferObject(inputActionPriority[i].action.name, _phase, false);
            InputBufferObject obj = FindNext(objToCompare);
            if(obj != null)
            {

                for (int j = obj.bufferPosition; j >= 0; j--)
                {
                    inputQueue[j].wasProcessed = true;
                    obj.wasProcessed = true;
                    
                }   

                Debug.Log("Input used from buffer: "+ obj.name + " / " + obj.phase+ " / " + Time.time); 
                return obj;
            }

        }

        return null;

    }

    public bool HasInputStored(InputBufferObject _objToCompare)
    {
        if(inputQueue.Count <= 0)
            return false;

        if(_objToCompare.CompareToObject(PeekInput()))
            return true;

        return false; 
    }

    private InputBufferObject PeekInput() => inputQueue[0];
    private InputBufferObject DequeueInput()
    {
        InputBufferObject returnValue = inputQueue[0];
        inputQueue.RemoveAt(0);
        return returnValue;
    }

    private InputBufferObject FindNext(InputBufferObject _objToCompare)
    {
        for(int i = 0; i < inputQueue.Count; i++ )
        {
            if(_objToCompare.CompareToObject(inputQueue[i]))
            {
                inputQueue[i].bufferPosition = i;
                return inputQueue[i];
            }
        }
        return null;
    }


}
