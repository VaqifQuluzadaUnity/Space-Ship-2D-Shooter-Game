using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace GalaxyDefenders
{
    public class LocalizationController : MonoBehaviour
    {
        public void OnLanguageDropDownPressed(int languageIndex)
        {
            Locale selectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];

            LocalizationSettings.Instance.SetSelectedLocale(selectedLocale);
        }
    }
}