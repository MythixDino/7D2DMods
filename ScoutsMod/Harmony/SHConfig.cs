﻿using System.Collections.Generic;

public static class SHConfig
{
    public static bool CheckFeatureStatus(string strFeature)
    {
        BlockValue ScoutHordeConfig = Block.GetBlockValue("SHConfigBlock");
        if (ScoutHordeConfig.type == 0)
            return false;

        bool result = false;
        if(ScoutHordeConfig.Block.Properties.Contains(strFeature))
            result = ScoutHordeConfig.Block.Properties.GetBool(strFeature);

        return result;
    }

    
    public static bool CheckFeatureStatus(string strClass, string strFeature)
    {
        BlockValue ScoutHordeConfig = Block.GetBlockValue("SHConfigBlock");
        if (ScoutHordeConfig.type == 0)
            return false;

        bool result = false;
        if(ScoutHordeConfig.Block.Properties.Classes.ContainsKey(strClass))
        {
            DynamicProperties dynamicProperties3 = ScoutHordeConfig.Block.Properties.Classes[strClass];
            foreach(System.Collections.Generic.KeyValuePair<string, object> keyValuePair in dynamicProperties3.Values.Dict.Dict)
                if(string.Equals(keyValuePair.Key, strFeature, System.StringComparison.CurrentCultureIgnoreCase))
                    result = StringParsers.ParseBool(dynamicProperties3.Values[keyValuePair.Key]);
        }

        return result;
    }

    public static string GetPropertyValue(string strClass, string strFeature)
    {
        BlockValue ScoutHordeConfig = Block.GetBlockValue("SHConfigBlock");
        if(ScoutHordeConfig.type == 0)
            return string.Empty;


        string result = string.Empty;
        if(ScoutHordeConfig.Block.Properties.Classes.ContainsKey(strClass))
        {
            DynamicProperties dynamicProperties3 = ScoutHordeConfig.Block.Properties.Classes[strClass];
            foreach(KeyValuePair<string, object> keyValuePair in dynamicProperties3.Values.Dict.Dict)
            {
                if(keyValuePair.Key == strFeature)
                    return keyValuePair.Value.ToString();
            }
        }

        return result;
    }
}

