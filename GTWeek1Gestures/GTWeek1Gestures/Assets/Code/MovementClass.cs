using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBehaviourClass))]
public class MovementClass : MonoBehaviour
{

    private InputBehaviourClass _input;

    // Use this for initialization
    void Start()
    {
        _input = GetComponent<InputBehaviourClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.Tap())
        {
            Debug.Log("Move!");
        }

        if (_input.DoubleTap())
        {
            /*
Dash Code Here!
*/
            Debug.Log("Dash");
        }
    }
}
