using System.Collections;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int _currentPointIndex;

    bool _once;
    
    private void Update()
    {
        if (transform.position != patrolPoints[_currentPointIndex].position)
        {
            var transform1 = transform;
            transform1.position = Vector2.MoveTowards(transform1.position, patrolPoints[_currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (_once == false)
            {
                _once = true;
                StartCoroutine(Wait());
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        
        if (_currentPointIndex + 1 < patrolPoints.Length)
        {
            _currentPointIndex++;
        }
        else
        {
            _currentPointIndex = 0;
        }
        _once = false;
    }
}
