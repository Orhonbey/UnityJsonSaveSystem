using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystemJson : MonoBehaviour
{

    /*//////--------sunal Orhon Save System Json----------///////
     * 
     * 
     * istediğimiz verileri string bir değişkene kaydediyoruz 
     */
    [SerializeField]
    private InputField userName;
    [SerializeField]
    private  InputField userLastName;
    [SerializeField]
    private InputField score;

    private string playerPrefsName;
    // Name Kayıt Panel
    [SerializeField]
    private GameObject nameSavePanel;

    public MainClass mainClass = new MainClass();

    #region start Fonksiyonu
    void Start()
    {
        StringToMainClass();
        if (PlayerPrefs.HasKey("mainClassJson") && mainClass.MainClassName !="")
        {
            nameSavePanel.SetActive(false);
        }
    }
    #endregion


    #region  İsim kayıt Sistemi

    public void NameLastNameSaveButton() // Buttone atanan Fonksiyon
    {
        Debug.Log("Input Name :" + userName.text + " Input Last name :" + userLastName.text);
        mainClass.MainClassName = userName.text.ToString();
        mainClass.MainClasslastName = userLastName.text.ToString();
        string mcJson = MainClassToString(mainClass);
        PlayerPrefs.SetString("mainClassJson", mcJson);
        Debug.Log("Player Prefs Get string hali :" + PlayerPrefs.GetString("mainClassJson"));
        nameSavePanel.SetActive(false);


    }

    #endregion

    #region Score Kayıt işlemi
    public void ScoreSaveButton()
    {
        Debug.Log("Score Kayıt Input" + score.text);
        float scoreFloat = float.Parse(score.text.ToString());
        mainClass.userScore.ScoreClass.Add(scoreFloat);
        PlayerPrefs.SetString("mainClassJson", MainClassToString(mainClass));


    }
    #endregion


    #region Class To String Class Stringe Çeviriyoruz
    private string MainClassToString(MainClass mc) // Class Gelen değeri Player Pref Haline çeviriyoruz
    {
        string toString = JsonUtility.ToJson(mc);
        return toString;
    }
    #endregion

    #region Player Prefsteki String Değeri class İçine Dolduruyoruz 
    private void StringToMainClass()// Player Prefs deki string değeri classımıza dolduruyoruz
    {
        playerPrefsName = PlayerPrefs.GetString("mainClassJson");// Player Prefs Olarak Gelen Değeri bir stringe atayıp 
        mainClass = stringToClass(playerPrefsName);// Daha sonra stringtoClass fonksiyonuna yolluyoruz ve orda json formatındaki string 
        // class cinsine dönüyor 
    }

    private MainClass stringToClass(string mc) // String Gelen Değeri Class cindsinden döndürüyoruz
    {
        return JsonUtility.FromJson<MainClass>(mc);
    }


    #endregion


    

}
