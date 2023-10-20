using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using System.Threading;

using UnityEngine.Audio;

public class BulletComputer : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject splashSprite;
    // Start is called before the first frame update
    [SerializeField] private GameObject boomSprite;

    public AudioSource splashAudio; // Water Splash
    public AudioSource explosionAudio; // Explosion

    public GameObject gameOverMenu;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    Quaternion rot;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(rb2d.velocity.x, rb2d.velocity.y, transform.position.z)); // This causes the object to rotate to point at wherever the object is heading (Currently causing unneccesary rotation)
        rot.eulerAngles = new Vector3(0, 0, transform.rotation.z * 100);
        transform.rotation = rot;
    }

    async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject explosion = Instantiate(boomSprite, transform.position, Quaternion.identity);
            explosionAudio.Play();
            Destroy(explosion, 1f);

            await Task.Delay(1000);

            Destroy(other.gameObject, 1f);
            gameOverMenu.SetActive(true);
        }


        /*if (other.tag == "Killzone")
        {
            Destroy(this);
        }*/

        if (other.tag == "Water")
        {
            GameObject splash = Instantiate(splashSprite, transform.position, Quaternion.identity);
            splashAudio.Play();
            Destroy(splash, 1f);
            Destroy(gameObject);
        }
    }

}
