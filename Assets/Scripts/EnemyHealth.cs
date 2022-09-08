using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoints = 100f;
    [SerializeField] private float _currentHealthPoints = 100f;
    [SerializeField] private float _damageOnClick = 35f;
    [SerializeField] private float _deathDelay = 1.5f;
    private EnemyAnimation _enemyAnimation;
    private EnemyAttack _enemyAttack;
    private EnemyMovement _enemyMovement;
    private EnemySpawner _enemySpawner;
    [SerializeField] private HealthBar _healthBar;
    private Collider2D _collider;
    private bool _isDying = false;

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _collider = GetComponent<Collider2D>();

        _healthBar.UpdateHealthBar(_maxHealthPoints, _currentHealthPoints);
    }

    private void OnMouseDown()
    {
        _currentHealthPoints -= _damageOnClick;
        _enemyAnimation.LaunchHitAnimation();
        _healthBar.UpdateHealthBar(_maxHealthPoints, _currentHealthPoints);

        if (_currentHealthPoints <= 0 && _isDying == false)
        {
            StartCoroutine(HandleDeath());
            _isDying = true;
            _collider.enabled = false;
        }
    }

    private IEnumerator HandleDeath()
    {
        _healthBar.Deactivate();
        _enemyAnimation.LaunchDeathAnimation();
        _enemyAttack.StopAttacking();
        _enemyMovement.SetCanMove(false);
        _enemySpawner.DecrementEnemiesRemainingCount();

        yield return new WaitForSeconds(_deathDelay);
        Destroy(gameObject);
    }
}
