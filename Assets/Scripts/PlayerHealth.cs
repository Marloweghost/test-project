using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoints = 150f;
    [SerializeField] private float _currentHealthPoints = 150f;
    [SerializeField] private float _deathDelay = 1f;
    private PlayerAnimation _playerAnimation;
    [SerializeField] private HealthBar _healthBar;

    public void DealDamage(float _damageAmount)
    {
        _currentHealthPoints -= _damageAmount;
        _playerAnimation.LaunchHitAnimation();
        _healthBar.UpdateHealthBar(_maxHealthPoints, _currentHealthPoints);

        if (_currentHealthPoints <= 0)
        {
            StartCoroutine(HandleDeath());
        }
    }

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _healthBar.UpdateHealthBar(_maxHealthPoints, _currentHealthPoints);
    }

    private IEnumerator HandleDeath()
    {
        _healthBar.Deactivate();
        _playerAnimation.LaunchDeathAnimation();
        yield return new WaitForSeconds(_deathDelay);
        EndgameHandler.instance.Initialize(EndgameHandler.GameState.Loss);
        Destroy(gameObject);
    }
}
