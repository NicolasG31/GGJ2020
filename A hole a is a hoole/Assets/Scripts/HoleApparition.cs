using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleApparition : MonoBehaviour
{
    public GameObject PrefabHole;
    private Transform rt;
    List<GameObject> Holes = new List<GameObject>();
    public float apparitionTimeStart = 8.0f;
    public float apparitionTimeEnd = 2.0f;
    public float apparitionTimeReduceValue = 0.3f;
    public float apparitionTime = 8.0f;
    float Width = 0f;
    float Height = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Width = 3.0f;
        Height = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        apparitionTime -= Time.deltaTime;
        if (apparitionTime < 0)
        {
            CreateAHole();
            if (apparitionTimeStart > apparitionTimeEnd)
            {
                Debug.Log(apparitionTimeStart);
                apparitionTimeStart -= apparitionTimeReduceValue;
                apparitionTime = apparitionTimeStart;
            }
        }
    }

    public void CreateAHole()
    {
        if (Holes.Count < 10)
        {
            Debug.Log("I create a hole");
            rt = PrefabHole.transform;
            float x = Random.Range(-Width, Width);
            float y = Random.Range(-Height, Height);

            for (int i = 0; i < Holes.Count; i++)
            {
                //RectTransform rtTemp = (RectTransform)Holes[i].transform;
                Debug.Log("X = " + x + " & Y = " + y);
                Debug.Log("Holes[i]X = " + Holes[i].transform.position.x + " & Holes[i]Y = " + Holes[i].transform.position.y);
                Debug.Log("ABS x = " + Mathf.Abs((x - Holes[i].transform.position.x)));
                Debug.Log("ABS y = " + Mathf.Abs((y - Holes[i].transform.position.y)));

                if ((Mathf.Abs((x - Holes[i].transform.position.x)) < 0.2f)
                    || (Mathf.Abs((y - Holes[i].transform.position.y)) < 0.2f))
                {
                    x = Random.Range(-Width, Width);
                    y = Random.Range(-Height, Height);
                    i = 0;
                }
            }

            Holes.Add(Instantiate(PrefabHole, new Vector3(x, y, 0), Quaternion.identity));
            GetComponent<WaterMove>().waterMoving = true;
            GetComponent<WaterMove>().IncreaseWaterSpeed();
        }
        else if (Holes.Count == 0)
        {
            GetComponent<WaterMove>().waterMoving = false;
        }
    }

    public void DestroyAHole(GameObject Hole)
    {
        if (Holes.Count > 0)
        {
            Holes.Remove(Hole);
            Destroy(Hole);
            GetComponent<WaterMove>().ReduceWaterSpeed();
            GetComponent<ScoringManager>().IncreaseScore(100);
            Debug.Log("Remove a hole !");
        }
    }
}
