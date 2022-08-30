
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public float offset;
    private float _time;
    public float startTime;

    public GameObject bullet;
    public Transform point;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_camera != null)
        {
            var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            var rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }

        if (_time <= 0f)
        {
            if (!Input.GetMouseButtonDown(0)) return;
            Instantiate(bullet, point.position, transform.rotation);
            _time = startTime;
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }
}
