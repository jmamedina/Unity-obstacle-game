using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Get the start pos of our object
    Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //Get the start pos of our object
        startPos = transform.position;

        //get the hafl way size of box collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the object is less than the start Pos x then it will go back to the start pos
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
