﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    // Start is called before the first frame update
    //public Animator _anim;
    public bool damageToGive = true;
    public Transform slenderman;
    public Transform character;
    public GameObject deathMenu;
    

    private void Start()
    {
        Debug.Log("playerdetah calisti");
    }

    void Update()
    {
        Vector2 vCharacter = GameObject.Find("Character").transform.position;
        Vector2 vSlenderman = GameObject.Find("Slenderman").transform.position;
        Vector2 maxOffset = new Vector2(2f, 2f);

        if (MyMath.Equal(vCharacter, vSlenderman, maxOffset))
        {
            //Destroy(character);
            Debug.Log("Character and Objects are closer than maxOffset.");
            DeathMenu();
        }
    }

    void DeathMenu()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    

    public static class MyMath
    {
        public static bool Equal(Vector2 _v1, Vector2 _v2, Vector2 _e)
        {
            return System.Math.Abs(_v1.x - _v2.x) <= _e.x &&
                   System.Math.Abs(_v1.y - _v2.y) <= _e.y;
        }
    }
}
