using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

   public GameObject player;

   public float health;

   public GameObject lifebar5;
   public GameObject lifebar4;
   public GameObject lifebar3;
   public GameObject lifebar2;
   public GameObject lifebar5BG;
   public GameObject lifebar4BG;
   public GameObject lifebar3BG;
   public GameObject lifebar2BG;
   public GameObject spawnZombies;

   InterstitialAd interstitial;
   

   public GameObject cameradeath;

    public bool cursorOn;
   //public AudioSource punch;
  // public AudioClip punchsound;

    Vector3 velocity;


    public void ShowInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }
    }
  
  void Start()
  {
    RequestInterstitialAds();
  }

  private void RequestInterstitialAds()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3526702404345714/9438035770";
#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
			string adUnitId = "unexpected_platform";
#endif

        // Iniciando um anuncio em tela cheia apos alguma acao
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    // Update is called once per frame
    void Update()
    {
       

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

      

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

         if (health == 10)
        {
            lifebar5.gameObject.SetActive(false);
            lifebar5BG.gameObject.SetActive(true);
            //punch.PlayOneShot(punchsound);
        }
         if (health == 20)
        {
            lifebar4.gameObject.SetActive(false);
            lifebar4BG.gameObject.SetActive(true);
        }
         if (health ==30)
        {
            lifebar3.gameObject.SetActive(false);
            lifebar3BG.gameObject.SetActive(true);
        }
         if (health == 40)
        {
            lifebar2.gameObject.SetActive(false);
            lifebar2BG.gameObject.SetActive(true);
        }
         if (health == 50)
        {
            Destroy(gameObject);
            cameradeath.SetActive(true);
            ShowInterstitialAd();
           
            
            spawnZombies.SetActive(false);
        }

        

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            health+=10;
            
        }
    }

   
}
