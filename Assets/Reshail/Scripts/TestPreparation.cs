using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPreparation : MonoBehaviour
{
    public int[] intArray = new int[10];
    public List<int> intList = new List<int>();
    public int result;


    // Start is called before the first frame update
    void Start()
    {
        EvenNumberAdder();
        //List<int> intList1 == [1, 2, 3];
        intList.Add(1);
    }

    //Given an array of ints, write a C# method to total all the values that are even numbers.
    public void EvenNumberAdder()
    {
        int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        for (int i = 0; i < intArray.Length; i++)
        {
            if (intArray[i] % 2 == 0)
            {
                result += intArray[i];
            }
        }

        Debug.Log("Result is: " + result);
    }


}
