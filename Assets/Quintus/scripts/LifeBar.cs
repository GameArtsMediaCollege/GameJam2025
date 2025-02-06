using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeBar : MonoBehaviour
{
    public GameObject heartprefab;
    public GameObject soloheart;
    public List<GameObject> hearts = new List<GameObject>();
    public int instanceoffset = 30;
    public int maxhearts;

    void Start()
    {
    }

    public void setupthehearts(int lifecount)
    {
        hearts.Add(soloheart);
        for (int i = 1; i < lifecount; i++)
        {
            Debug.Log("started the heartthing");
            GameObject heartinstance = Instantiate(heartprefab, soloheart.transform.position, Quaternion.identity);
            heartinstance.transform.parent = this.transform;
            heartinstance.transform.localScale = new Vector3(1, 1, 1);
            heartinstance.transform.position = new Vector3(hearts[i-1].transform.position.x + instanceoffset, heartinstance.transform.position.y);
            hearts.Add(heartinstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
