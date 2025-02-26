using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnSolver : StateMachineBehaviour
{
    [SerializeField] private string aimingBoneName;
    [SerializeField] private float turnThreshold;

    [SerializeField] private string leftTurnTrigger;
    [SerializeField] private string rightTurnTrigger;


    private Transform aimingBone;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aimingBone != null) return;
        aimingBone = animator.transform.GetComponentsInChildren<Transform>().FirstOrDefault(t=>t.gameObject.name == aimingBoneName);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aimingBone == null) return; 
        Vector3 forward = animator.transform.forward;
        Vector3 aimForward = Vector3.ProjectOnPlane(aimingBone.forward, animator.transform.up).normalized;
        float angle = Vector3.SignedAngle(forward, aimForward, animator.transform.up);
        animator.SetFloat("AimVSBody", Mathf.Abs(angle));
        if (Mathf.Abs(angle) > turnThreshold)
        {
            animator.SetTrigger(angle > 0 ? rightTurnTrigger : leftTurnTrigger);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
