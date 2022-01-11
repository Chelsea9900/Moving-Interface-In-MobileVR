using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerWalkinPlace : MonoBehaviour
{
    public Camera RayCamera;
    public int WalkStep = 0; // 0: Init, 1: Left, 2: Right
    public int MoveState = 0; // 0: Stop, 1: Forward
    private int preWalkStep;
    private float delayTime = 0.0f;

    private bool isOneSide = false;

    private CharacterController controller;
    private Vector3 velocity;

    private float gravity = 20.0f;

    public Transform trBody;
    public float m_moveSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("MovementUI");  // MovementUI 레이어만 충돌 체크함
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(RayCamera.transform.position, RayCamera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(RayCamera.transform.position, RayCamera.transform.forward * hit.distance, Color.yellow);
            if (hit.transform.gameObject.name == "Left")
            {
                WalkStep = 1;
                if(Mathf.Abs(preWalkStep - WalkStep) == 1)
                    delayTime = 0.0f;
            }
            else if (hit.transform.gameObject.name == "Right")
            {
                WalkStep = 2;
                if (Mathf.Abs(preWalkStep - WalkStep) == 1)
                    delayTime = 0.0f;
            }
            else
            {
                isOneSide = false;
            }
        }
        else
        {
            Debug.DrawRay(RayCamera.transform.position, RayCamera.transform.forward * 1000, Color.red);
            isOneSide = false;
            //velocity = new Vector3(0.0f, velocity.y, 0.0f);
        }
        if(WalkStep > 0)
        {
            if (delayTime >= 0.5f)
            {
                if (Mathf.Abs(preWalkStep - WalkStep) == 0)
                {
                    isOneSide = true;
                }
                //MoveState = 0;
                WalkStep = 0;
                delayTime = 0.0f;
            }
            else
            {
                delayTime += Time.deltaTime;
            }
        }
        else
        {
            MoveState = 0;
        }

        if(isOneSide)
            MoveState = 0;
        else if (delayTime < 1.0f && Mathf.Abs(preWalkStep - WalkStep) == 1 && WalkStep>0)
            MoveState = 1;


        //Character Controller
        if (controller.isGrounded)
        {
            if(MoveState == 1)
                velocity = trBody.forward;
            else
                velocity = new Vector3(0.0f, velocity.y, 0.0f);
            /*
            if((preWalkStep == 1 && WalkStep == 2) || (preWalkStep == 2 && WalkStep == 1))
            {
                velocity = trBody.forward;
            }
            else
            {
                velocity = new Vector3(0.0f, velocity.y, 0.0f);
            } */
        }
        //Debug.Log(velocity);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * m_moveSpeed * Time.deltaTime);
        preWalkStep = WalkStep;
    }
}
