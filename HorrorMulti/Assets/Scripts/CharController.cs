using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 50.0f;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	float gravity = -9.8f;
	private bool gamePaused = false;
	private bool flashlightOn = false;
	public GameObject flashlight;
	public GameObject pauseMenu;


	void Start(){
		character = GetComponent<CharacterController> ();
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

		Flashlight();

		Running();

		PauseMenu();
		
		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);
	}
}
