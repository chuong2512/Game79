using System.Collections;
using System.Collections.Generic;
using Assets.BanSung.Scripts;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject spark;
    public AudioClip _amThanh;

    public float timeShot = 1;
    private float _counter;

    void Start()
    {
        _counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShot();
        }

        _counter -= Time.deltaTime;
    }

    private WaitForSeconds _seconds = new WaitForSeconds(0.01f);

    private void Shot()
    {
        if (gameObject.activeSelf)
        {
            if (_counter < 0)
            {
                if (GameDataManager.Instance.playerData.intBullets > 0)
                {
                    Debug.Log("------------------Shotttttttttttttttttttttt");

                    StartCoroutine(ShowSpark());

                    _counter = timeShot;

                    GameDataManager.Instance.playerData.SubDiamond(1);
                    AudioManager.Instance.Play(_amThanh);
                }
            }
        }

        IEnumerator ShowSpark()
        {
            spark?.SetActive(true);
            yield return _seconds;
            spark?.SetActive(false);
        }
    }

    public void StopShot()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log("-----------------------Stop Shotttttttttttttttttttttt");
        }
    }
}