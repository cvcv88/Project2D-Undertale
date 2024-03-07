using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;
    private Vector2 moveDir;

	public bool upFlag = false;
	public bool downFlag = false;
	public bool rightFlag = false;
	public bool leftFlag = false;

	private void FixedUpdate()
	{
		Move();
	}

	private void Update()
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
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			animator.Play("RightWalk");
			upFlag = false;
			downFlag = false;	
			rightFlag = true;
			leftFlag = false;
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			animator.Play("LeftWalk");
			upFlag = false;
			downFlag = false;
			rightFlag = false;
			leftFlag = true;
		}

		if (!Input.anyKey)
		{
			if(upFlag)
			{
				animator.Play("BackIdle");
			}
			if(downFlag)
			{
				animator.Play("FrontIdle");
			}
			if(rightFlag)
			{
				animator.Play("RightIdle");
			}
			if(leftFlag)
			{
				animator.Play("LeftIdle");
			}
		}
	}

	private void Move()
    {
		transform.position += new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, 0) * Time.deltaTime;
		/*if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
		}*/
	}

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}