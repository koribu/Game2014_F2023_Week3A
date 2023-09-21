using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;

    [SerializeField]
    private Boundry _boundry;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        float yAxis = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        Debug.Log("This is my x axis input: " + xAxis);
        Debug.Log("This is my y axis input: " + yAxis);

        transform.position = new Vector3(transform.position.x + xAxis, transform.position.y /*+ yAxis*/, 0); //new Vector3(xAxis, yAxis, 0);

        if(transform.position.x < _boundry.xPoint)
        {
            transform.position = new Vector3(_boundry.xPoint, transform.position.y, transform.position.z);
        }

        if(transform.position.x > _boundry.yPoint)
        {
            transform.position = new Vector3(_boundry.yPoint, transform.position.y, transform.position.z);
        }
    }
}
