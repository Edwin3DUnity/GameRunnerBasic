using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 25), Tooltip("Fuerza de salto")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;


    [SerializeField, Tooltip("Está en el suelo ")]
    private bool isGround;

    private Animator _animator;


    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER="SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";

    private const string DEATH = "Death_b";
    private bool isDeath ;
    
    private const string DEATH_TYPE = "DeathType_int" ;
    private int deathTypeInt;
    
    
    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }


    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _animator.SetFloat(SPEED_MULTIPLIER, 0.6f);


       
    }

    // Update is called once per frame
    void Update()
    {
      Jump();  
      
    }

    private void Jump()
    {
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + Time.time / 10);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            
            
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
           
            
            isGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                _animator.SetFloat(SPEED_F, 0);
                
                
                _animator.SetBool(DEATH, isDeath = true );
                deathTypeInt = Random.Range(1,3);
                _animator.SetInteger(DEATH_TYPE, deathTypeInt);

            }
        }
    }
}
