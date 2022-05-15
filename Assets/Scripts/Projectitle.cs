using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectitle : MonoBehaviour
{
    Rigidbody2D m_rb;

    public float speed;

    public float timeToDestroy;

    GameController m_gc;

    AudioSource aus;

    public AudioClip hitS;

    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeToDestroy);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector2.up = (0,1)
        m_rb.velocity = Vector2.up * speed;
    }
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Enemy"))
		{
            /// tang diem so cua nguoi choi
            m_gc.ScoreIncrement();

			if (aus && hitS)
			{
                aus.PlayOneShot(hitS);
			}

			if (hit)
			{
                Instantiate(hit, col.transform.position, Quaternion.identity);
			}

            Destroy(gameObject);
            Destroy(col.gameObject);

            Debug.Log("Vien dan va cham");
		}
        else if (CompareTag("ScenceLimit"))
		{
            Destroy(gameObject);
		}
	}
}
