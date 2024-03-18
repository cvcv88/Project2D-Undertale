using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeartMove : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] float moveSpeed;
    private Vector2 moveDir;

    private FloweyController flowey;

    [SerializeField] Image dialogueHolder;


    private void Move()
    {
        transform.position += new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, 0) * Time.deltaTime;
    }

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

    private bool inDialogue()
    {
        if (flowey != null)
            return flowey.DialogueActive();
        else return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}