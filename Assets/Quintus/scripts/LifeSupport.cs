using UnityEngine;

public class LifeSupport : MonoBehaviour
{
    public LifeBar lifebar; 

    public int lifecount = 3;
    void Start()
    {
        lifebar.setupthehearts(lifecount);
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "bullet")
        {
            CheckLife();
            Debug.Log("damage taken");
        }
    }

    private void CheckLife()
    {
        lifecount--;
        if (lifecount == 0)
        {
            Debug.Log("im dead");

        }
    }
}
