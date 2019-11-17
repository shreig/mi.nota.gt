using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOut : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = speed * Time.deltaTime;

        transform.Translate(direction * translation);
    }

    public void Initialize(float speed, Vector3 direction)
    {
        this.speed = speed;
        this.direction = direction;
    }
}
