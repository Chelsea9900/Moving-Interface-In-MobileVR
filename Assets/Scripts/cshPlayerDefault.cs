using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshPlayerDefault : MonoBehaviour
{
    public Camera RayCamera;
    private int MoveState = 0; // 0: Stop, 1: Forward, 2: Backward, 3: Jump

    private CharacterController controller;
    private Vector3 velocity;
    
    private float gravity = 20.0f;
    private bool m_jumpOn = false;

    public Transform trBody;
    public float m_moveSpeed = 2.0f;

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
            if(hit.transform.gameObject.name == "Forward")
            {
                MoveState = 1;
                velocity = trBody.forward;
            }
            else if(hit.transform.gameObject.name == "Backward")
            {
                MoveState = 2;
                velocity = -1.0f * trBody.forward;
            }
            else if (hit.transform.gameObject.name == "Jump")
            {
                MoveState = 3;
                m_jumpOn = true;
            }
            Debug.Log(MoveState + ", " + hit.transform.gameObject.name);
        }
        else
        {
            Debug.DrawRay(RayCamera.transform.position, RayCamera.transform.forward * 1000, Color.red);
            MoveState = 0;
            m_jumpOn = false;
            velocity = new Vector3(0.0f, velocity.y, 0.0f);
        }


        //Character Controller
        if (controller.isGrounded)
        {
            if (m_jumpOn)
            {
                velocity.y = 5.0f;
                m_jumpOn = false;
            }
        }
        Debug.Log(velocity);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * m_moveSpeed * Time.deltaTime);

    }
}
