using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinMovement : MonoBehaviour
{
    
    public float _maxBounce;
   public float _bounceSpeed;
    public float _rotateSpeed;
    private float _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, _rotateSpeed, 0));

        if (transform.position.y > _initialPosition + _maxBounce)
        {
            _bounceSpeed = -_bounceSpeed;
        }else if (transform.position.y < _initialPosition)
        {
            _bounceSpeed = -_bounceSpeed;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + _bounceSpeed, transform.position.z);
    }
}
