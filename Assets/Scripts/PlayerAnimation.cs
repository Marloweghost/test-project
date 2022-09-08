using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    public void LaunchHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    public void LaunchDeathAnimation()
    {
        _animator.SetTrigger("Death");
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
