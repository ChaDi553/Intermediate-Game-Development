using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rigidBody;
    public Vector2 movement;
    public KeyCode jumpKey;
    public Animator playerAnimator;

    private string _currentState;
    private AnimationDirection _playerDirection;

    #region Animation Clips
    public string idle_left;
    public string idle_right;
    #endregion
    public enum AnimationDirection
    {
        Left,
        Right,
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");

        /*if (Input.GetKeyDown(jumpKey))
        {
            playerAnimator.SetBool("movingLeft", true);
        }

        if (Input.GetKeyDown(jumpKey))
        {
            playerAnimator.SetBool("movingRight", false);
        }

          */
    }

    private void FixedUpdate() 
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed);
        if (_playerDirection == AnimationDirection.Right)
       
            ChangeAnimationState(idle_right);
        else if(_playerDirection == AnimationDirection.Left)
            ChangeAnimationState(idle_left);

        if (movement.x > 0)//right
        {
            ChangeAnimationState(idle_right);
            _playerDirection = AnimationDirection.Right;
        }
        if (movement.y > 0)//left
        {
            ChangeAnimationState(idle_left);
            _playerDirection = AnimationDirection.Left;
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) 
            return;
      
        playerAnimator.Play(newState);

        _currentState = newState;
    }
}
