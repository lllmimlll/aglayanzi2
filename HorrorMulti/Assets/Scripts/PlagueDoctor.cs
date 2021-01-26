using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctor : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y-20, transform.eulerAngles.z);
    }
}
