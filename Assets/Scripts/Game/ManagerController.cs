using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerController : MonoBehaviour
{
    public TMP_Text timerText;
    private float distancia = 0f; 

    public static ManagerController instance;
    [SerializeField] int points = 0;

    private void Update()
    {
        distancia += Time.deltaTime;
        timerText.text = "Distanci: " + distancia.ToString("F0") + " m";
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log("Puntos: " + points);
    }
}
