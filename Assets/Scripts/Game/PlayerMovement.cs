using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    private Vector2 _movement;
    [SerializeField] private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        SetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
        if (_movement.y > 0 && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (_movement.y < 0 && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if (other.tag == "Enemy")
        {
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(), this);
            StartCoroutine(Invulnerability());
            transform.position = initialPosition;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private IEnumerator Invulnerability()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;

        yield return new WaitForSeconds(1f);

        collider.enabled = true;
    }
}
