using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    #region Handlers
    public void LaunchAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    public void LaunchRunAnimation()
    {
        _animator.SetTrigger("Run");
    }

    public void LaunchDeathAnimation()
    {
        _animator.SetTrigger("Death");
    }

    public void LaunchHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }
    #endregion

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

}
