using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer render;
    [SerializeField] Animator animator;

    [SerializeField] float movePower;
    private Vector2 moveDir;

	private void FixedUpdate()
	{
		Move();
	}

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			Debug.Log("UpArrow down");
			animator.Play("BackWalk");
        }
		if (Input.GetKey(KeyCode.DownArrow))
		{
			// nowMode = downAnime;
			animator.Play("FrontWalk");
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			// nowMode = rightAnime;
			animator.Play("RightWalk");
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// nowMode = leftAnime;
			animator.Play("LeftWalk");
		}
	}

	private void Move()
    {
        transform.position += new Vector3(moveDir.x * movePower, moveDir.y * movePower, 0) * Time.deltaTime;
        // rigid.AddForce(Vector2.right * moveDir.x);
    }

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}