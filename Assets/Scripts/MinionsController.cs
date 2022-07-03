using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// Puttting classes here, move to another .cs file?
public class Skills
{
    public Skills(float InitialHeight)
    {
        Height = InitialHeight;
    }

    public Skills()
    {
        Height = 0.0f;
    }

    public float Height { get; set; }
}

interface IGeneric
{
    float Score { get; set; }

    public Skills MinionSkills { get; set; }
}

public class Minion: IGeneric
{
    public Minion()
    {
        Score = 0;
        MinionSkills = new Skills();
    }

    public Minion(float initialScore, float initalHeight)
    {
        Score = initalHeight;
        MinionSkills = new Skills(initalHeight);
    }

    public float Score { get; set; }

    public Skills MinionSkills { get; set; }
}
public class MinionsController : MonoBehaviour
{
    List<Minion> Minions = new List<Minion>();

    int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            Minions.Add(new Minion());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (frameCounter % 1000 == 0)

        {

            LogResult();

        }







        ScoreMinions();

        SortMinions();

        //KillMinions();



        EvolveMinions(3);



        frameCounter++;
    }
    /// <summary>
    /// Scoring the performance of each Minion.
    /// </summary>
    void ScoreMinions()
    {
        foreach (Minion minion in Minions)
        {

            minion.Score = -0.000001f * minion.MinionSkills.Height * minion.MinionSkills.Height + 0.002f * minion.MinionSkills.Height;

        }
    }

    void SortMinions()

    {

        Minions = Minions.OrderBy(o => o.Score).ToList();

    }
    void KillMinions() // For eases, killing 50 worst

    {

        Minions.RemoveRange(Minions.Count - 51, 50);

    }



    void EvolveMinions(float Evolution)

    {
        List<Minion> tempList = new List<Minion>();
        foreach (Minion minion in Minions)

        {

            float evol = Evolution * Random.value;

            tempList.Add(new Minion(0, minion.MinionSkills.Height + evol));

        }
        Minions.AddRange(tempList);

    }



    void LogResult()

    {

        // Total count

        Debug.Log("Number of Minions: " + Minions.Count);

        // Getting height range

        float tallest = Minions.Select(o => o.MinionSkills.Height).Max();

        float lowest = Minions.Select(o => o.MinionSkills.Height).Min();



        Debug.Log("Tallest Minion: " + tallest);

        Debug.Log("Lowest Minion: " + lowest);

        // make this dynamic

        Debug.Log("Between 0 and 20 - " + Minions.Select(o => o.MinionSkills.Height > 0 && o.MinionSkills.Height < 20).Count());

        Debug.Log("Between 5 and 15 - " + Minions.Select(o => o.MinionSkills.Height > 5 && o.MinionSkills.Height < 15).Count());

        Debug.Log("Between 7 and 13 - " + Minions.Select(o => o.MinionSkills.Height > 7 && o.MinionSkills.Height < 13).Count());

        Debug.Log("Between 9 and 11 - " + Minions.Select(o => o.MinionSkills.Height > 9 && o.MinionSkills.Height < 11).Count());

        Debug.Log("----------------------------------------------------------------------------------------");







    }

}
