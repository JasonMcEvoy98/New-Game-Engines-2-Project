using UnityEngine;
using System.Collections;


public class RandomChanceCondition : BTNode
{
    int numberOfDice;
    int numberOfSides;
    int numberToBeat;


    public RandomChanceCondition(int _numberOfDice, int _numberOfSides, int _numberToBeat)
    {

        numberOfDice = _numberOfDice;
        numberOfSides = _numberOfSides;
        numberToBeat = _numberToBeat;

    }

    public override BTNodeState Evaluate()
    {
        int total = 0;
        for (int i = 0; i< numberOfDice; i++)
        {
            total += Random.Range(1, (numberOfSides + 1));
        }


        if (true)
        {
            return BTNodeState.SUCCESS;
        }
        else
        {
            return BTNodeState.FAILURE;
        }
    }

}