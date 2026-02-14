using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{




    [SerializeField] GameObject playerModel;


    public void Save(Vector3 PlayerPosition, Quaternion PlayerRotation, int coincount)
    {



        SavePosition savePosition = new SavePosition
        {
            Position = PlayerPosition,
            Rotation = PlayerRotation,
            CoinCount = coincount
        };


        string json = JsonUtility.ToJson(savePosition);


        File.WriteAllText(Application.persistentDataPath + "/save.txt", json);
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            string Loadfile = File.ReadAllText(Application.persistentDataPath + "/save.txt");
            SavePosition savePosition = JsonUtility.FromJson<SavePosition>(Loadfile);

            TREEDMoveAnim moveAnim = playerModel.GetComponent<TREEDMoveAnim>();

            playerModel.transform.position = savePosition.Position;
            playerModel.transform.rotation = savePosition.Rotation;
            moveAnim.Coinref.TotalCoins = savePosition.CoinCount;
        }
        else
        {
            playerModel.transform.position = Vector3.zero;
            playerModel.transform.rotation = Quaternion.identity;
        }
    }



}



public class SavePosition
{
    public Vector3 Position;
    public Quaternion Rotation;
    public int CoinCount;
}