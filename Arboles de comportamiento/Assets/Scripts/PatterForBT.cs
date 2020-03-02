using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class PatterForBT : MonoBehaviour
{

    public float speed; // Velocidad de movimiento
    public GameObject target; // Personaje a mirar
    public float lookDistance; // Distancia a la que deja de patrullar para mirar al target
    public float timeBetweenPoints; // Tiempo que espera al llegar a un punto de patrulla antes de pasar al siguiente
    public List<Vector3> patrolPoints; // Puntos de la ruta de patrulla

    private int _currentPatrolIndex; // Punto de patrulla actual al que se dirige
    private float _timer; // Temporizador para la espera

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) // En caso de que no hayamos arastrado un target lo buscamos por tag 
            target = GameObject.FindGameObjectWithTag("Player");
        _currentPatrolIndex = 0; // Especificamos que el primer punto de la patrulla
        transform.LookAt(patrolPoints[_currentPatrolIndex]); // Mirar al punto de patrulla actual
    }

    [Task]
    private void UpdatePatrolIndex() // Actualizar el punto de patrulla actual obteniendo el siguiente de la lista, si es el último volvemos al primero
    {
        if (_currentPatrolIndex < patrolPoints.Count - 1)
            _currentPatrolIndex++;
        else
            _currentPatrolIndex = 0;
    }

    [Task]
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.transform.position)<lookDistance)
        {
            Task.current.Fail();
        }

        Task.current.Succeed();
    }

    [Task]
    private void Look()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < lookDistance)
        {
            transform.LookAt(patrolPoints[_currentPatrolIndex]);
        }
        else
        {
            transform.LookAt(target.transform);
        }

        Task.current.Succeed();
    }

    [Task]
    private bool islookingAtPlayer()
    {
        Task.current.Succeed();
        return (Vector3.Distance(transform.position, target.transform.position) <= lookDistance);
    }
    [Task]
    private bool isNearPatrolPoint()
    {
        Task.current.Succeed();
        return (Vector3.Distance(transform.position, patrolPoints[_currentPatrolIndex]) < lookDistance);
    }
}
