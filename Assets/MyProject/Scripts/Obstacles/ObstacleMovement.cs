using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _canMove = true;

    private float _horizontalValue = 1.0f;
    private float _verticalValue = 1.0f;

    [Header("Movement")]
    [SerializeField] private float _rotationSpeed = 2.0f;
    [SerializeField] private float _translateSpeed = 2.0f;

    [Header("Type")]
    [SerializeField] private bool _rotation = false;
    [SerializeField] private bool _isHorizontal;
    [SerializeField] private bool _isGuard;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void FixedUpdate()
    {
        if (_canMove) 
            Movement(_rotation);
        else if (_isGuard)
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // Si l'obstacle qui ne peut pas bouger est un garde, on met la vélocité à 0.
    }

    private void Movement(bool rotation)
    {
        // Mouvement de rotation.
        if(rotation)
            transform.Rotate(0.0f, 0.0f, _rotationSpeed);

        // Mouvement de translation.
        else
            Translate();
    }

    // Bouge l'obstacle selon l'axe choisi.
    private void Translate()
    {
        Vector3 direction;

        // Choisi la direction voulue.
        if (!_isHorizontal)
            direction = new Vector3(0.0f, 0.0f, _horizontalValue);
        else 
            direction = new Vector3(_verticalValue, 0.0f, 0.0f);

        gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * Time.fixedDeltaTime * _translateSpeed;

        // Tourne l'obstale, seulement si c'est un garde.
        if (_isGuard)
        {
            // Code pris selon la vidéo de Ketra Games sur YouTube: https://www.youtube.com/watch?v=BJzYGsMcy8Q.
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    /* ---------------------
     * Méthodes publiques:
     * ---------------------
     */
    public void SetCanMove(bool canMove) 
    {
        _canMove = canMove;
    }

    // Inverse le mouvement de va-et-viens.
    public void ChangeDirection() 
    {
        _horizontalValue *= -1.0f;
        _verticalValue *= -1.0f;
    }
}
