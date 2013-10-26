using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float gravity = 0.8F;
	public float velocity = 0F;
	public float speed = 10F;
	public float jumpPower = 10F;
	
	private CharacterController characterController;
	private SpriteController spriteController;
	private Vector3 moveDirection = Vector3.zero;
	
	private bool inputJump = false;
	private bool lookRight = true;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		spriteController = GetComponent<SpriteController>();
	}
	
	// Update is called once per frame
	void Update () {
		InputCheck();
		Move();
		SetAnimation();
	}
	
	void InputCheck () {
		velocity = Input.GetAxis("Horizontal") * speed;
		if (velocity > 0) {
			lookRight = true;
		}
		if (velocity < 0) {
			lookRight = false;
		}
		if (Input.GetKeyDown(KeyCode.Space)){
			inputJump = true;
		} else {
			inputJump = false;
		}
	}
	
	void Move () {
		if (characterController.isGrounded) {
			if (inputJump) {
				moveDirection.y = jumpPower;
			}
		}
		moveDirection.x = velocity;
		moveDirection.y -= gravity;
		characterController.Move(moveDirection * Time.deltaTime);
	}
	
	void SetAnimation () {
		if (velocity > 0) {
			spriteController.SetAnimation(SpriteController.AnimationType.goRight);
		}
		if (velocity < 0) {
			spriteController.SetAnimation(SpriteController.AnimationType.goLeft);
		}
		if (velocity == 0) {
			if (lookRight) {
				spriteController.SetAnimation(SpriteController.AnimationType.stayRight);
			} else {
				spriteController.SetAnimation(SpriteController.AnimationType.stayLeft);
			}
		}
		if (!characterController.isGrounded) {
			if (lookRight) {
				spriteController.SetAnimation(SpriteController.AnimationType.jumpRight);
			} else {
				spriteController.SetAnimation(SpriteController.AnimationType.jumpLeft);
			}
		}
	}

}
