using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : ARInteractableObject
{
    [SerializeField] private Renderer _renderer;
    private static readonly int StartInteraction = Animator.StringToHash("StartInteraction");
    private static readonly int GoToIdle = Animator.StringToHash("GoToIdle");
    private Animator _animator;
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Idle:
                _animator.SetTrigger(GoToIdle );
                if (_renderer == null) return;
                _renderer.materials[0].EnableKeyword("_EMISSION");
                _renderer.materials[0].SetColor("_EmissionColor", new Color(0, 0, 0, 0));
                break;
            case State.Active:
                _animator.SetTrigger(StartInteraction);
                if (_renderer == null) return;
                _renderer.materials[0].EnableKeyword("_EMISSION");
                _renderer.materials[0].SetColor("_EmissionColor", new Color(0.5f, 0.5f, 0.5f, 0.1f));
                break;
        }
    }
    
}
