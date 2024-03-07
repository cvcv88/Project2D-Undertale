using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;
    private Vector2 moveDir;

	private void FixedUpdate()
	{
		Move();
	}

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			animator.Play("BackWalk");
        }
		if (Input.GetKey(KeyCode.DownArrow))
		{
			animator.Play("FrontWalk");
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			animator.Play("RightWalk");
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			animator.Play("LeftWalk");
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
}