using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float _horizontalMultiplier;
    [SerializeField] private float _speed;
    private Vector2 _movement;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * _horizontalMultiplier);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement.magnitude < 1 ? _movement * _speed : _movement.normalized * _speed;
    }
}
