using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }; //  causes the function to terminate without proceeding to the rest of the code in that function
        float cycle = Time.time / period;   // Every 2 seconds a cycle will be emerged 
        const float tau = Mathf.PI * 2;  // Constant value of 6.283
        float rawSinWave = Mathf.Sin(cycle * tau);  // Going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2; // It was between -1 & 1 => +1 => 0 & 2 => /2 => 0 & 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
