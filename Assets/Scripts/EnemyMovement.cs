using UnityEngine;

[RequireComponent(typeof(EnemyAttack))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    private bool _isPlayerNearby = false;
    private bool _isAttacking = false;
    private bool _isRunning = false;
    private bool _canMove = true;

    [SerializeField] private EnemyAttack _enemyAttack;
    private GameObject _playerReference;
    private EnemyAnimation _enemyAnimation;

    public void SetCanMove(bool _value)
    {
        _canMove = _value;
    }

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        if (_isPlayerNearby == false && _canMove)
        {
            PerformMovement();
        }
        else if (_isAttacking == false && _playerReference != null)
        {
            _enemyAttack.Initialize(_playerReference);
            _isAttacking = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            _isPlayerNearby = true;
            _playerReference = collision.gameObject;
        }
    }

    private void PerformMovement()
    {
        transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);

        if (_isRunning == false)
        {
            _enemyAnimation.LaunchRunAnimation();
            _isRunning = true;
        } 
    }
}
