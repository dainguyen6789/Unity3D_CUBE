/**
 * Documentation of C# driver 1.10:
 * http://mongodb.github.io/mongo-csharp-driver/1.11/getting_started/
 * c# Driver for MongoDBprovided by http://answers.unity3d.com/questions/618708/unity-and-mongodb-saas.html
 * reference: https://github.com/fabifiess/unity-mongodb
 */


using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

public class mongo : MonoBehaviour
{
    public GameObject cube;
    //int t;
    double ttt;
    public Color color;
    //Text text1;
    MongoCollection<BsonDocument> playercollection;
    MongoClient client;
    MongoServer server;
    MongoDatabase database;
    string connectionString = "mongodb://localhost:27017";
    // string connectionString = "mongodb://gravityhunter.mi.hdm-stuttgart.de:27017";

    void Start()
    {


        /*
		 * 1. establish connection
		 */

        InvokeRepeating("Update_Cube", 0.0f, 1.0f);
        client = new MongoClient(connectionString);
        server = client.GetServer();
        database = server.GetDatabase("cms");
        playercollection = database.GetCollection<BsonDocument>("postas");
        foreach (var document in playercollection.FindAll())
        {
            Debug.Log("4. SELECT ALL DOCS: \n" + document["Red"]);
        }


    }
    void Update()
    {
        foreach (var document in playercollection.FindAll())
        {
            //t = document["title"];
            //Debug.Log(document["status"]);
            //Debug.Log(Color.blue);
            //ttt= document["Rot"].ToDouble();
            // Debug.Log(ttt);




            color.r = (float)(document["Red"].ToInt32()) / (255);

            color.g = (float)(document["Red"].ToInt32()) / (255);

            color.b = (float)(document["Red"].ToInt32()) / (255);

            color.a = 0.1f;

            Debug.Log(document);
            // cube.GetComponent<Renderer>().material.color = new Vector4((float)(document["Red"].ToInt64()),
            //   (float)(document["Green"].ToInt64()), (float)(document["Blue"].ToInt64()),100);

            // Change the color of our Cubic.
            cube.GetComponent<Renderer>().material.color = color;
            cube.transform.Rotate(Vector3.right * (float)(document["RotX"].ToInt32()) * Time.deltaTime);
            cube.transform.Rotate(Vector3.up * (float)(document["RotY"].ToInt32()) * Time.deltaTime);
            cube.transform.Rotate(Vector3.left * (float)(document["RotZ"].ToInt32()) * Time.deltaTime);
            //cube.transform.Rotate(new Vector3(    (float)(document["RotX"].ToDouble()), (float)(document["RotY"].ToDouble()), 
            //   (float)(document["RotZ"].ToDouble()) ));


        }
    }


    void Update_Cube()

    {
        playercollection = database.GetCollection<BsonDocument>("postas");
        print(Time.time);

    }



}