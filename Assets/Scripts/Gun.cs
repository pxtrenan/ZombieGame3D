using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;

    public Camera fpsCam;

    private float segundos;
    private int segundosToInt;
    
    public Text highScore; 
    public Text highScore2; 

    private int pontosAtual = 0;
    public Text pontos;
    public Text pontos2;
    public Text segundosText;
    public Text segundosText2;
    public Text pontosFinal;
    public Text pontosFinal2;
    

    public AudioClip soundGun;
    public AudioSource somGun;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScore2.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           Shoot();
        }

        segundos += Time.deltaTime;

        

        segundosToInt = (int) segundos;
        segundosText.text = segundosToInt.ToString();
        segundosText2.text = segundosToInt.ToString();
    }

    public void Shoot ()
    {
        
        RaycastHit hit;

        somGun.PlayOneShot(soundGun);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
                
                pontosAtual+=10;
                pontos.text = pontosAtual.ToString();
                pontos2.text = pontosAtual.ToString();
                pontosFinal.text = pontosAtual.ToString();
                pontosFinal2.text = pontosAtual.ToString();
            }
            if (pontosAtual > PlayerPrefs.GetInt("HighScore", 0))
            {
              PlayerPrefs.SetInt("HighScore", pontosAtual);
            }
        }
    }
}
