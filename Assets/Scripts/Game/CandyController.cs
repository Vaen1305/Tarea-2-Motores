using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public int frame;
    public int lifeChanges;
    [SerializeField] int points = 1;
    [SerializeField] private SoundDoor _soundDoor;

    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
            CandyGenerator.instance.ManageCandy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ManagerController.instance.AddPoints(points);
            CandyGenerator.instance.ManageCandy(this);
            SoundController.instance.RunSound(_soundDoor.SoundClip);
        }
    }
}
