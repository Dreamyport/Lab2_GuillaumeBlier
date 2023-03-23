using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _madeCopy = false;

    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _copy;
    [SerializeField] private Transform _copyStartLocation;

    [SerializeField] private bool _onIce = false;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _sprintSpeed = 12f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _gravity = 9.81f;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Update() 
    {
        // Gestion de la copie.
        if (Input.GetKeyDown(KeyCode.E) && !_madeCopy)
            CreateCopy();
        else if (Input.GetKeyDown(KeyCode.E) && _madeCopy) 
            DeleteCopy();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 direction = GetDirection();

        // On regarde si le joueur court.
        if (Input.GetKey(KeyCode.LeftShift))
            PushPlayer(direction, _sprintSpeed);
        else
            PushPlayer(direction, _moveSpeed);
    }

    // On retourne la direction du joueur.
    private Vector3 GetDirection()
    {
        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        return new Vector3(xPos, 0f, zPos);
    }

    private void PushPlayer(Vector3 direction, float speed)
    {
        // Bouge le joueur en fonction du terrain.
        if (!_onIce)
        {
            _rb.velocity = direction.normalized * Time.fixedDeltaTime * speed;
            _rb.AddForce(Vector3.down * _gravity);
        }
        else
        {
            _rb.AddForce(direction.normalized * Time.fixedDeltaTime * speed);
        }

        // Code pris selon la vidéo de Ketra Games sur YouTube: https://www.youtube.com/watch?v=BJzYGsMcy8Q.
        if (direction.normalized != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    // On déplace la copie à la position du joueur pour créer l'illusion d'instanciation d'objet.
    private void CreateCopy() 
    {
        _copy.transform.position = transform.position;
        _copy.transform.rotation = transform.rotation;
        _madeCopy = true;
    }

    // On remet la copie en dessous du terrain pour créer l'illusion de destruction.
    private void DeleteCopy()
    {
        _copy.transform.position = _copyStartLocation.position;
        _madeCopy = false;
    }

    /* ---------------------
     * Méthodes publiques:
     * ---------------------
     */

    // Pour savoir si le joueur à fait une copie.
    public bool GetMadeCopy() 
    {
        return _madeCopy;
    }

    // Partie terminé, on désactive le joueur.
    public void GameOver()
    {
        this.gameObject.SetActive(false);
    }
}
