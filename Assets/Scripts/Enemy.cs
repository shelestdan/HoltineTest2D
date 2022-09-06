using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public float speed = 400f; 
    public float nextWayPointDistance = 3f;
    
    public Transform target;
    
    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;

    private Seeker _seeker;
    private Rigidbody2D _rbEnemy;

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rbEnemy = GetComponent<Rigidbody2D>();

        _seeker.StartPath(_rbEnemy.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        _path = p;
        _currentWaypoint = 0;
    }
    
    void FixedUpdate()
    {
        if (_path == null)
        {
            return;
        }

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        var direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rbEnemy.position).normalized;
        var force = direction * (speed * Time.deltaTime);
            
        _rbEnemy.AddForce(force);

        var distance = Vector2.Distance(_rbEnemy.position, _path.vectorPath[_currentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            _currentWaypoint++;
        }
    }
}
