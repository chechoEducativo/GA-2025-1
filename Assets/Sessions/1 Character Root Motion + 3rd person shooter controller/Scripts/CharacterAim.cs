using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAim : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private CinemachineCamera aimingCamera;
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
            anim.SetLayerWeight(1, 1);
            ParentCharacter.IsAiming = true;
        }

        if (ctx.canceled)
        {
            aimingCamera?.gameObject.SetActive(false);
            anim.SetLayerWeight(1, 0);
            ParentCharacter.IsAiming = false;
        }
    }

    public void OnChangeShoulder(InputAction.CallbackContext ctx)
    {
        
    }

    public Character ParentCharacter { get; set; }
}
