using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	public GameObject flashlight;
	private bool flashlightOn = false;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;
	public GameObject pauseMenu;
	private bool gamePaused = false;


	void Start(){
		//LockCursor ();
		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
	}

	

	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}

	void PauseMenu()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (gamePaused == false)
			{
				Time.timeScale = 0f;
				pauseMenu.SetActive(true);
				gamePaused = true;
			} else if(gamePaused==true)
            {
				ResumeGame();
            }
			
		}
	}

	public void ResumeGame()
    {
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		gamePaused = false;
	}

	void Flashlight()
    {
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (flashlightOn == true)
			{
				flashlight.SetActive(false);
				flashlightOn = false;
			}
			else if (flashlightOn == false)
			{
				flashlight.SetActive(true);
				flashlightOn = true;
			}
		}
	}

	void Running()
    {
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = speed*1.5f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 10.0f;
		}
	}


	void Update(){
		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;


		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();

		Flashlight();

		Running();

		PauseMenu();
		


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);

		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);
	}


	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}




}
