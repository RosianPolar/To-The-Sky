using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 0.25f;
	[SerializeField]
	float rayLength  = 1.4f;

	[SerializeField]
	float rayOffsetX = 0.5f;
	[SerializeField]
	float rayOffsetY = 0.5f;
	[SerializeField]
	float rayOffsetZ = 0.5f;



	Vector3 targetPosition;
	Vector3 startPosition;
	bool moving;

	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce;
	private CharacterController controller;


	private void Start() {
		controller = GetComponent<CharacterController>();
	}


	void Update()
	{
		if (controller.isGrounded)
		{
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				verticalVelocity = jumpForce;
			}
		}
		else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
		controller.Move(moveVector * Time.deltaTime);


		if (moving) {
			if (Vector3.Distance(startPosition, transform.position) > 1f) {
				transform.position = targetPosition;
				moving = false;
				return;
			}

			transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
			return;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (CanMove(Vector3.forward)) { 
				targetPosition = transform.position + Vector3.forward;
				startPosition = transform.position;
				moving = true;
			}
			} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
				if (CanMove(Vector3.back)){
					targetPosition = transform.position + Vector3.back;
					startPosition = transform.position;
					moving = true;
				}
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow)){
				if (CanMove(Vector3.left)){
					targetPosition = transform.position + Vector3.left;
					startPosition = transform.position;
					moving = true;
				//play sounds
				}
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow)){
				if (CanMove(Vector3.right)){
					targetPosition = transform.position + Vector3.right;
					startPosition = transform.position;
					moving = true;
				}
			}


		bool CanMove(Vector3 direction)
		{
			if (Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction))
			{
				if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, rayLength)) return false;
				if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, rayLength)) return false;
			}
			else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
			{
				if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, rayLength)) return false;
				if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, rayLength)) return false;
			}
			
			return true;
		}

	}




}
