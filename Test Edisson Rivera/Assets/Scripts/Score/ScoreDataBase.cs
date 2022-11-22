using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Proyecto26;

public class ScoreDataBase : MonoBehaviour
{
    public ScoreTable scoreTable = new ScoreTable();
    public Transform tableScores;

    private void Start()
    {
        GetData();
    }

    public void DataAll()
    {
        var scores = new List<Score>
        {
            new Score("Homer", 0),

            new Score("Lisa", 50),
            new Score("Marge", 25),

            new Score("Bart", 100),
            new Score("Maggie", 75)
        };

        var table = new ScoreTable(scores);

        // save to JSON
        var json = JsonUtility.ToJson(table, true);

        // load from JSON
        var fromJson = JsonUtility.FromJson<ScoreTable>(json);

        // print the top 3 players

        var take = fromJson.Scores.OrderByDescending(s => s.Points).Take(5);


        var dataBaseScore = new List<Score>();
        foreach (var score in take)
        {
            Debug.Log($"{score.Name}: {score.Points}");
            dataBaseScore.Add(score);
        }
        var tables = new ScoreTable(dataBaseScore);

        // save to JSON
        var jsons = JsonUtility.ToJson(tables, true);



        RestClient.Put("https://restapi-b99ed-default-rtdb.firebaseio.com/" + "HighScore" + ".json", jsons);

    }

    public void GetData()
    {

        

        RestClient.Get<ScoreTable>("https://restapi-b99ed-default-rtdb.firebaseio.com/" + "HighScore" + ".json").Then(response =>
        {
            scoreTable = response;
            UpdateTable();

        }).Catch(error =>
        {
            Debug.Log(error);
        });

    }

    void UpdateTable()
    {
        int x = 0;
        foreach (Transform item in tableScores)
        {
            item.GetComponent<ItemScore>().NicName.text = scoreTable.Scores[x].Name;
            item.GetComponent<ItemScore>().Score.text = scoreTable.Scores[x].Points.ToString();
            item.GetComponent<ItemScore>().position.text = (x + 1).ToString(); 
            x++;
        }
    }


    public void SetScore(string nickName,int score)
    {
        Score newScore = new Score(nickName, score);
        scoreTable.Scores.Add(newScore);



        var table = new ScoreTable(scoreTable.Scores);

        // save to JSON
        var json = JsonUtility.ToJson(table, true);

        // load from JSON
        var fromJson = JsonUtility.FromJson<ScoreTable>(json);

        // print the top 3 players

        var take = fromJson.Scores.OrderByDescending(s => s.Points).Take(10);


        var dataBaseScore = new List<Score>();
        foreach (var scores in take)
        {
            Debug.Log($"{scores.Name}: {scores.Points}");
            dataBaseScore.Add(scores);
        }
        var tables = new ScoreTable(dataBaseScore);

        // save to JSON
        var jsons = JsonUtility.ToJson(tables, true);



        RestClient.Put("https://restapi-b99ed-default-rtdb.firebaseio.com/" + "HighScore" + ".json", jsons);
    }

    public void GetScore()
    {

        RestClient.Get<ScoreTable>("https://restapi-b99ed-default-rtdb.firebaseio.com/" + "HighScore" + ".json").Then(response =>
        {
            Debug.Log(response);
            scoreTable = response;
        }).Catch(error =>
        {
            Debug.Log(error);
        });
    }

}

[Serializable]
public class ScoreTable
{
    public List<Score> Scores = new List<Score>();

    public ScoreTable()
    {
        // for serializer
    }

    public ScoreTable([NotNull] List<Score> scores)
    {
        if (scores == null)
            throw new ArgumentNullException(nameof(scores));

        Scores = scores;
    }
}

[Serializable]
public class Score
{
    public string Name;
    public int Points;

    public Score()
    {
        // for serializer
    }

    public Score(string name, int points)
    {
        Name = name;
        Points = points;
    }
}