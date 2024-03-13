using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] Animator animator;

	[SerializeField] float moveSpeed;
	private Vector2 moveDir;

	private FloweyController flowey;

	private bool upFlag = false;
	private bool downFlag = false;
	private bool rightFlag = false;
	private bool leftFlag = false;

	private void FixedUpdate()
	{
		Move();
	}

	private void Update()
	{
		if (!inDialogue())
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				animator.Play("BackWalk");
				upFlag = true;
				downFlag = false;
				rightFlag = false;
				leftFlag = false;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				animator.Play("FrontWalk");
				upFlag = false;
				downFlag = true;
				rightFlag = false;
				leftFlag = false;
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				animator.Play("RightWalk");
				upFlag = false;
				downFlag = false;
				rightFlag = true;
				leftFlag = false;
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				animator.Play("LeftWalk");
				upFlag = false;
				downFlag = false;
				rightFlag = false;
				leftFlag = true;
			}
			StopAnimation();
		}
	}

	private void Move()
	{
		transform.position += new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, 0) * Time.deltaTime;
	}

	private void OnMove(InputValue value)
	{
		moveDir = value.Get<Vector2>();
	}

	public void StopAnimation()
	{
		if (!Input.anyKey)
		{
			if (upFlag)
			{
				animator.Play("BackIdle");
			}
			if (downFlag)
			{
				animator.Play("FrontIdle");
			}
			if (rightFlag)
			{
				animator.Play("RightIdle");
			}
			if (leftFlag)
			{
				animator.Play("LeftIdle");
			}
		}
	}

	private bool inDialogue()
	{
		if (flowey != null)
			return flowey.DialogueActive();
		else return false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Flowey")
		{
			flowey = collision.gameObject.GetComponent<FloweyController>();
			flowey.ActivateDialogue();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		flowey = null;
	}
}