using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllChildren : MonoBehaviour
{
    public GameObject[] parentGameObj;

    public void DisableChildren()
    {
        // for every parent
        for (int i = 0; i < parentGameObj.Length; i++)
        {
            // for every child on game obj
            for (int j = 0; j < parentGameObj[i].transform.childCount; j++)
            {
                var child = parentGameObj[i].transform.GetChild(j).gameObject;

                // if child exists
                if (child != null)
                {
                    // disable
                    child.SetActive(false);
                }
            }
        }
      
    }
}
