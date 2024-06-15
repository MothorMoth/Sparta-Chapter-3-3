using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private InputController _controller;
    private Animator _animator;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _controller = GetComponent<InputController>();
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        _controller.OnClickEvent += OnclickTree;
    }

    private void OnclickTree()
    {
        _animator.SetTrigger("Hit");
        _particleSystem.Play();
    }
}
