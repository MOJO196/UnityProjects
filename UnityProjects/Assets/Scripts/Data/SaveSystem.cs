using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //TicTacToe
    static string tictactoePath = Application.persistentDataPath + "/data.tictactoe";
    public static void SaveTicTacToeGame()
    {
        TicTacToeData data = new TicTacToeData();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(tictactoePath, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TicTacToeData LoadTicTacToe()
    {
        if (File.Exists(tictactoePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(tictactoePath, FileMode.Open);

            TicTacToeData data = formatter.Deserialize(stream) as TicTacToeData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("ERROR: Data not found at " + tictactoePath);
            return null;
        }
    }


    //Pong ...
}
