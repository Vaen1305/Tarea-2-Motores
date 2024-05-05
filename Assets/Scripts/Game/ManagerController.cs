using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{
    public static ManagerController instance;
    [SerializeField] int points = 0;

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
