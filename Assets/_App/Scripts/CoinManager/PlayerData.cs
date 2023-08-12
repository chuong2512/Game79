using System;
using UnityEngine;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSong = 19;
    public static int priceUnlockSong = 1000;
}

public class PlayerData : BaseData
{
    public int intBullets;
    public int currentSong;
    public bool[] listSongs;

    public Action<int> onChangeDiamond;

    public long time;
    public string timeRegister;

    public void SetTimeRegister(long timeSet)
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = timeSet;
        Save();
    }


    
    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = 7 * 24 * 60 * 60;
        
        intBullets = 20;
        currentSong = 0;
        listSongs = new bool[Constant.countSong];

        for (int i = 0; i < 8; i++)
        {
            listSongs[i] = true;
        }

        Save();
    }

    public bool CheckLock(int id)
    {
        return this.listSongs[id];
    }

    public void Unlock(int id)
    {
        if (!listSongs[id])
        {
            listSongs[id] = true;
        }

        Save();
    }

 

    public bool CheckCanUnlock()
    {
        return intBullets >= Constant.priceUnlockSong;
    }

    public void SubDiamond(int a)
    {
        intBullets -= a;

        if (intBullets < 0)
        {
            intBullets = 0;
        }

        onChangeDiamond?.Invoke(intBullets);
        
        Save();
    }

    public void ChooseSong(int i)
    {
        currentSong = i;
        Save();
    }
    
    public void AddDiamond(int a)
    {
        intBullets += a;

        onChangeDiamond?.Invoke(intBullets);
        
        Save();
    }
    
    public void ResetTime()
    {
        time = 0;
        Save();
    }
}