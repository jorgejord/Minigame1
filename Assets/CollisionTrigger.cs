using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    // เชื่อมหน้า Panel ของมินิเกม
    public GameObject miniGamePanel;

    private void OnCollisionEnter(Collision collision)
    {
        // ถ้าชนกับ Enemy (ตรวจด้วย Tag ช็คดีๆอย่าลืมเปลี่ยน)
        if (collision.collider.CompareTag("Enemy"))
        {
            // เปิดมินิเกม
            miniGamePanel.SetActive(true);

            // เรียกเริ่มมินิเกม
            MiniGameManager mg = miniGamePanel.GetComponent<MiniGameManager>();
            if (mg != null)
                mg.StartMiniGame();
        }
    }
}
