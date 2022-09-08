using UnityEngine;
using TMPro;

public class EnemiesRemainingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesRemainingText;

    public void UpdateEnemiesRemainingText(int enemiesRemaining)
    {
        _enemiesRemainingText.text = $"������ ��������: {enemiesRemaining.ToString()}";
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
