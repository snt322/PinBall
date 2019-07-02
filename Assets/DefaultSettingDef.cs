using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettingDef {

    public enum mySetting
    {
        None = 0,
        First = 1,
        Second,
        Third,
    };

    public mySetting setting = mySetting.None;

    int hitPnts;
    int magicPnts;
    int level;
    string name;

    public DefaultSettingDef()
    {
        name = "名無し";
        hitPnts = 10;
        magicPnts = 10;
        level = 1;
    }
    public DefaultSettingDef(int h, int m, string n)
    {
        name = n;
        hitPnts = h;
        magicPnts = m;
    }


    public mySetting Setting
    {
        get
        {
            return this.setting;
        }
        set
        {
            this.setting = value;
        }
    }





}
