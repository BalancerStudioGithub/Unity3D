using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UniPhpSql : MonoBehaviour
{

    [SerializeField] Text outputArea;

    public GameObject SysTimer;
    public GameObject LevelNum;
    public GameObject ABTest;
    public GameObject TimeA;
    public GameObject LevelTime;
    public GameObject lagTimer;
    public GameObject LevelPick;
    public GameObject EmailBox;


    public void Send()
    {

        string sysTm = SysTimer.GetComponent<InputField>().text;
        string levN = LevelNum.GetComponent<InputField>().text;
        string abT = ABTest.GetComponent<InputField>().text;
        string tA = TimeA.GetComponent<InputField>().text;
        string levT = LevelTime.GetComponent<InputField>().text;
        string lagTm = lagTimer.GetComponent<InputField>().text;
        string levP = LevelPick.GetComponent<InputField>().text;
        string Eml = EmailBox.GetComponent<InputField>().text;


        int number = int.Parse(lagTm);

        StartCoroutine(InsertIntoDataBase(number));

        IEnumerator InsertIntoDataBase(int lagT)

        {
            // Change url to your own
            string url = "http://www.***.com/sql/insertscore.php";
            WWWForm form = new WWWForm();

            form.AddField("sysTime", sysTm);
            form.AddField("levelNum", levN);
            form.AddField("abTest", abT);
            form.AddField("timeA", tA);
            form.AddField("levelTime", levT);
            form.AddField("lagTime", lagT);
            form.AddField("levelPick", levP);
            form.AddField("eMail", Eml);
         
           
           

            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();
                if (www.isNetworkError || www.isHttpError)
                {
                    print(www.error);
                }
                else
                {
                    //print(www.downloadHandler.text);
                    outputArea.text = www.downloadHandler.text;
                }
            }
        }

    }


}