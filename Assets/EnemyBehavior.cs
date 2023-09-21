using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    float _speedForward;

    [SerializeField]
    Boundry _verticalBoundry;

    [SerializeField]
    Boundry _horizontalBoundry;

    // Start is called before the first frame update
    void Start()
    {
        _speedForward = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y - _speedForward * Time.deltaTime,
            transform.position.z);

        if(_verticalBoundry.yPoint > transform.position.y)
        {
            transform.position = new Vector3(Random.Range(_horizontalBoundry.xPoint,_horizontalBoundry.yPoint)    /*transform.position.x*/, _verticalBoundry.xPoint, transform.position.z);


        }
    }
}
