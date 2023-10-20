using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using System.Threading;

using UnityEngine.Audio;

using UnityEngine.SceneManagement;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject splashSprite;
    // Start is called before the first frame update
    [SerializeField] private GameObject boomSprite;

    public AudioSource splashAudio; // Water Splash
    public AudioSource explosionAudio; // Explosion

    public GameObject playerBattleship;

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
       
        if(other.tag == "Computer")
        {
            GameObject explosion = Instantiate(boomSprite, transform.position, Quaternion.identity);
            explosionAudio.Play();

            await Task.Delay(1000);

            PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") + 1);

            if (MainMenu.difficulty == "easy"){
                if(PlayerPrefs.GetInt("EasyHighScore") <= PlayerPrefs.GetInt("CurrentScore")){
                    PlayerPrefs.SetInt("EasyHighScore", PlayerPrefs.GetInt("CurrentScore"));
                }
            }
            else if (MainMenu.difficulty == "med"){
                if(PlayerPrefs.GetInt("IntermediateHighScore") <= PlayerPrefs.GetInt("CurrentScore")){
                    PlayerPrefs.SetInt("IntermediateHighScore", PlayerPrefs.GetInt("CurrentScore"));
                }
            }
            else{
                if(PlayerPrefs.GetInt("HardHighScore") <= PlayerPrefs.GetInt("CurrentScore")){
                    PlayerPrefs.SetInt("HardHighScore", PlayerPrefs.GetInt("CurrentScore"));
                }
            }

            float integer = UnityEngine.Random.Range(0, 2);
            if(integer == 0){
                SceneManager.LoadScene("Pacific");
            }
            else if(integer == 1){
                SceneManager.LoadScene("Meditteranean");
            }
            else{
                SceneManager.LoadScene("Arctic");
            }

        }
        
        /*if(other.tag == "Killzone")
        {
            Destroy(this); // Destroys the computer only
        }*/

        if(other.tag == "Water")
        {
            GameObject splash = Instantiate(splashSprite, transform.position, Quaternion.identity);
            splashAudio.Play();
            Destroy(splash, 1f);
            Destroy(gameObject);
        }
    }

   
}
