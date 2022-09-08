using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackCooldownAmount = 0.5f;
    private CooldownTimer _attackCooldownTimer = new CooldownTimer();
    private bool _isAttacking = false;
    private PlayerHealth _playerHealthReference;
    private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _attackCooldownTimer.cooldownAmount = _attackCooldownAmount;
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void Initialize(GameObject playerToAttack)
    {
        _isAttacking = true;
        _playerHealthReference = playerToAttack.GetComponent<PlayerHealth>();
    }

    public void StopAttacking()
    {
        _isAttacking = false;
    }

    private void Update()
    {
        if (_isAttacking == true)
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        if (_attackCooldownTimer.CooldownComplete == false) return;

        if (_playerHealthReference != null)
        {
            _playerHealthReference.DealDamage(_attackDamage);
            _enemyAnimation.LaunchAttackAnimation();
            _attackCooldownTimer.StartCooldown();
        }
    }
}
