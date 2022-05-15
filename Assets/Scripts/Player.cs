using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject projectitle;

    public Transform shootingPoint;

    public AudioSource aus;

    public AudioClip shootingS;

    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_gc.IsGameOver())
		{
            return;
		}
        float xDir = Input.GetAxisRaw("Horizontal");

        if ((xDir < 0 && transform.position.x <= -8.5) || (xDir > 0 && transform.position.x >= 6.5))
            return;
        // Vector3.right = (1,0,0)
        transform.position += Vector3.right * moveSpeed * xDir *Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space))
		{
            Shoot();
		}
    }

    public void Shoot()
	{
        if(projectitle && shootingPoint)
		{
            if (aus && shootingS)
			{
                aus.PlayOneShot(shootingS);
			}

            Instantiate(projectitle, shootingPoint.position, Quaternion.identity);
		}
	}
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Enemy"))
		{
            m_gc.SetGameOver(true);
            Destroy(col.gameObject);

            Debug.Log("Da va Player, GameOver");
		}
	}
}
