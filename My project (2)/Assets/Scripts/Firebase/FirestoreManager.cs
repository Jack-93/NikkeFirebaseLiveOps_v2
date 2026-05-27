using Firebase.Firestore;
using Firebase.Auth;
using UnityEngine;
using System.Collections.Generic;

public class FirestoreManager : MonoBehaviour
{
    public static FirestoreManager Instance;

    private FirebaseFirestore db;

    private void Awake()
    {
        Instance = this;

        db = FirebaseFirestore.DefaultInstance;
    }

    public async void SavePlayerData(PlayerData data)
    {
        FirebaseUser user =
            FirebaseAuth.DefaultInstance.CurrentUser;

        if (user == null)
        {
            Debug.LogError("No User");
            return;
        }

        DocumentReference docRef =
            db.Collection("users")
            .Document(user.UserId);

        Dictionary<string, object> playerData =
            new Dictionary<string, object>()
        {
            { "nickname", data.nickname },
            { "level", data.level },
            { "gold", data.gold },
            { "tutorialCompleted", data.tutorialCompleted }
        };

        await docRef.SetAsync(playerData);

        Debug.Log("[Firestore] Save Success");
    }

    public async void LoadPlayerData()
    {
        FirebaseUser user =
            FirebaseAuth.DefaultInstance.CurrentUser;

        if (user == null)
        {
            Debug.LogError("No User");
            return;
        }

        DocumentReference docRef =
            db.Collection("users")
            .Document(user.UserId);

        DocumentSnapshot snapshot =
            await docRef.GetSnapshotAsync();

        if (snapshot.Exists)
        {
            Debug.Log("[Firestore] Data Loaded");

            Debug.Log(snapshot.ToDictionary()["nickname"]);
        }
        else
        {
            Debug.Log("[Firestore] New User Data");

            PlayerData newPlayer =
                new PlayerData();

            SavePlayerData(newPlayer);
        }
    }
}