using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] PlayerInput input;
    [SerializeField] PlayerMovement movement;
    [SerializeField] ScoreDataBase scoreData;

    private void Update()
    {
        movement.jump = input.jump;
        movement.InputDirectionX = input.InputDirectionX;
        movement.InputDirectionY = input.InputDirectionY;
    }
}
