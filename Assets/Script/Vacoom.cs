using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacoom : MonoBehaviour
{
    /// <summary>
    ///     WIN/DEATH CONDITIONS
    /// </summary>


    public HealthBar HealthBar;
    public MoneyManager MoneyManager;

    public AudioSource collectSound;
    public AudioSource errorSound;
    public AudioSource bombSound;
    public ParticleSystem particleGarbage;
    public ParticleSystem particleFish;
    public ParticleSystem particleBomb;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garbage"))
        {
            MoneyManager.AddMoney(5);
            HealthBar.Heal(5f);
            DOTween.Restart("one");
            Debug.Log("There is garbage!");
            collectSound.Play();
            Destroy(collision.gameObject);
            particleGarbage.Play();
        }
        if (collision.gameObject.CompareTag("Fish"))
        {
            MoneyManager.ReduceMoney(5);
            DOTween.Restart("-one");
            Debug.Log("There is fish!");
           
            errorSound.Play();
            Destroy(collision.gameObject);
            particleFish.Play();

        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            HealthBar.TakeDamage(70f);
            DOTween.Restart("bombCocpit");
            DOTween.Restart("-one");
            DOTween.Restart("bombScreen");
            Debug.Log("There is bomb!");
            

            bombSound.Play();
            Destroy(collision.gameObject);
            particleBomb.Play();

        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garbage"))
        {
            
            //DOTween.Rewind("one");
            Debug.Log("There is garbage!");
            Destroy(collision.gameObject);
            particleGarbage.Stop();
        }
        if (collision.gameObject.CompareTag("Fish"))
        {
  
            Destroy(collision.gameObject);
            particleFish.Stop();

        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            
            Destroy(collision.gameObject);
            particleBomb.Stop();

        }

    }
}
