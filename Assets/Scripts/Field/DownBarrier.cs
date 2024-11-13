using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownBarrier : MonoBehaviour
{
    public float maxHp = 100;

    public Slider hpSlider;

    public float carrentHp;

    public float amountDamege = 5f;

    public float damegeInterval = 1f;

    private Coroutine damegecoroutine;

    public GameObject resultPanel;

    void Start()
    {
        carrentHp = maxHp;
        UpdateHp();
    }
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            UpdateHp();

            //時間ダメージ
            if(damegecoroutine == null)
            {
                damegecoroutine = StartCoroutine(AmoutDamage());
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Obstacles"))
       {

            if(damegecoroutine != null)
            {
                StopCoroutine(damegecoroutine);
                damegecoroutine = null;
            }
       }
    }

    IEnumerator AmoutDamage()
    {
        while(carrentHp > 0)
        {
            carrentHp -= amountDamege;
            UpdateHp();
            yield return new WaitForSeconds(damegeInterval);
        }

        if(carrentHp <= 0)
        {
            resultPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateHp()
    {
        hpSlider.value = carrentHp / maxHp;

    }

}
