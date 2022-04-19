using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEventTrigger : MonoBehaviour
{
    public static event Action<AnimationEventTrigger> onAnimationStarted;
    public static event Action<AnimationEventTrigger> onAnimationEnded;

    public Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    public void TriggerStartEvent() => onAnimationStarted?.Invoke(this);
    public void TriggerEndEvent() => onAnimationEnded?.Invoke(this);
}
