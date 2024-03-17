using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeartMove : MonoBehaviour
{
    
    [SerializeField] float moveSpeed;
    private Vector2 moveDir;

    private FloweyController flowey;
    private bool dialogueCheck = false;

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}