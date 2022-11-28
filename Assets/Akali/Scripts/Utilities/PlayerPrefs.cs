namespace Akali.Scripts.Utilities
{
    public static class PlayerPrefs
    {
        #region Level

        public static int GetLevel()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsLevel))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsLevel, 1);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsLevel);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsLevel);
        }

        public static void SetLevel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsLevel, value);
        }

        #endregion

        #region LevelText

        public static int GetLevelText()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsLevelText))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsLevelText, 1);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsLevelText);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsLevelText);
        }

        public static void SetLevelText(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsLevelText, value);
        }

        #endregion

        #region Money

        public static int GetMoney()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsMoney))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMoney, 1000);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMoney);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMoney);
        }

        public static void SetMoney(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMoney, value);
        }

        #endregion

        #region Haptic

        public static string GetHaptic()
        {
            if (UnityEngine.PlayerPrefs.HasKey(Constants.PrefsHaptic))
            {
                UnityEngine.PlayerPrefs.SetString(Constants.PrefsHaptic, Constants.BoolVarTrue);
                return UnityEngine.PlayerPrefs.GetString(Constants.PrefsHaptic);
            }

            return UnityEngine.PlayerPrefs.GetString(Constants.PrefsHaptic);
        }

        public static void SetHaptic(string value)
        {
            UnityEngine.PlayerPrefs.SetString(Constants.PrefsHaptic, value);
        }

        #endregion
        
        #region ParkourLevel

        public static int GetParkourLevel()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsParkourLevel))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsParkourLevel, 0);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsParkourLevel);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsParkourLevel);
        }

        public static void SetParkourLevel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsParkourLevel, value);
        }

        #endregion
        
        #region BuyCarLevel

        public static int GetBuyCarLevel()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsBuyCarLevel))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsBuyCarLevel, 1);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsBuyCarLevel);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsBuyCarLevel);
        }

        public static void SetBuyCarLevel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsBuyCarLevel, value);
        }

        #endregion
        
        #region MergeCarLevel

        public static int GetMergeCarLevel()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsMergeCarLevel))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMergeCarLevel, 1);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMergeCarLevel);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMergeCarLevel);
        }

        public static void SetMergeCarLevel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMergeCarLevel, value);
        }

        #endregion
        
        #region BuyCarAmount

        public static int GetCarBuyAmount()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsCarBuyAmount))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarBuyAmount, 20);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarBuyAmount);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarBuyAmount);
        }

        public static void SetCarBuyAmount(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarBuyAmount, value);
        }

        #endregion

        #region MergeCarAmount

        public static int GetCarMergeAmount()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsMergeCarAmount))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMergeCarAmount, 45);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMergeCarAmount);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsMergeCarAmount);
        }

        public static void SetCarMergeAmount(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsMergeCarAmount, value);
        }

        #endregion
        
        #region CarSpeedLevel

        public static int GetCarSpeedLevel()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsCarSpeedLevel))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarSpeedLevel, 1);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarSpeedLevel);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarSpeedLevel);
        }

        public static void SetCarSpeedLevel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarSpeedLevel, value);
        }

        #endregion
        
        #region CarSpeedAmount

        public static int GetCarSpeedAmount()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsCarSpeedAmount))
            {
                UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarSpeedAmount, 75);
                return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarSpeedAmount);
            }

            return UnityEngine.PlayerPrefs.GetInt(Constants.PrefsCarSpeedAmount);
        }

        public static void SetCarSpeedAmount(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(Constants.PrefsCarSpeedAmount, value);
        }

        #endregion
        
        #region CarSpeed

        public static float GetCarSpeed()
        {
            if (!UnityEngine.PlayerPrefs.HasKey(Constants.PrefsCarSpeed))
            {
                UnityEngine.PlayerPrefs.SetFloat(Constants.PrefsCarSpeed, 1f);
                return UnityEngine.PlayerPrefs.GetFloat(Constants.PrefsCarSpeed);
            }

            return UnityEngine.PlayerPrefs.GetFloat(Constants.PrefsCarSpeed);
        }

        public static void SetCarSpeed(float value)
        {
            UnityEngine.PlayerPrefs.SetFloat(Constants.PrefsCarSpeed, value);
        }

        #endregion
    }
}