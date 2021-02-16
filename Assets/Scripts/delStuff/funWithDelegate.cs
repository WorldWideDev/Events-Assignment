using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funWithDelegate : MonoBehaviour {

    delegate bool MeDelegate(int n);

    delegate int NumDel(int n);

    int[] numbers = { 2, 5, 2, 7, 44, 99, 3 };

    void Start()
    {
        IEnumerable<int> result = RunNumbersThruGauntlet(numbers, n => n > 13);
        foreach (int n in result)
            Debug.Log(n);

    }
    


    static IEnumerable<int> RunNumbersThruGauntlet(IEnumerable<int> numbers, MeDelegate gauntlet)
    {
        foreach (int number in numbers)
            if (gauntlet(number))
                yield return number;
    }


}
