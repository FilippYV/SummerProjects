using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UIElements;
//using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    //public List<Transform> cameraTransform;
    public Transform cameraTransform;
    public Transform cameraTempTransform;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _fastSpeed;
    [SerializeField] private float _rotationAmount;
    [SerializeField] private Vector3 _zoomAmount;
    //[SerializeField] private float _minLimPos;
    //[SerializeField] private float _maxLimPos;

    private Quaternion _newRotation;
    private Vector3 _newPosition;
    private Vector3 _newZoom;
    //public float maxZoom;
    //public float minZoom;

    private Vector3 _dragStartPosition;
    private Vector3 _dragCurrentPosition;
    private Vector3 _rotateStartPosition;
    private Vector3 _rotateCurrentPosition;


    void Start()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _newZoom = cameraTransform.localPosition;
        _newZoom = cameraTempTransform.localPosition;
    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
    }


    void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            _newZoom += Input.mouseScrollDelta.y * _zoomAmount;
            _newZoom = new Vector3(0, Mathf.Clamp(_newZoom.y, 2, 50), Mathf.Clamp(_newZoom.z, -50, -2));
            //_newRotation *= Quaternion.Euler(Vector3.right * -_rotationAmount);

            //float _newZoomY = _newZoom.y;
            //float _newZoomYM = Mathf.Clamp(_newZoomY, 5, 50);
            //float _newZoomZ = _newZoom.z;
            //float _newZoomZM = Mathf.Clamp(_newZoomZ, 5, 50);
            //Vector3 Xui = new Vector3(0f, _newZoomYM, _newZoomZM);
            //_newZoom = Xui;
        }

        //if (Input.mouseScrollDelta.y != 0)
        //{
        //    if (Input.mouseScrollDelta.y > 0 && newZoom.z < maxZoom)
        //    {
        //        newZoom += Input.mouseScrollDelta.y * zoomAmount;
        //    }
        //    if (Input.mouseScrollDelta.y < 0 && newZoom.z > minZoom)
        //    {
        //        newZoom += Input.mouseScrollDelta.y * zoomAmount;
        //    }
        //}

        if (Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float entry;

            if(plane.Raycast(ray, out entry)) 
            {
                _dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float entry;

            if (plane.Raycast(ray, out entry))
            {
                _dragCurrentPosition = ray.GetPoint(entry);

                _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
            }
        }

        if(Input.GetMouseButtonDown(1)) 
        {
            _rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            _rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = _rotateStartPosition - _rotateCurrentPosition;

            _rotateStartPosition = _rotateCurrentPosition;

            _newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = _fastSpeed;
        }
        else
        {
            _movementSpeed = _normalSpeed;
        }

        //_newPosition = new Vector3(Mathf.Clamp(newPosition.x, -7f, 7f), 0.1f, Mathf.Clamp(newPosition.z, -7f, 7f));
        //newPosition = new Vector3(Mathf.Clamp(_newPosition.x, -_minLimPos, _maxLimPos), 0.1f, Mathf.Clamp(_newPosition.z, -_minLimPos, _maxLimPos));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            _newPosition += (transform.forward * _movementSpeed);
            _newPosition = new Vector3(Mathf.Clamp(_newPosition.x, -20f, 20f), 0.1f, Mathf.Clamp(_newPosition.z, -20f, 20f));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -_movementSpeed);
            _newPosition = new Vector3(Mathf.Clamp(_newPosition.x, -20f, 20f), 0.1f, Mathf.Clamp(_newPosition.z, -20f, 20f));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * -_movementSpeed);
            _newPosition = new Vector3(Mathf.Clamp(_newPosition.x, -20f, 20f), 0.1f, Mathf.Clamp(_newPosition.z, -20f, 20f));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * _movementSpeed);
            _newPosition = new Vector3(Mathf.Clamp(_newPosition.x, -20f, 20f), 0.1f, Mathf.Clamp(_newPosition.z, -20f, 20f));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * _rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * -_rotationAmount);
        }



        if (Input.GetKey(KeyCode.PageUp))
        {
            _newZoom += _zoomAmount * 0.4f;
            _newZoom = new Vector3(0, Mathf.Clamp(_newZoom.y, 2, 50), Mathf.Clamp(_newZoom.z, -50, -2));
            //_newRotation *= Quaternion.Euler(Vector3.right * -_rotationAmount * 2f);
            //_newRotation = new Quaternion(Mathf.Clamp(_newRotation.x, 0, 20), 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            Vector3 _newRotationL = new Vector3(-1, 0, 0);
            _newZoom -= _zoomAmount * 0.4f;
            _newZoom = new Vector3(0, Mathf.Clamp(_newZoom.y, 2, 50), Mathf.Clamp(_newZoom.z, -50, -2));
            //_newRotation *= Quaternion.Euler(Vector3.left * -_rotationAmount * 2f);
            //_newRotation = new Quaternion(Mathf.Clamp(_newRotation.x, 0, 20), 0, 0, 0);
        }


        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, _newZoom, Time.deltaTime * _movementTime);
        cameraTempTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, _newZoom, Time.deltaTime * _movementTime);
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _movementTime);
    }
}
