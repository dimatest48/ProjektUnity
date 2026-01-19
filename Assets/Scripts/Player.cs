using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent DieEvent = new();

    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;

    private Animator _animator;
    private bool _isAlive = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _characterController.Move(Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);

    }

    public void Die()
    {
        if (_isAlive == false)
            return;

        print("Player is dead");
        _animator.SetTrigger("Die");
        _isAlive = false;
        DieEvent?.Invoke();
    }
}
