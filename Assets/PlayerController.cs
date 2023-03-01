using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _stepSounds;
    [SerializeField] private float _stepMaxDistance;
    private float _stepDistance;
    private Vector3 _previousPosition;
    private void Start()
    {
        Cursor.visible = false;
        _previousPosition = transform.position;
    }

    private void Update()
    {
        _characterController.Move( transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * _speed, _gravity,
            Input.GetAxis("Vertical") * _speed) * Time.deltaTime));
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        _cameraTransform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y"));

        _stepDistance += (transform.position - _previousPosition).magnitude;
        if (_stepDistance >= _stepMaxDistance)
        {
            _audioSource.PlayOneShot(_stepSounds[Random.Range(0, _stepSounds.Length)]);
            _stepDistance = 0;
        }


        _previousPosition = transform.position;
    }
}
