using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Profiling;
using UnityEngine;

public class createObject : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject squareToLoad;
    //the data structure I am storing the positions in
	
	//also this is an extra comment
	
	//okay this is different now
    HashSet<Vector3> positions;
	
	//another comment added to this test
    
    
    float xvalue, yvalue;

    void Start()
    {
        //the folder Prefabs, and the file Square, to load into this variable.
        squareToLoad = Resources.Load<GameObject>("Square");
        positions = new HashSet<Vector3>();

        StartCoroutine(generateBoxes());




    }


    IEnumerator generateBoxes()
    {
        while (true)
        {
            xvalue = Random.Range(-Camera.main.orthographicSize + 0.5f, Camera.main.orthographicSize - 0.5f);
            yvalue = Random.Range(-Camera.main.orthographicSize + 0.5f, Camera.main.orthographicSize - 0.5f);
            Debug.Log("X:"+xvalue + " Y:" + yvalue);

            Vector3 pos = new Vector3(xvalue, yvalue);

            if (!checkOverlapping(pos))
            {
                generateSquare(pos);
                positions.Add(pos);
            }
            Debug.Log(Mathf.Pow(1, 2));
            bool wanttostop =false;
            if (wanttostop)
            {
                break;
            }
            
            //100 squares in random positions on the screen which DO NOT overlap
           //  yield return new WaitForSeconds(1f);
            yield return null;
        }

        yield return null;
    }
    //1. create a method called calculateHypotenuse based on a given size square with a specific scale which returns a float.

    //2. find a way to stop the code executing when it seems that it has kept trying to find a random position for more than 10 times.



    bool checkOverlapping(Vector3 boxPosition)
    {
        foreach (Vector3 pos in positions)
        {
            if (Vector3.Distance(pos, boxPosition) < 1.41f)
            {
                //Debug.Log(positions.Count);
                return true;
            }
        }
        return false;
    }

    void generateSquare(Vector3 newposition)
    {

        Instantiate(squareToLoad, newposition, Quaternion.identity);
        
    }


    // Update is called once per frame
    void Update()
    {

    }
}
