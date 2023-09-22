using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerSetting : MonoBehaviour
{
    public float RotateY;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0, RotateY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
