using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class CharacterAim : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private CinemachineCamera aimingCamera;
    [SerializeField] private AimConstraint aimConstraint;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAim(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            aimingCamera?.gameObject.SetActive(true);
            ParentCharacter.IsAiming = true;
            aimConstraint.weight = 1;
            aimConstraint.enabled = true;
            anim.SetLayerWeight(1,1);
        }

        if (ctx.canceled)
        {
            aimingCamera?.gameObject.SetActive(false);
            ParentCharacter.IsAiming = false;
            aimConstraint.weight = 0;
            aimConstraint.enabled = false;
            anim.SetLayerWeight(1,0);
        }
    }

    public Character ParentCharacter { get; set; }
}
