using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float borders = 2.5f;
    [SerializeField] private float rotateAngle = 70;
    [SerializeField] private Animator _animator;

    private float _oldMousePositionX;
    private float _eulerY;

    private int _runBoolAnimID;

    public Action OnMove;

    private void Start()
    {
        _runBoolAnimID = Animator.StringToHash("Walk");
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            OnMove?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool(_runBoolAnimID, false);
        }
        
        if (Input.GetMouseButton(0))
        {
            _animator.SetBool(_runBoolAnimID, true);
            
            Vector3 newPosition = transform.position + transform.forward * (Time.deltaTime * moveSpeed);
            newPosition.x = Mathf.Clamp(newPosition.x, -borders, borders);
            transform.position = newPosition;
            
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -rotateAngle, rotateAngle);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }
    }
}