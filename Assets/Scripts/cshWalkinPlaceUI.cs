using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshWalkinPlaceUI : MonoBehaviour
{
    public Transform trBody;
    public float damping = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = transform.localRotation;
        desiredRotation = Quaternion.Euler(0.0f, trBody.localRotation.eulerAngles.y, 0.0f);
            
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, Time.deltaTime * damping);
    }
}
