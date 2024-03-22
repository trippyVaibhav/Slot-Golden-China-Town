using System.Collections;
using System.Collections.Generic;
using BestHTTP.SocketIO;
using UnityEngine;
using UnityEngine.Events;
using System;
using Newtonsoft.Json;
using BestHTTP.SocketIO.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using DG.Tweening;
using System.Linq;
using BestHTTP;

public class SocketIOManager : MonoBehaviour
{
    [SerializeField]
    private SlotBehaviour slotManager;
    [SerializeField]
    private TextAsset myJsonFile;

    private void Start()
    {
        ParseMyJson(myJsonFile.ToString());
    }

    private void ParseMyJson(string jsonObject)
    {
        try
        {
            jsonObject = jsonObject.Replace("\\", string.Empty);
            jsonObject = jsonObject.Trim();
            jsonObject = jsonObject.TrimStart('"').TrimEnd('"');
            InitialSlotData initialslots = JsonUtility.FromJson<InitialSlotData>(jsonObject);
            PopulateSlotSocket(initialslots.PopulateSlot);
        }
        catch(Exception e)
        {
            Debug.Log("Error while parsing Json " + e.Message);
        }
    }

    private void PopulateSlotSocket(List<string> slotPop)
    {
        for (int i = 0; i < slotPop.Count; i++)
        {
            List<int> points = slotPop[i]?.Split(',')?.Select(Int32.Parse)?.ToList();
            slotManager.PopulateInitalSlots(i, points);
        }

        for (int i = 0; i < slotPop.Count; i++)
        {
            slotManager.LayoutReset(i);
        }

    }
}

[Serializable]
public class InitialSlotData
{
    public List<string> PopulateSlot;
}
