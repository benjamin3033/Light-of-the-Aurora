using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headBobbing : MonoBehaviour
{
    [SerializeField] private bool _enable = true;

    [SerializeField, Range(0, 0.1f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float _frequency = 10.0f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private float _toggleSpeed = 0.999f;
    private Vector3 _startPos;
    private CharacterController _controller;

    PlayerMovment playermovment = null;

    private void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _startPos = _camera.localPosition;

        playermovment = gameObject.GetComponent<PlayerMovment>();
    }

    void Update()
    {
        if (!_enable) return;

        CheckMotion();
        ResetPosition();
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;

    }

    private void CheckMotion()
    {
        float speed = new Vector3(playermovment.move.x, 0, playermovment.move.z).magnitude;

        Debug.Log(speed);
        if (speed < _toggleSpeed) return;
        if (!playermovment.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }


}
