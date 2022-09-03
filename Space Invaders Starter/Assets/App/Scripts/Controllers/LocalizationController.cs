using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace GalaxyDefenders.Controllers
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