using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform mainContainer_RT;

    [Header("Sprites")]
    [SerializeField]
    private Sprite[] myImages;

    [Header("Slot Images")]
    [SerializeField]
    private List<Image> slot1_Image;
    [SerializeField]
    private List<Image> slot2_Image;
    [SerializeField]
    private List<Image> slot3_Image;
    [SerializeField]
    private List<Image> slot4_Image;
    [SerializeField]
    private List<Image> slot5_Image;

    [Header("Slots Objects")]
    [SerializeField]
    private GameObject Slot_1_Object;
    [SerializeField]
    private GameObject Slot_2_Object;
    [SerializeField]
    private GameObject Slot_3_Object;
    [SerializeField]
    private GameObject Slot_4_Object;
    [SerializeField]
    private GameObject Slot_5_Object;

    [Header("Slots Transforms")]
    [SerializeField]
    private Transform Slot_1_Transform;
    [SerializeField]
    private Transform Slot_2_Transform;
    [SerializeField]
    private Transform Slot_3_Transform;
    [SerializeField]
    private Transform Slot_4_Transform;
    [SerializeField]
    private Transform Slot_5_Transform;

    [Header("Buttons")]
    [SerializeField]
    private Button SlotStart_Button;

    [Header("Dummy Values")]
    [SerializeField]
    private List<int> Row_1_value;

    int tweenHeight = 0;

    [SerializeField]
    private GameObject Image_Prefab;

    private Tweener tweener1;
    private Tweener tweener2;
    private Tweener tweener3;
    private Tweener tweener4;
    private Tweener tweener5;

    private void Start()
    {
        if (SlotStart_Button) SlotStart_Button.onClick.RemoveAllListeners();
        if (SlotStart_Button) SlotStart_Button.onClick.AddListener(StartSlots);
        PopulateSlot(Row_1_value, slot1_Image, Slot_1_Transform, Slot_1_Object);
        PopulateSlot(Row_1_value, slot2_Image, Slot_2_Transform, Slot_2_Object);
        PopulateSlot(Row_1_value, slot3_Image, Slot_3_Transform, Slot_3_Object);
        PopulateSlot(Row_1_value, slot4_Image, Slot_4_Transform, Slot_4_Object);
    }

    private void PopulateSlot(List<int> values, List<Image> slot_Images, Transform SlotTransform, GameObject SlotObject)
    {
        if (SlotObject) SlotObject.SetActive(true);
        for(int i = 0; i<values.Count; i++)
        {
            GameObject myImg = Instantiate(Image_Prefab, SlotTransform);
            slot_Images.Add(myImg.GetComponent<Image>());
            slot_Images[i].sprite = myImages[values[i]];
        }
        GameObject mylastImg = Instantiate(Image_Prefab, SlotTransform);
        slot_Images.Add(mylastImg.GetComponent<Image>());
        slot_Images[slot_Images.Count - 1].sprite = myImages[values[0]];
        if (mainContainer_RT) LayoutRebuilder.ForceRebuildLayoutImmediate(mainContainer_RT);
        tweenHeight = (values.Count * 100)-150;
    }

    private void StartSlots()
    {
        StartCoroutine(TweenRoutine());
    }

    private IEnumerator TweenRoutine()
    {
        InitializeTweening1(Slot_1_Transform);
        InitializeTweening2(Slot_2_Transform);
        InitializeTweening3(Slot_3_Transform);
        InitializeTweening4(Slot_4_Transform);
        yield return new WaitForSeconds(8);
        StopTweening1(5, Slot_1_Transform);
        yield return new WaitForSeconds(1);
        StopTweening2(8, Slot_2_Transform);
        yield return new WaitForSeconds(1);
        StopTweening3(7, Slot_3_Transform);
        yield return new WaitForSeconds(1);
        StopTweening4(11, Slot_4_Transform);
    }

    private void InitializeTweening1(Transform slotTransform)
    {
        slotTransform.localPosition = new Vector2(slotTransform.localPosition.x, 0);
        tweener1 = slotTransform.DOLocalMoveY(-tweenHeight, 0.2f).SetLoops(-1, LoopType.Restart).SetDelay(0);
        tweener1.Play();
    }
    private void InitializeTweening2(Transform slotTransform)
    {
        slotTransform.localPosition = new Vector2(slotTransform.localPosition.x, 0);
        tweener2 = slotTransform.DOLocalMoveY(-tweenHeight, 0.2f).SetLoops(-1, LoopType.Restart).SetDelay(0);
        tweener2.Play();
    }
    private void InitializeTweening3(Transform slotTransform)
    {
        slotTransform.localPosition = new Vector2(slotTransform.localPosition.x, 0);
        tweener3 = slotTransform.DOLocalMoveY(-tweenHeight, 0.2f).SetLoops(-1, LoopType.Restart).SetDelay(0);
        tweener3.Play();
    }
    private void InitializeTweening4(Transform slotTransform)
    {
        slotTransform.localPosition = new Vector2(slotTransform.localPosition.x, 0);
        tweener4 = slotTransform.DOLocalMoveY(-tweenHeight, 0.2f).SetLoops(-1, LoopType.Restart).SetDelay(0);
        tweener4.Play();
    }
    private void InitializeTweening5(Transform slotTransform)
    {
        slotTransform.localPosition = new Vector2(slotTransform.localPosition.x, 0);
        tweener5 = slotTransform.DOLocalMoveY(-tweenHeight, 0.2f).SetLoops(-1, LoopType.Restart).SetDelay(0);
        tweener5.Play();
    }

    private void StopTweening1(int reqpos, Transform slotTransform)
    {
        tweener1.Pause();
        int tweenpos = (reqpos * 100) - 150;
        tweener1 = slotTransform.DOLocalMoveY(-tweenpos, 2f);
    }
    private void StopTweening2(int reqpos, Transform slotTransform)
    {
        tweener2.Pause();
        int tweenpos = (reqpos * 100) - 150;
        tweener2 = slotTransform.DOLocalMoveY(-tweenpos, 2f);
    }
    private void StopTweening3(int reqpos, Transform slotTransform)
    {
        tweener3.Pause();
        int tweenpos = (reqpos * 100) - 150;
        tweener3 = slotTransform.DOLocalMoveY(-tweenpos, 2f);
    }
    private void StopTweening4(int reqpos, Transform slotTransform)
    {
        tweener4.Pause();
        int tweenpos = (reqpos * 100) - 150;
        tweener4 = slotTransform.DOLocalMoveY(-tweenpos, 2f);
    }
    private void StopTweening5(int reqpos, Transform slotTransform)
    {
        tweener5.Pause();
        int tweenpos = (reqpos * 100) - 150;
        tweener5 = slotTransform.DOLocalMoveY(-tweenpos, 2f);
    }

}
