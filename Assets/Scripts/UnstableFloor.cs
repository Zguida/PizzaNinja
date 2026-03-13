using System.Collections;
using UnityEngine;

public class UnstableFloor : MonoBehaviour
{
    public float fallDelay = 2f;
    public float resetDelay = 2f;
    private float _timer;
    private bool _hasFallen;
    private bool _isOccupied;


    private Vector3 _startPos;
    private Quaternion _startRot;
    private RigidbodyConstraints _startConstraints;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _startPos = transform.position;
        _startRot = transform.rotation;
        _startConstraints = _rb.constraints;
    }

    void Update()
    {
        if (_isOccupied && !_hasFallen)
        {
            _timer += Time.deltaTime;
            if (_timer > fallDelay)
            {
                _hasFallen = true;
                _rb.constraints = RigidbodyConstraints.None;
                _rb.linearVelocity = new Vector3(0, -6f, 0);
                StartCoroutine(ResetState(resetDelay));
            }
        }
    }

    private IEnumerator ResetState(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        transform.position = _startPos;
        transform.rotation = _startRot;

        _rb.constraints = _startConstraints;
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        
        
        _hasFallen = false;
        _timer = 0f;
        _isOccupied = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("Hit by: " + player.gameObject.name);
        
        if (player.gameObject.CompareTag("Player"))
        {
            _isOccupied = true;
        }
    }
}
