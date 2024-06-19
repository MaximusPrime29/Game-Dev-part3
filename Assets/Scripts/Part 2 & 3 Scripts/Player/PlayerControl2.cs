using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    
    private Rigidbody objRb;
    [SerializeField]
    private float speed;   
    public float jumpForce;
    private const float Gravity = -9.18f;
    [SerializeField]
    private float gravityScaleMultiplier = 50;
    private float target;

    private float originalJumpForce;

    private bool IsGrounded()
    {
        //Will not allow for the user to double jump
        return Mathf.Approximately(objRb.velocity.y, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        objRb = GetComponent<Rigidbody>();

        originalJumpForce = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
       //Creates "Lanes" as player movement is restricted 
        if (Input.GetKeyDown(KeyCode.A))
        {
            target -= 3;
            target = Mathf.Clamp(target, -3, 3);
        }
        else if(Input.GetKeyDown(KeyCode.D)) 
        {
            target += 3;
            target = Mathf.Clamp(target, -3, 3);
        }

        //Jump with physics
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            if (PickUpManager.jumpBoost==false)
            {
                jumpForce= originalJumpForce;
            }
            if(PickUpManager.jumpBoost==true)
            {
                jumpForce = 23;

            }
            objRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        //Movement between lanes
        Vector3 movePos = Vector3.MoveTowards(objRb.position, new Vector3(target, objRb.position.y, objRb.position.z), speed * Time.fixedDeltaTime);
        objRb.MovePosition(movePos);
        //Home made gravity to control jump fall
        objRb.AddForce(Gravity * gravityScaleMultiplier * Vector3.up, ForceMode.Acceleration);
    }

    
}
