using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandler : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    private static readonly int Running = Animator.StringToHash("running");
    [SerializeField] private List<string> _animationTriggersToResetOnMove;
    public bool CanMove { private get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (CanMove)
        {
            HandleMoveAnimation();
        }
    }

    private void HandleMoveAnimation()
    {
        Vector3 velocity = _rb.velocity;
        if (Math.Abs(velocity.x) + Math.Abs(velocity.z) > 0.2)
        {
            _animationTriggersToResetOnMove.ForEach(_animator.ResetTrigger);
            _animator.SetBool(Running, true);
        }
        else
        {
            _animator.SetBool(Running, false);
        }
    }

}