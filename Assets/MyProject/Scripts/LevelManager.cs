using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Attributs
    private float _addTime = 0.0f;
    private float _subTime = 0.0f;
    private float _timer = 0.0f;
    private bool _endGame;

    private float[] _diamonds = { 0.0f, 0.0f, 0.0f };
    private float[] _obstacles = { 0.0f, 0.0f, 0.0f };
    private float[] _time = { 0.0f, 0.0f, 0.0f };

    private int _indexLevel = 0;

    // Méthodes privées:
    private void Awake()
    {
        int nLevelManager = FindObjectsOfType<LevelManager>().Length;

        if (nLevelManager > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _endGame = false;

        // Instructions.
        StartingInstruction();
    }

    private void Update()
    {
        ChangeTime();

        if (_endGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }

    private void ChangeTime()
    {
        if (!_endGame)
            _timer = Time.time + _addTime - _subTime;
    }

    private static void StartingInstruction()
    {
        Debug.Log("*** Course à Obstacle ***");
        Debug.Log("1. Finir les trois niveaux le plus rapidement possible.");
        Debug.Log("2. Diamant = +1s au temps final, Obstacle = -1s au temps final.");
        Debug.Log("3. Les clés ouvrent les portes et la plaque de pression ouvre un passage.");
        Debug.Log("4. Appuyer sur E pour mettre une copie, E (encore) pour la détruire.");
        Debug.Log("5. La copie sert de distraction pour les gardes et de corps pour les plaques de pression.");
        Debug.Log("6. Le portail violet est l'arrivée.");
        Debug.Log("Bonne chance!");
    }

    // Méthodes publics:
    public void AddTime()
    {
        _addTime += 1.0f;
    }

    public void SubTime()
    {
        _subTime += 1.0f;
    }

    public void LevelStatistics() 
    {
        _diamonds[_indexLevel] = _addTime;
        _obstacles[_indexLevel] = _subTime;
        _time[_indexLevel] = _timer;

        if (_indexLevel != 0)
        {
            for (int i = _indexLevel - 1; i >= 0; i--)
            {
                _diamonds[_indexLevel] -= _diamonds[i];
                _obstacles[_indexLevel] -= _obstacles[i];
                _time[_indexLevel] -= _time[i];
            }
        }
        
        _indexLevel++;
    }

    public void GameOver()
    {
        _endGame = true;
        FindObjectOfType<PlayerMovement>().GameOver();

        Debug.Log("Partie terminée!");

        for (int i = 0; i < 3; i++)
            Debug.Log("Niveau " + (i+1).ToString() + ": " + _time[i].ToString("#.") + "s, Diamants collectés: " + _diamonds[i].ToString("#.") + ", Obstacles touchés: " + _obstacles[i].ToString("#.") + ".");
       
        Debug.Log("Total: " + _timer.ToString("#.") + "s, Diamants collectés: " + _addTime.ToString("#.") + ", Obstacles touchés: " + _subTime.ToString("#.") + ".");
    }
}
