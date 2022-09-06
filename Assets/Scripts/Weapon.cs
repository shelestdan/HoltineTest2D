
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
    
    private void Update()
    {
        
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
