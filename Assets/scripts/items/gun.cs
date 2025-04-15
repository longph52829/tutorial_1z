using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform fire_point;
    public int max_ammor;
    public int current_ammor;
    public float fire_rate;
    public audio_manager audio_manager;
    public TextMeshProUGUI ammor_text;
    
    float next_fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_ammor = max_ammor;

        ammor_text.text = $"{current_ammor}";
    }

    // Update is called once per frame
    void Update()
    {
        rotate_gun();
        shoot();
        reload();
    }

    void rotate_gun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 ||
            Input.mousePosition.y > Screen.height)
        {
            return;
        }
        
        var mouse_pos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    public void shoot()
    {
        if (Input.GetMouseButtonDown(0) && current_ammor > 0 && Time.time > next_fire)
        {
            next_fire = Time.time + fire_rate;
            Instantiate(bullet, fire_point.position, fire_point.rotation);
            current_ammor -= 1;
            ammor_text.text = $"{current_ammor}";
            audio_manager.play_shoot();
        }
    }

    void reload()
    {
        if (Input.GetMouseButtonDown(1) && current_ammor < max_ammor)
        {
            current_ammor = max_ammor;
            ammor_text.text = $"{current_ammor}";
            audio_manager.play_reload();
        }
    }
}
