using UnityEngine;

[System.Serializable]
public class CooldownTimer
{
    private float _cooldownCompleteTime;

    public float cooldownAmount = 0.5f;
    public bool CooldownComplete => Time.time > _cooldownCompleteTime;

    public void StartCooldown()
    {
        _cooldownCompleteTime = Time.time + cooldownAmount;
    }
}
