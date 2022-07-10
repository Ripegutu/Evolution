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

public class Minion : IGeneric
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

    public Minion(GameObject minionObject)
    {
        Score = 0;
        MinionSkills = new Skills();
        this.minionObject = minionObject;

    }

    public float Score { get; set; }

    public Skills MinionSkills { get; set; }

    public GameObject minionObject { get; set; }
}
public class MinionsController : MonoBehaviour
{
    List<Minion> Minions = new List<Minion>();
    public GameObject minionPrefab;

    int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            // Instansiate (For real time test)
            Minions.Add(new Minion(Instantiate(minionPrefab, new Vector3(1f, 1f, 1f), new Quaternion())));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (frameCounter % 1000 == 0)
        //{
        //    LogResult();
        //}

        //ScoreMinions();
        //SortMinions();
        //KillMinions();

        //EvolveMinions(0.1f);

        frameCounter++;
    }

    /// <summary>
    /// Scoring the performance of each Minion. The closer the height is to 1000. the better score.
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

    void KillMinions() // killing 50 worst for now
    {
        Minions.RemoveRange(0, 50);
    }

    void EvolveMinions(float Evolution)
    {
        List<Minion> tempList = new List<Minion>();
        int i = 0;

        foreach (Minion minion in Minions)
        {
            float evol = Evolution * Random.value;
            tempList.Add(new Minion(0, minion.MinionSkills.Height + evol));
            i++;
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

        Debug.Log("Between 0 and 2000 - " + Minions.Where(o => o.MinionSkills.Height > 0 && o.MinionSkills.Height < 2000).Count());

        Debug.Log("Between 500 and 1500 - " + Minions.Where(o => o.MinionSkills.Height > 500 && o.MinionSkills.Height < 1500).Count());

        Debug.Log("Between 700 and 1300 - " + Minions.Where(o => o.MinionSkills.Height > 700 && o.MinionSkills.Height < 1300).Count());

        Debug.Log("Between 900 and 1100 - " + Minions.Where(o => o.MinionSkills.Height > 900 && o.MinionSkills.Height < 1100).Count());

        Debug.Log("----------------------------------------------------------------------------------------");
    }
}
