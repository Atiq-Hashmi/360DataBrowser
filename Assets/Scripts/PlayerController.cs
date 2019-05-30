using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    //[SerializeField] AudioClip mainSound;
    //AudioSource audioSource;
    float moveSpeed = 12f;
    float rotSpeed = 25f;
    //float yrot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidBody = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        //audioSource.PlayOneShot(mainSound);
        TranslationController();
        RotationController();
        GetCursorBack();
        
    }

    //cursor is locked
    private void TranslationController()
    {
        
        float horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");
        //print("horizontal value"+horizontalMove);
        float verticalMove = CrossPlatformInputManager.GetAxis("Vertical");
        //print("vertical value" + verticalMove);

        float speedFactor = moveSpeed * Time.deltaTime;
        horizontalMove = speedFactor * horizontalMove;
        verticalMove = speedFactor * verticalMove;
        transform.Translate(horizontalMove, 0, verticalMove);
    }
    private void RotationController()
    {
        //rigidBody.freezeRotation = true;
        float AxisRY = CrossPlatformInputManager.GetAxis("RotationY");
        //float AxisRX = CrossPlatformInputManager.GetAxis("RotationX");
        //print(AxisRY);
        float rotAlongY = AxisRY * rotSpeed * Time.deltaTime;
        //float rotAlongX = AxisRX * rotSpeed * Time.deltaTime;

        if (Mathf.Abs(AxisRY) > 0.25f)
        {
            transform.Rotate(0f, rotAlongY, 0f);
        }
      
        // rigidBody.freezeRotation = false;
    }

    private static void GetCursorBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}