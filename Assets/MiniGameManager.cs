using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameManager : MonoBehaviour
{
    [Header("Health Settings")]
    public Slider healthBar;
    public float maxHealth = 100f;
    public float damagePerPress = 5f;
    public float regenPerSecond = 2f;

    private float currentHealth;
    private bool isRunning = false;
    private Coroutine regenRoutine;

    // เริ่มมินิเกม (เรียกจาก Trigger)
    public void StartMiniGame()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        isRunning = true;

        // เริ่ม Coroutine regen
        if (regenRoutine != null) StopCoroutine(regenRoutine);
        regenRoutine = StartCoroutine(RegenerateHealth());
    }

    private void Update()
    {
        if (!isRunning) return;

        // กด Space ลดเลือด
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= damagePerPress;
            healthBar.value = currentHealth;
            CheckGameOver();
        }
    }

    // เพิ่มเลือดทุก 1 วินาที
    private IEnumerator RegenerateHealth()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(1f);
            currentHealth = Mathf.Min(maxHealth, currentHealth + regenPerSecond);
            healthBar.value = currentHealth;
        }
    }

    private void CheckGameOver()
    {
        if (currentHealth <= 0f)
        {
            isRunning = false;
            // หยุด regen
            if (regenRoutine != null) StopCoroutine(regenRoutine);
            // ปิด Panel มินิเกม
            gameObject.SetActive(false);
        }
    }
}
