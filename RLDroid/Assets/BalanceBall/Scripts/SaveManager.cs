using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager
{

    public void SaveGame(BalanceBrain _brain)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/balancebrain.sav", FileMode.Create);
        //File.WriteAllText(Application.persistentDataPath + "/smart_city_game.txt", _info.WriteData());
        BalanceBrain data = _brain;
        bf.Serialize(stream, data);
        stream.Close();

        //mono_gmail g = new mono_gmail();
        //g.SendMailWithAttachment();
    }

    public BalanceBrain LoadGame()
    {
        BalanceBrain brain = null;
        if (File.Exists(Application.persistentDataPath + "/balancebrain.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/balancebrain.sav", FileMode.Open);
            brain = bf.Deserialize(stream) as BalanceBrain;
            stream.Close();
        }

        return brain;

    }

    public bool checkIfAsDataSave()
    {
        return File.Exists(Application.persistentDataPath + "/balancebrain.sav");
    }
}

//[Serializable]
//public class BlockInfoSG
//{
//    public int blocktype;
//    public string description;
//    public int height;
//    public int x, z;

//    public BlockInfoSG(int type, string dis, int h, int posx, int posz)
//    {
//        x = posx;
//        z = posz;
//        height = h;
//        description = dis;
//        blocktype = type;
//    }

//}

//[Serializable]
//public class InfoSG
//{
//    // por tudo a guardar
//    public BlockInfoSG[,] city_info;
//    public int money;
//    public int last_happinnes, last_number_citizens, last_energy, last_water, last_garbage_collection, last_unemployment, last_air_quality, last_money_perturn;
//    public int health;
//    public int last_education;
//    public int health_bar_size;
//    public int education_cost_lv2, education_cost_lv3;
//    //GameObject cube;

//    public InfoSG(BlockInfoSG[,] city, int _money)
//    {
//        city_info = city;
//        money = _money;

//    }
//    public void PrintData()
//    {
//        Debug.Log("Money:   " + money + "\n\n\n\n\n");

//        foreach (BlockInfoSG b in city_info)
//        {
//            Debug.Log(b.description);
//        }

//    }

//    public void SaveTextInfo(int last_happinnes, int last_number_citizens, int last_energy, int last_water, int last_garbage_collection, int last_unemployment, int last_air_quality, int last_money_perturn)
//    {
//        this.last_happinnes = last_happinnes;
//        this.last_number_citizens = last_number_citizens;
//        this.last_energy = last_energy;
//        this.last_water = last_water;
//        this.last_garbage_collection = last_garbage_collection;
//        this.last_unemployment = last_unemployment;
//        this.last_air_quality = last_air_quality;
//        this.last_money_perturn = last_money_perturn;
//    }
//    //public string WriteData()
//    //{
//    //    String s;
//    //    s = "Money: " + money+"\n";
//    //    foreach(BlockInfoSG b in city_info)
//    //    {
//    //        s += b.description+"\n";
//    //    }
//    //    return s;
//    //}

//    public string WriteData()
//    {
//        String s;
//        s = "Money " + money + "\n";
//        s += "Happiness " + last_happinnes + "\n";
//        s += "Number_of_citizens " + last_number_citizens + "\n";
//        s += "Energy " + last_energy + "\n";
//        s += "Water " + last_water + "\n";
//        s += "Garbage " + last_garbage_collection + "\n";
//        s += "Unemployment " + last_unemployment + "\n";
//        s += "Air_quality " + last_air_quality + "\n";
//        s += "Money_per_turn " + last_money_perturn + "\n";
//        s += "Health " + health + "\n";
//        s += "Education " + last_education + "\n";
//        return s;
//   }
//}
