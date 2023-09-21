using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;

    [SerializeField]
    private Boundry _boundry;

    Vector3 _destination;

    Camera _camera;

    [SerializeField]
    bool _isUsingMobile = false;

        // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        _isUsingMobile = Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isUsingMobile)
            GetTouchInput();
        else
            GetConventionalInput();
     

        Move();

    }

    void GetTouchInput()
    {

        foreach (Touch touch in Input.touches)
        {
            _destination = _camera.ScreenToWorldPoint(touch.position);
            _destination = new Vector3(_destination.x, _destination.y, 0);

        }
    }

    void GetConventionalInput()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        float yAxis = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        _destination = new Vector3(transform.position.x + xAxis, transform.position.y, 0);
    }

    void Move()
    {
        transform.position = _destination;


        if (transform.position.x < _boundry.xPoint)
        {
            transform.position = new Vector3(_boundry.xPoint, transform.position.y, transform.position.z);
        }

        if (transform.position.x > _boundry.yPoint)
        {
            transform.position = new Vector3(_boundry.yPoint, transform.position.y, transform.position.z);
        }
    }
}
