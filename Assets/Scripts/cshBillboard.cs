using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBillboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Camera cameraToLookAt;

    void Update()
    {
        transform.LookAt(cameraToLookAt.transform);
    }
}
