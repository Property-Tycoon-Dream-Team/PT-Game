using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertySpawner : MonoBehaviour
{
    public GameManager manager;
    public Transform prefabList;

    private GameObject[] propertyObjects = new GameObject[40];

    public void UpdateProperty(int index, int propLevel)
    {
        if (propertyObjects[index] != null)
        {
            Destroy(propertyObjects[index]);
            propertyObjects[index] = null;
        }

        GameObject houseToClone = prefabList.GetChild(propLevel - 1).gameObject;

        Vector3 adjustment = new Vector3(0f, 0f, 0f);
        if (index < 10)
        {
            adjustment = new Vector3(0f, 0f, 0.1527f);
        }
        else if (index < 20)
        {
            adjustment = new Vector3(0.13f, 0f, 0f);
        }        
        else if (index < 30)
        {
            adjustment = new Vector3(0f, 0f, -0.101f);
        }        
        else if (index < 40)
        {
            adjustment = new Vector3(-0.113f, 0f, 0f);
        }

        Vector3 clonePos = manager.getTileObject(index).transform.position + adjustment;
        propertyObjects[index] = Object.Instantiate(houseToClone, clonePos, Quaternion.identity);
    }
}

