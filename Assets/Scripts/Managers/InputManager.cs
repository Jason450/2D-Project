﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerScript player;
    public LevelManager lvlManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        // Pausar el juego
        InputPause();
        // Salto del player
        InputJump();
        // Ataque del player
        Attack();
        // Activar/Desactivar God Mode
        GodMode();
    }

    void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Debug.Log("Pause");
            lvlManager.Pause();
        }
    }

    void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            player.JumpStart();
        }
    }

    void Attack()
    {
        if (player.isActiveAndEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.Shot();
            }
        }
    }

    void GodMode()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            player.GodMode();
        }
    }
}

