using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    public State state; // Estado actual
    public float speed; // Velocidad de movimiento
    public GameObject target; // Personaje a mirar
    public float lookDistance; // Distancia a la que deja de patrullar para mirar al target
    public float timeBetweenPoints; // Tiempo que espera al llegar a un punto de patrulla antes de pasar al siguiente
    public List<Vector3> patrolPoints; // Puntos de la ruta de patrulla

    private int _currentPatrolIndex; // Punto de patrulla actual al que se dirige
    private float _timer; // Temporizador para la espera

    public enum State // Tres estados (Patrulla, esperar en punto de patrulla y mirar al jugador)
    {
        Patrol, Wait, Looking
    }

    void Start()
    {
        if(target == null) // En caso de que no hayamos arastrado un target lo buscamos por tag 
            target = GameObject.FindGameObjectWithTag("Player");
        _currentPatrolIndex = 0; // Especificamos que el primer punto de la patrulla
        transform.LookAt(patrolPoints[_currentPatrolIndex]); // Mirar al punto de patrulla actual
        state=  State.Looking;

    }

    void Update()
    {
       /* switch(state) // Switch dependiendo del estado actual
        {
            cases....
        }
        */
    }

    private void UpdatePatrolIndex() // Actualizar el punto de patrulla actual obteniendo el siguiente de la lista, si es el último volvemos al primero
    {
        if (_currentPatrolIndex < patrolPoints.Count - 1)
            _currentPatrolIndex++;
        else
            _currentPatrolIndex = 0;
    }

    [ContextMenu("AddPatrolPoint")] // Añade a través del inspector un nuevo punto de patrulla
    public void AddPatrolPoint()
    {
        patrolPoints.Add(transform.position);
    }
}