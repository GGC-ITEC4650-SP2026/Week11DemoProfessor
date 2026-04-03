using UnityEngine;

public class Roller : MonoBehaviour
{
    Rigidbody myBod;
    public float power;
    public string faceName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
    }

    public void roll()
    {
        Vector3 f = new Vector3(Random.Range(-1f, 1f), 5, Random.Range(-1f, 1f));
        Vector3 p = transform.position - 
            new Vector3(Random.Range(-1f, 1f), -0.5f, Random.Range(-1f, 1f));
        myBod.AddForceAtPosition(f * power, p);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            roll();
        }

        float maxY = 0;
        
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform face = transform.GetChild(i);
            if(face.position.y > maxY)
            {
                maxY = face.position.y;
                faceName = face.name;
            }
        }
    }
}
