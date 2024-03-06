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

    [Header("Animated Sprites")]
    [SerializeField]
    private Sprite[] A_Sprite;
    [SerializeField]
    private Sprite[] Bonus_Sprite;
    [SerializeField]
    private Sprite[] Coins_Sprite;
    [SerializeField]
    private Sprite[] Fan_Sprite;
    [SerializeField]
    private Sprite[] FreeSpin_Sprite;
    [SerializeField]
    private Sprite[] J_Sprite;
    [SerializeField]
    private Sprite[] JackPot_Sprite;
    [SerializeField]
    private Sprite[] K_Sprite;
    [SerializeField]
    private Sprite[] Q_Sprite;
    [SerializeField]
    private Sprite[] Scatter_Sprite;
    [SerializeField]
    private Sprite[] Scroll_Sprite;
    [SerializeField]
    private Sprite[] Sycee_Sprite;
    [SerializeField]
    private Sprite[] TeaPot_Sprite;
    [SerializeField]
    private Sprite[] Ten_Sprite;
    [SerializeField]
    private Sprite[] Wild_Sprite;

    [Header("Dummy Values")]
    [SerializeField]
    private List<int> Row_1_value;

    int tweenHeight = 0;

    [SerializeField]
    private GameObject Image_Prefab;

    [SerializeField]
    private PayoutCalculation PayCalculator;

    private Tweener tweener1;
    private Tweener tweener2;
    private Tweener tweener3;
    private Tweener tweener4;
    private Tweener tweener5;

    [SerializeField]
    private List<ImageAnimation> TempList;

    int numberOfSlots = 0;

    [SerializeField]
    bool isWildObj = false;

    [SerializeField]
    int dummynum1 = 0;
    [SerializeField]
    int dummynum2 = 0;
    [SerializeField]
    int dummynum3 = 0;
    [SerializeField]
    int dummynum4 = 0;
    [SerializeField]
    int dummynum5 = 0;

    private void Start()
    {
        if (SlotStart_Button) SlotStart_Button.interactable = false;
        if (SlotStart_Button) SlotStart_Button.onClick.RemoveAllListeners();
        if (SlotStart_Button) SlotStart_Button.onClick.AddListener(StartSlots);
        numberOfSlots = 5;
        PopulateInitalSlots(numberOfSlots);
    }

    private void PopulateInitalSlots(int number)
    {
        if (number >= 1) 
        {
            PopulateSlot(Row_1_value, slot1_Image, Slot_1_Transform, Slot_1_Object);
        }
        if (number >= 2)
        {
            PopulateSlot(Row_1_value, slot2_Image, Slot_2_Transform, Slot_2_Object);
        }
        if (number >= 3)
        {
            PopulateSlot(Row_1_value, slot3_Image, Slot_3_Transform, Slot_3_Object);
        }
        if (number >= 4)
        {
            PopulateSlot(Row_1_value, slot4_Image, Slot_4_Transform, Slot_4_Object);
        }
        if (number >= 5)
        {
            PopulateSlot(Row_1_value, slot5_Image, Slot_5_Transform, Slot_5_Object);
        }
        if (SlotStart_Button) SlotStart_Button.interactable = true;
    }

    private void PopulateSlot(List<int> values, List<Image> slot_Images, Transform SlotTransform, GameObject SlotObject)
    {
        if (SlotObject) SlotObject.SetActive(true);
        for(int i = 0; i<values.Count; i++)
        {
            GameObject myImg = Instantiate(Image_Prefab, SlotTransform);
            slot_Images.Add(myImg.GetComponent<Image>());
            slot_Images[i].sprite = myImages[values[i]];
            PopulateAnimationSprites(slot_Images[i].gameObject.GetComponent<ImageAnimation>(), values[i]);
        }
        for (int k = 0; k < 2; k++)
        {
            GameObject mylastImg = Instantiate(Image_Prefab, SlotTransform);
            slot_Images.Add(mylastImg.GetComponent<Image>());
            slot_Images[slot_Images.Count - 1].sprite = myImages[values[k]];
            PopulateAnimationSprites(slot_Images[slot_Images.Count - 1].gameObject.GetComponent<ImageAnimation>(), values[k]);
        }
        if (mainContainer_RT) LayoutRebuilder.ForceRebuildLayoutImmediate(mainContainer_RT);
        tweenHeight = (values.Count * 100)-150;
    }

    private void PopulateAnimationSprites(ImageAnimation animScript, int val)
    {
        switch(val)
        {
            case 0:
                for (int i = 0; i < Ten_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Ten_Sprite[i]);
                }
                break;
            case 1:
                for (int i = 0; i < A_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(A_Sprite[i]);
                }
                break;
            case 2:
                for (int i = 0; i < Bonus_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Bonus_Sprite[i]);
                }
                animScript.AnimationSpeed = 30f;
                break;
            case 3:
                for (int i = 0; i < Coins_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Coins_Sprite[i]);
                }
                break;
            case 4:
                for (int i = 0; i < Fan_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Fan_Sprite[i]);
                }
                break;
            case 5:
                for (int i = 0; i < FreeSpin_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(FreeSpin_Sprite[i]);
                }
                animScript.AnimationSpeed = 30f;
                break;
            case 6:
                for (int i = 0; i < J_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(J_Sprite[i]);
                }
                break;
            case 7:
                for (int i = 0; i < JackPot_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(JackPot_Sprite[i]);
                }
                animScript.AnimationSpeed = 30f;
                break;
            case 8:
                for (int i = 0; i < K_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(K_Sprite[i]);
                }
                break;
            case 9:
                for (int i = 0; i < Q_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Q_Sprite[i]);
                }
                break;
            case 10:
                for (int i = 0; i < Scatter_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Scatter_Sprite[i]);
                }
                animScript.AnimationSpeed = 30f;
                break;
            case 11:
                for (int i = 0; i < Scroll_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Scroll_Sprite[i]);
                }
                break;
            case 12:
                for (int i = 0; i < Sycee_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Sycee_Sprite[i]);
                }
                break;
            case 13:
                for (int i = 0; i < TeaPot_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(TeaPot_Sprite[i]);
                }
                break;
            case 14:
                for (int i = 0; i < Wild_Sprite.Length; i++)
                {
                    animScript.textureArray.Add(Wild_Sprite[i]);
                }
                animScript.AnimationSpeed = 30f;
                break;
        }
    }

    private void StartSlots()
    {
        if (SlotStart_Button) SlotStart_Button.interactable = false;
        dummynum1 = Random.Range(3, 17);
        dummynum2 = Random.Range(3, 17);
        dummynum3 = Random.Range(3, 17);
        dummynum4 = Random.Range(3, 17);
        dummynum5 = Random.Range(3, 17);
        if (TempList.Count > 0) 
        {
            StopGameAnimation();
        }
        PayCalculator.ResetLines();
        StartCoroutine(TweenRoutine());
    }

    private IEnumerator TweenRoutine()
    {
        if (numberOfSlots >= 1)
        {
            InitializeTweening1(Slot_1_Transform);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 2)
        {
            InitializeTweening2(Slot_2_Transform);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 3)
        {
            InitializeTweening3(Slot_3_Transform);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 4)
        {
            InitializeTweening4(Slot_4_Transform);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 5)
        {
            InitializeTweening5(Slot_5_Transform);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 1)
        {
            StopTweening1(dummynum1, Slot_1_Transform);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 2)
        {
            StopTweening2(dummynum2, Slot_2_Transform);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 3)
        {
            StopTweening3(dummynum3, Slot_3_Transform);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 4)
        {
            StopTweening4(dummynum4, Slot_4_Transform);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 5)
        {
            StopTweening5(dummynum5, Slot_5_Transform);
        }
        yield return new WaitForSeconds(2);
        CalculatePayoutLines(17 - dummynum1, 17 - dummynum2, 17 - dummynum3, 17 - dummynum4, 17 - dummynum5);
        if (SlotStart_Button) SlotStart_Button.interactable = true;
    }

    private void StartGameAnimation(GameObject a1 = null, GameObject a2 = null, GameObject a3 = null, GameObject a4 = null, GameObject a5 = null)
    {
        if (a1 != null)
        {
            ImageAnimation temp = a1.GetComponent<ImageAnimation>();
            temp.StartAnimation();
            TempList.Add(temp);
        }
        if (a2 != null)
        {
            ImageAnimation temp = a2.GetComponent<ImageAnimation>();
            temp.StartAnimation();
            TempList.Add(temp);
        }
        if (a3 != null)
        {
            ImageAnimation temp = a3.GetComponent<ImageAnimation>();
            temp.StartAnimation();
            TempList.Add(temp);
        }
        if (a4 != null)
        {
            ImageAnimation temp = a4.GetComponent<ImageAnimation>();
            temp.StartAnimation();
            TempList.Add(temp);
        }
        if (a5 != null)
        {
            ImageAnimation temp = a5.GetComponent<ImageAnimation>();
            temp.StartAnimation();
            TempList.Add(temp);
        }
    }

    private void StopGameAnimation()
    {
        for (int i = 0; i < TempList.Count; i++)
        {
            TempList[i].StopAnimation();
        }
        TempList.Clear();
        TempList.TrimExcess();
    }

    #region PayoutLineCalculation
    private void CalculatePayoutLines(int a1, int a2, int a3, int a4, int a5)
    {
        #region Initializations
        Sprite u1 = slot1_Image[a1].sprite;
        Sprite u2 = slot1_Image[a1 + 1].sprite;
        Sprite u3 = slot1_Image[a1 + 2].sprite;

        Sprite v1 = slot2_Image[a2].sprite;
        Sprite v2 = slot2_Image[a2 + 1].sprite;
        Sprite v3 = slot2_Image[a2 + 2].sprite;

        Sprite x1 = slot3_Image[a3].sprite;
        Sprite x2 = slot3_Image[a3 + 1].sprite;
        Sprite x3 = slot3_Image[a3 + 2].sprite;

        Sprite y1 = slot4_Image[a4].sprite;
        Sprite y2 = slot4_Image[a4 + 1].sprite;
        Sprite y3 = slot4_Image[a4 + 2].sprite;

        Sprite z1 = slot5_Image[a5].sprite;
        Sprite z2 = slot5_Image[a5 + 1].sprite;
        Sprite z3 = slot5_Image[a5 + 2].sprite;

        GameObject b1 = slot1_Image[a1].gameObject;
        GameObject b2 = slot1_Image[a1 + 1].gameObject;
        GameObject b3 = slot1_Image[a1 + 2].gameObject;

        GameObject c1 = slot2_Image[a2].gameObject;
        GameObject c2 = slot2_Image[a2 + 1].gameObject;
        GameObject c3 = slot2_Image[a2 + 2].gameObject;

        GameObject d1 = slot3_Image[a3].gameObject;
        GameObject d2 = slot3_Image[a3 + 1].gameObject;
        GameObject d3 = slot3_Image[a3 + 2].gameObject;

        GameObject e1 = slot4_Image[a4].gameObject;
        GameObject e2 = slot4_Image[a4 + 1].gameObject;
        GameObject e3 = slot4_Image[a4 + 2].gameObject;

        GameObject f1 = slot5_Image[a5].gameObject;
        GameObject f2 = slot5_Image[a5 + 1].gameObject;
        GameObject f3 = slot5_Image[a5 + 2].gameObject;
        #endregion

        if (!isWildObj)
        {
            if ((u2 == v2) && (u2 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z2))
            {
                if ((u2 == v2) && (u2 == x2) && (u2 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z2))
                {
                    if ((u2 == v2) && (u2 == x2) && (u2 == y2) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(1);
                        StartGameAnimation(b2, c2, d2, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x2) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(1, 4);
                        StartGameAnimation(c2, d2, e2, f2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(1, 4, 2);
                        StartGameAnimation(b2, c2, d2, e2);
                    }
                }
                else if ((u2 == v2) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(1, 3);
                    StartGameAnimation(b2, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(1, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(1, 3, 0, 3);
                    StartGameAnimation(d2, e2, f2);
                }
            } //Middle Line

            if ((u1 == v1) && (u1 == x1) || (v3 == x3) && (v3 == y3) || (x1 == y1) && (x1 == z1))
            {
                if ((u1 == v1) && (u1 == x1) && (u1 == y1) || (v1 == x1) && (v1 == y1) && (v1 == z1))
                {
                    if ((u1 == v1) && (u1 == x1) && (u1 == y1) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(2);
                        StartGameAnimation(b1, c1, d1, e1, f1);
                    }
                    else if ((u1 == v1) && (u1 == x1) && (u1 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(2, 4);
                        StartGameAnimation(b1, c1, d1, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(2, 4, 2);
                        StartGameAnimation(c1, d1, e1, f1);
                    }
                }
                else if ((u1 == v1) && (u1 == x1))
                {
                    PayCalculator.GeneratePayoutLine(2, 3);
                    StartGameAnimation(b1, c1, d1);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(2, 3, 0, 2);
                    StartGameAnimation(c1, d1, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(2, 3, 0, 3);
                    StartGameAnimation(d1, e1, f1);
                }
            } //Top Line

            if ((u3 == v3) && (u3 == x3) || (v3 == x3) && (v3 == y3) || (x3 == y3) && (x3 == z3))
            {
                if ((u3 == v3) && (u3 == x3) && (u3 == y3) || (v3 == x3) && (v3 == y3) && (v3 == z3))
                {
                    if ((u3 == v3) && (u3 == x3) && (u3 == y3) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(3);
                        StartGameAnimation(b3, c3, d3, e3, f3);
                    }
                    else if ((u3 == v3) && (u3 == x3) && (u3 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(3, 4);
                        StartGameAnimation(b3, c3, d3, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(3, 4, 2);
                        StartGameAnimation(c3, d3, e3, f3);
                    }
                }
                else if ((u3 == v3) && (u3 == x3))
                {
                    PayCalculator.GeneratePayoutLine(3, 3);
                    StartGameAnimation(b3, c3, d3);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(3, 3, 0, 2);
                    StartGameAnimation(c3, d3, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(3, 3, 0, 3);
                    StartGameAnimation(d3, e3, f3);
                }
            } //Bottom Line

            if ((u1 == v2) && (u1 == x3) || (v2 == x3) && (v2 == y2) || (x3 == y2) && (x3 == z1))
            {
                if ((u1 == v2) && (u1 == x3) && (u1 == y2) || (v2 == x3) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x3) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(4);
                        StartGameAnimation(b1, c2, d3, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x3) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(4, 4);
                        StartGameAnimation(b1, c2, d3, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(4, 4, 2);
                        StartGameAnimation(c2, d3, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(4, 3);
                    StartGameAnimation(b1, c2, d3);
                }
                else if ((v2 == x3) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(4, 3, 0, 2);
                    StartGameAnimation(c2, d3, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(4, 3, 0, 3);
                    StartGameAnimation(d3, e2, f1);
                }
            } //V Line

            if ((u3 == v2) && (u3 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z3))
            {
                if ((u3 == v2) && (u3 == x1) && (u3 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z3))
                {
                    if ((u3 == v2) && (u3 == x1) && (u3 == y2) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(5);
                        StartGameAnimation(b3, c2, d1, e2, f3);
                    }
                    else if ((u3 == v2) && (u3 == x1) && (u3 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(5, 4);
                        StartGameAnimation(b3, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(5, 4, 2);
                        StartGameAnimation(c2, d1, e2, f3);
                    }
                }
                else if ((u3 == v2) && (u3 == x1))
                {
                    PayCalculator.GeneratePayoutLine(5, 3);
                    StartGameAnimation(b3, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(5, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(5, 3, 0, 3);
                    StartGameAnimation(d1, e2, f3);
                }
            } //Reverse V Line

            if ((u2 == v1) && (u2 == x2) || (v1 == x2) && (v1 == y1) || (x2 == y1) && (x2 == z2))
            {
                if ((u2 == v1) && (u2 == x2) && (u2 == y1) || (v1 == x2) && (v1 == y1) && (v1 == z2))
                {
                    if ((u2 == v1) && (u2 == x2) && (u2 == y1) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(6);
                        StartGameAnimation(b2, c1, d2, e1, f2);
                    }
                    else if ((u2 == v1) && (u2 == x2) && (u2 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(6, 4);
                        StartGameAnimation(b2, c1, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(6, 4, 2);
                        StartGameAnimation(c1, d2, e1, f2);
                    }
                }
                else if ((u2 == v1) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(6, 3);
                    StartGameAnimation(b2, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y1))
                {
                    PayCalculator.GeneratePayoutLine(6, 3, 0, 2);
                    StartGameAnimation(c1, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(6, 3, 0, 3);
                    StartGameAnimation(d2, e1, f2);
                }
            } //ZigZag Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (v3 == x2) && (v3 == y3) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(7);
                        StartGameAnimation(b2, c3, d2, e3, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(7, 4);
                        StartGameAnimation(b2, c3, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(7, 4, 2);
                        StartGameAnimation(c3, d2, e3, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(7, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(7, 3, 0, 2);
                    StartGameAnimation(c3, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(7, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse ZigZag Line

            if ((u1 == v1) && (u1 == x2) || (v1 == x2) && (v1 == y3) || (x2 == y3) && (x2 == z3))
            {
                if ((u1 == v1) && (u1 == x2) && (u1 == y3) || (v1 == x2) && (v1 == y3) && (v1 == z3))
                {
                    if ((u1 == v1) && (u1 == x2) && (u1 == y3) && (u1 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(8);
                        StartGameAnimation(b1, c1, d2, e3, f3);
                    }
                    else if ((u1 == v1) && (u1 == x2) && (u1 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(8, 4);
                        StartGameAnimation(b1, c1, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(8, 4, 2);
                        StartGameAnimation(c1, d2, e3, f3);
                    }
                }
                else if ((u1 == v1) && (u1 == x2))
                {
                    PayCalculator.GeneratePayoutLine(8, 3);
                    StartGameAnimation(b1, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y3))
                {
                    PayCalculator.GeneratePayoutLine(8, 3, 0, 2);
                    StartGameAnimation(c1, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(8, 3, 0, 3);
                    StartGameAnimation(d2, e3, f3);
                }
            } //Z Line

            if ((u3 == v3) && (u3 == x2) || (v3 == x2) && (v3 == y1) || (x2 == y1) && (x2 == z1))
            {
                if ((u3 == v3) && (u3 == x2) && (u3 == y1) || (v3 == x2) && (v3 == y1) && (v3 == z1))
                {
                    if ((u3 == v3) && (u3 == x2) && (u3 == y1) && (u3 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(9);
                        StartGameAnimation(b3, c3, d2, e1, f1);
                    }
                    else if ((u3 == v3) && (u3 == x2) && (u3 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(9, 4);
                        StartGameAnimation(b3, c3, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(9, 4, 2);
                        StartGameAnimation(c3, d2, e1, f1);
                    }
                }
                else if ((u3 == v3) && (u3 == x2))
                {
                    PayCalculator.GeneratePayoutLine(9, 3);
                    StartGameAnimation(b3, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y1))
                {
                    PayCalculator.GeneratePayoutLine(9, 3, 0, 2);
                    StartGameAnimation(c3, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(9, 3, 0, 3);
                    StartGameAnimation(d2, e1, f1);
                }
            } //Reverse Z Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y1) || (x2 == y1) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y1) || (v3 == x2) && (v3 == y1) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y1) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(10);
                        StartGameAnimation(b2, c3, d2, e1, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(10, 4);
                        StartGameAnimation(b2, c3, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(10, 4, 2);
                        StartGameAnimation(c3, d2, e1, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(10, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y1))
                {
                    PayCalculator.GeneratePayoutLine(10, 3, 0, 2);
                    StartGameAnimation(c3, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(10, 3, 0, 3);
                    StartGameAnimation(d2, e1, f2);
                }
            } //Uneven Line

            if ((u2 == v1) && (u2 == x2) || (v1 == x2) && (v1 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v1) && (u2 == x2) && (u2 == y3) || (v1 == x2) && (v1 == y3) && (v1 == z2))
                {
                    if ((u2 == v1) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(11);
                        StartGameAnimation(b2, c1, d2, e3, f2);
                    }
                    else if ((u2 == v1) && (u2 == x2) && (u2 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(11, 4);
                        StartGameAnimation(b2, c1, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(11, 4, 2);
                        StartGameAnimation(c1, d2, e3, f2);
                    }
                }
                else if ((u2 == v1) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(11, 3);
                    StartGameAnimation(b2, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y3))
                {
                    PayCalculator.GeneratePayoutLine(11, 3, 0, 2);
                    StartGameAnimation(c1, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(11, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse Uneven Line

            if ((u1 == v2) && (u1 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z1))
            {
                if ((u1 == v2) && (u1 == x2) && (u1 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x2) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(12);
                        StartGameAnimation(b1, c2, d2, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x2) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(12, 4);
                        StartGameAnimation(b1, c2, d2, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(12, 4, 2);
                        StartGameAnimation(c2, d2, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x2))
                {
                    PayCalculator.GeneratePayoutLine(12, 3);
                    StartGameAnimation(b1, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(12, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(12, 3, 0, 3);
                    StartGameAnimation(d2, e2, f1);
                }
            } //U Line

            if ((u3 == v2) && (u3 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z3))
            {
                if ((u3 == v2) && (u3 == x2) && (u3 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z3))
                {
                    if ((u3 == v2) && (u3 == x2) && (u3 == y2) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(13);
                        StartGameAnimation(b3, c2, d2, e2, f3);
                    }
                    else if ((u3 == v2) && (u3 == x2) && (u3 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(13, 4);
                        StartGameAnimation(b3, c2, d2, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(13, 4, 2);
                        StartGameAnimation(c2, d2, e2, f3);
                    }
                }
                else if ((u3 == v2) && (u3 == x2))
                {
                    PayCalculator.GeneratePayoutLine(13, 3);
                    StartGameAnimation(b3, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(13, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(13, 3, 0, 3);
                    StartGameAnimation(d2, e2, f3);
                }
            } //Reverse U Line

            if ((u1 == v2) && (u1 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z1))
            {
                if ((u1 == v2) && (u1 == x1) && (u1 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x1) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(14);
                        StartGameAnimation(b1, c2, d1, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x1) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(14, 4);
                        StartGameAnimation(b1, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(14, 4, 2);
                        StartGameAnimation(c2, d1, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x1))
                {
                    PayCalculator.GeneratePayoutLine(14, 3);
                    StartGameAnimation(b1, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(14, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(14, 3, 0, 3);
                    StartGameAnimation(d1, e2, f1);
                }
            } //W Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (v3 == x2) && (v3 == y3) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(15);
                        StartGameAnimation(b2, c3, d2, e3, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(15, 4);
                        StartGameAnimation(b2, c3, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(15, 4, 2);
                        StartGameAnimation(c3, d2, e3, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(15, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(15, 3, 0, 2);
                    StartGameAnimation(c3, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(15, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse W Line

            if ((u2 == v2) && (u2 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z2))
            {
                if ((u2 == v2) && (u2 == x1) && (u2 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z2))
                {
                    if ((u2 == v2) && (u2 == x1) && (u2 == y2) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(16);
                        StartGameAnimation(b2, c2, d1, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x1) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(16, 4);
                        StartGameAnimation(b2, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(16, 4, 2);
                        StartGameAnimation(c2, d1, e2, f2);
                    }
                }
                else if ((u2 == v2) && (u2 == x1))
                {
                    PayCalculator.GeneratePayoutLine(16, 3);
                    StartGameAnimation(b2, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(16, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(16, 3, 0, 3);
                    StartGameAnimation(d1, e2, f2);
                }
            } //Reverse Small T Line

            if ((u2 == v2) && (u2 == x3) || (v2 == x3) && (v2 == y2) || (x3 == y2) && (x3 == z2))
            {
                if ((u2 == v2) && (u2 == x3) && (u2 == y2) || (v2 == x3) && (v2 == y2) && (v2 == z2))
                {
                    if ((u2 == v2) && (u2 == x3) && (u2 == y2) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(17);
                        StartGameAnimation(b2, c2, d3, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x3) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(17, 4);
                        StartGameAnimation(b2, c2, d3, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(17, 4, 2);
                        StartGameAnimation(c2, d3, e2, f2);
                    }
                }
                else if ((u2 == v2) && (u2 == x3))
                {
                    PayCalculator.GeneratePayoutLine(17, 3);
                    StartGameAnimation(b2, c2, d3);
                }
                else if ((v2 == x3) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(17, 3, 0, 2);
                    StartGameAnimation(c2, d3, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(17, 3, 0, 3);
                    StartGameAnimation(d3, e2, f2);
                }
            } //Small T Line

            if ((u1 == v1) && (u1 == x3) || (v1 == x3) && (v1 == y1) || (x3 == y1) && (x3 == z1))
            {
                if ((u1 == v1) && (u1 == x3) && (u1 == y1) || (v1 == x3) && (v1 == y1) && (v1 == z1))
                {
                    if ((u1 == v1) && (u1 == x3) && (u1 == y1) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(18);
                        StartGameAnimation(b1, c1, d3, e1, f1);
                    }
                    else if ((u1 == v1) && (u1 == x3) && (u1 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(18, 4);
                        StartGameAnimation(b1, c1, d3, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(18, 4, 2);
                        StartGameAnimation(c1, d3, e1, f1);
                    }
                }
                else if ((u1 == v1) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(18, 3);
                    StartGameAnimation(b1, c1, d3);
                }
                else if ((v1 == x3) && (v1 == y1))
                {
                    PayCalculator.GeneratePayoutLine(18, 3, 0, 2);
                    StartGameAnimation(c1, d3, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(18, 3, 0, 3);
                    StartGameAnimation(d3, e1, f1);
                }
            } //T Line

            if ((u3 == v3) && (u3 == x1) || (v3 == x1) && (v3 == y3) || (x1 == y3) && (x1 == z3))
            {
                if ((u3 == v3) && (u3 == x1) && (u3 == y3) || (v3 == x1) && (v3 == y3) && (v3 == z3))
                {
                    if ((u3 == v3) && (u3 == x1) && (u3 == y3) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(19);
                        StartGameAnimation(b3, c3, d1, e3, f3);
                    }
                    else if ((u3 == v3) && (u3 == x1) && (u3 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(19, 4);
                        StartGameAnimation(b3, c3, d1, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(19, 4, 2);
                        StartGameAnimation(c3, d1, e3, f3);
                    }
                }
                else if ((u3 == v3) && (u3 == x1))
                {
                    PayCalculator.GeneratePayoutLine(19, 3);
                    StartGameAnimation(b3, c3, d1);
                }
                else if ((v3 == x1) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(19, 3, 0, 2);
                    StartGameAnimation(c3, d1, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(19, 3, 0, 3);
                    StartGameAnimation(d1, e3, f3);
                }
            } //Reverse T Line

            if ((u1 == v3) && (u1 == x3) || (v3 == x3) && (v3 == y3) || (x3 == y3) && (x3 == z1))
            {
                if ((u1 == v3) && (u1 == x3) && (u1 == y3) || (v3 == x3) && (v3 == y3) && (v3 == z1))
                {
                    if ((u1 == v3) && (u1 == x3) && (u1 == y3) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(20);
                        StartGameAnimation(b1, c3, d3, e3, f1);
                    }
                    else if ((u1 == v3) && (u1 == x3) && (u1 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(20, 4);
                        StartGameAnimation(b1, c3, d3, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(20, 4, 2);
                        StartGameAnimation(c3, d3, e3, f1);
                    }
                }
                else if ((u1 == v3) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(20, 3);
                    StartGameAnimation(b1, c3, d3);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(20, 3, 0, 2);
                    StartGameAnimation(c3, d3, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(20, 3, 0, 3);
                    StartGameAnimation(d3, e3, f1);
                }
            } //Smiley Line
        }
        else
        {
            if ((u2 == v2) && (u2 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z2))
            {
                if ((u2 == v2) && (u2 == x2) && (u2 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z2))
                {
                    if (((u2 == v2) && (u2 == x2) && (u2 == y2) && (u2 == z2)) || u2 == myImages[myImages.Length - 1] || z2 == myImages[myImages.Length - 1]) 
                    {
                        PayCalculator.GeneratePayoutLine(1);
                        StartGameAnimation(b2, c2, d2, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x2) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(1, 4);
                        StartGameAnimation(c2, d2, e2, f2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(1, 4, 2);
                        StartGameAnimation(b2, c2, d2, e2);
                    }
                }
                else if ((u2 == v2) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(1, 3);
                    StartGameAnimation(b2, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(1, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(1, 3, 0, 3);
                    StartGameAnimation(d2, e2, f2);
                }
            } //Middle Line

            if ((u1 == v1) && (u1 == x1) || (v3 == x3) && (v3 == y3) || (x1 == y1) && (x1 == z1))
            {
                if ((u1 == v1) && (u1 == x1) && (u1 == y1) || (v1 == x1) && (v1 == y1) && (v1 == z1))
                {
                    if ((u1 == v1) && (u1 == x1) && (u1 == y1) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(2);
                        StartGameAnimation(b1, c1, d1, e1, f1);
                    }
                    else if ((u1 == v1) && (u1 == x1) && (u1 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(2, 4);
                        StartGameAnimation(b1, c1, d1, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(2, 4, 2);
                        StartGameAnimation(c1, d1, e1, f1);
                    }
                }
                else if ((u1 == v1) && (u1 == x1))
                {
                    PayCalculator.GeneratePayoutLine(2, 3);
                    StartGameAnimation(b1, c1, d1);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(2, 3, 0, 2);
                    StartGameAnimation(c1, d1, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(2, 3, 0, 3);
                    StartGameAnimation(d1, e1, f1);
                }
            } //Top Line

            if ((u3 == v3) && (u3 == x3) || (v3 == x3) && (v3 == y3) || (x3 == y3) && (x3 == z3))
            {
                if ((u3 == v3) && (u3 == x3) && (u3 == y3) || (v3 == x3) && (v3 == y3) && (v3 == z3))
                {
                    if ((u3 == v3) && (u3 == x3) && (u3 == y3) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(3);
                        StartGameAnimation(b3, c3, d3, e3, f3);
                    }
                    else if ((u3 == v3) && (u3 == x3) && (u3 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(3, 4);
                        StartGameAnimation(b3, c3, d3, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(3, 4, 2);
                        StartGameAnimation(c3, d3, e3, f3);
                    }
                }
                else if ((u3 == v3) && (u3 == x3))
                {
                    PayCalculator.GeneratePayoutLine(3, 3);
                    StartGameAnimation(b3, c3, d3);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(3, 3, 0, 2);
                    StartGameAnimation(c3, d3, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(3, 3, 0, 3);
                    StartGameAnimation(d3, e3, f3);
                }
            } //Bottom Line

            if ((u1 == v2) && (u1 == x3) || (v2 == x3) && (v2 == y2) || (x3 == y2) && (x3 == z1))
            {
                if ((u1 == v2) && (u1 == x3) && (u1 == y2) || (v2 == x3) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x3) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(4);
                        StartGameAnimation(b1, c2, d3, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x3) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(4, 4);
                        StartGameAnimation(b1, c2, d3, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(4, 4, 2);
                        StartGameAnimation(c2, d3, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(4, 3);
                    StartGameAnimation(b1, c2, d3);
                }
                else if ((v2 == x3) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(4, 3, 0, 2);
                    StartGameAnimation(c2, d3, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(4, 3, 0, 3);
                    StartGameAnimation(d3, e2, f1);
                }
            } //V Line

            if ((u3 == v2) && (u3 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z3))
            {
                if ((u3 == v2) && (u3 == x1) && (u3 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z3))
                {
                    if ((u3 == v2) && (u3 == x1) && (u3 == y2) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(5);
                        StartGameAnimation(b3, c2, d1, e2, f3);
                    }
                    else if ((u3 == v2) && (u3 == x1) && (u3 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(5, 4);
                        StartGameAnimation(b3, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(5, 4, 2);
                        StartGameAnimation(c2, d1, e2, f3);
                    }
                }
                else if ((u3 == v2) && (u3 == x1))
                {
                    PayCalculator.GeneratePayoutLine(5, 3);
                    StartGameAnimation(b3, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(5, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(5, 3, 0, 3);
                    StartGameAnimation(d1, e2, f3);
                }
            } //Reverse V Line

            if ((u2 == v1) && (u2 == x2) || (v1 == x2) && (v1 == y1) || (x2 == y1) && (x2 == z2))
            {
                if ((u2 == v1) && (u2 == x2) && (u2 == y1) || (v1 == x2) && (v1 == y1) && (v1 == z2))
                {
                    if ((u2 == v1) && (u2 == x2) && (u2 == y1) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(6);
                        StartGameAnimation(b2, c1, d2, e1, f2);
                    }
                    else if ((u2 == v1) && (u2 == x2) && (u2 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(6, 4);
                        StartGameAnimation(b2, c1, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(6, 4, 2);
                        StartGameAnimation(c1, d2, e1, f2);
                    }
                }
                else if ((u2 == v1) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(6, 3);
                    StartGameAnimation(b2, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y1))
                {
                    PayCalculator.GeneratePayoutLine(6, 3, 0, 2);
                    StartGameAnimation(c1, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(6, 3, 0, 3);
                    StartGameAnimation(d2, e1, f2);
                }
            } //ZigZag Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (v3 == x2) && (v3 == y3) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(7);
                        StartGameAnimation(b2, c3, d2, e3, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(7, 4);
                        StartGameAnimation(b2, c3, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(7, 4, 2);
                        StartGameAnimation(c3, d2, e3, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(7, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(7, 3, 0, 2);
                    StartGameAnimation(c3, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(7, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse ZigZag Line

            if ((u1 == v1) && (u1 == x2) || (v1 == x2) && (v1 == y3) || (x2 == y3) && (x2 == z3))
            {
                if ((u1 == v1) && (u1 == x2) && (u1 == y3) || (v1 == x2) && (v1 == y3) && (v1 == z3))
                {
                    if ((u1 == v1) && (u1 == x2) && (u1 == y3) && (u1 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(8);
                        StartGameAnimation(b1, c1, d2, e3, f3);
                    }
                    else if ((u1 == v1) && (u1 == x2) && (u1 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(8, 4);
                        StartGameAnimation(b1, c1, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(8, 4, 2);
                        StartGameAnimation(c1, d2, e3, f3);
                    }
                }
                else if ((u1 == v1) && (u1 == x2))
                {
                    PayCalculator.GeneratePayoutLine(8, 3);
                    StartGameAnimation(b1, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y3))
                {
                    PayCalculator.GeneratePayoutLine(8, 3, 0, 2);
                    StartGameAnimation(c1, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(8, 3, 0, 3);
                    StartGameAnimation(d2, e3, f3);
                }
            } //Z Line

            if ((u3 == v3) && (u3 == x2) || (v3 == x2) && (v3 == y1) || (x2 == y1) && (x2 == z1))
            {
                if ((u3 == v3) && (u3 == x2) && (u3 == y1) || (v3 == x2) && (v3 == y1) && (v3 == z1))
                {
                    if ((u3 == v3) && (u3 == x2) && (u3 == y1) && (u3 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(9);
                        StartGameAnimation(b3, c3, d2, e1, f1);
                    }
                    else if ((u3 == v3) && (u3 == x2) && (u3 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(9, 4);
                        StartGameAnimation(b3, c3, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(9, 4, 2);
                        StartGameAnimation(c3, d2, e1, f1);
                    }
                }
                else if ((u3 == v3) && (u3 == x2))
                {
                    PayCalculator.GeneratePayoutLine(9, 3);
                    StartGameAnimation(b3, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y1))
                {
                    PayCalculator.GeneratePayoutLine(9, 3, 0, 2);
                    StartGameAnimation(c3, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(9, 3, 0, 3);
                    StartGameAnimation(d2, e1, f1);
                }
            } //Reverse Z Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y1) || (x2 == y1) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y1) || (v3 == x2) && (v3 == y1) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y1) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(10);
                        StartGameAnimation(b2, c3, d2, e1, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(10, 4);
                        StartGameAnimation(b2, c3, d2, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(10, 4, 2);
                        StartGameAnimation(c3, d2, e1, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(10, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y1))
                {
                    PayCalculator.GeneratePayoutLine(10, 3, 0, 2);
                    StartGameAnimation(c3, d2, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(10, 3, 0, 3);
                    StartGameAnimation(d2, e1, f2);
                }
            } //Uneven Line

            if ((u2 == v1) && (u2 == x2) || (v1 == x2) && (v1 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v1) && (u2 == x2) && (u2 == y3) || (v1 == x2) && (v1 == y3) && (v1 == z2))
                {
                    if ((u2 == v1) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(11);
                        StartGameAnimation(b2, c1, d2, e3, f2);
                    }
                    else if ((u2 == v1) && (u2 == x2) && (u2 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(11, 4);
                        StartGameAnimation(b2, c1, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(11, 4, 2);
                        StartGameAnimation(c1, d2, e3, f2);
                    }
                }
                else if ((u2 == v1) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(11, 3);
                    StartGameAnimation(b2, c1, d2);
                }
                else if ((v1 == x2) && (v1 == y3))
                {
                    PayCalculator.GeneratePayoutLine(11, 3, 0, 2);
                    StartGameAnimation(c1, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(11, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse Uneven Line

            if ((u1 == v2) && (u1 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z1))
            {
                if ((u1 == v2) && (u1 == x2) && (u1 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x2) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(12);
                        StartGameAnimation(b1, c2, d2, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x2) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(12, 4);
                        StartGameAnimation(b1, c2, d2, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(12, 4, 2);
                        StartGameAnimation(c2, d2, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x2))
                {
                    PayCalculator.GeneratePayoutLine(12, 3);
                    StartGameAnimation(b1, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(12, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(12, 3, 0, 3);
                    StartGameAnimation(d2, e2, f1);
                }
            } //U Line

            if ((u3 == v2) && (u3 == x2) || (v2 == x2) && (v2 == y2) || (x2 == y2) && (x2 == z3))
            {
                if ((u3 == v2) && (u3 == x2) && (u3 == y2) || (v2 == x2) && (v2 == y2) && (v2 == z3))
                {
                    if ((u3 == v2) && (u3 == x2) && (u3 == y2) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(13);
                        StartGameAnimation(b3, c2, d2, e2, f3);
                    }
                    else if ((u3 == v2) && (u3 == x2) && (u3 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(13, 4);
                        StartGameAnimation(b3, c2, d2, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(13, 4, 2);
                        StartGameAnimation(c2, d2, e2, f3);
                    }
                }
                else if ((u3 == v2) && (u3 == x2))
                {
                    PayCalculator.GeneratePayoutLine(13, 3);
                    StartGameAnimation(b3, c2, d2);
                }
                else if ((v2 == x2) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(13, 3, 0, 2);
                    StartGameAnimation(c2, d2, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(13, 3, 0, 3);
                    StartGameAnimation(d2, e2, f3);
                }
            } //Reverse U Line

            if ((u1 == v2) && (u1 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z1))
            {
                if ((u1 == v2) && (u1 == x1) && (u1 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z1))
                {
                    if ((u1 == v2) && (u1 == x1) && (u1 == y2) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(14);
                        StartGameAnimation(b1, c2, d1, e2, f1);
                    }
                    else if ((u1 == v2) && (u1 == x1) && (u1 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(14, 4);
                        StartGameAnimation(b1, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(14, 4, 2);
                        StartGameAnimation(c2, d1, e2, f1);
                    }
                }
                else if ((u1 == v2) && (u1 == x1))
                {
                    PayCalculator.GeneratePayoutLine(14, 3);
                    StartGameAnimation(b1, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(14, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(14, 3, 0, 3);
                    StartGameAnimation(d1, e2, f1);
                }
            } //W Line

            if ((u2 == v3) && (u2 == x2) || (v3 == x2) && (v3 == y3) || (x2 == y3) && (x2 == z2))
            {
                if ((u2 == v3) && (u2 == x2) && (u2 == y3) || (v3 == x2) && (v3 == y3) && (v3 == z2))
                {
                    if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(15);
                        StartGameAnimation(b2, c3, d2, e3, f2);
                    }
                    else if ((u2 == v3) && (u2 == x2) && (u2 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(15, 4);
                        StartGameAnimation(b2, c3, d2, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(15, 4, 2);
                        StartGameAnimation(c3, d2, e3, f2);
                    }
                }
                else if ((u2 == v3) && (u2 == x2))
                {
                    PayCalculator.GeneratePayoutLine(15, 3);
                    StartGameAnimation(b2, c3, d2);
                }
                else if ((v3 == x2) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(15, 3, 0, 2);
                    StartGameAnimation(c3, d2, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(15, 3, 0, 3);
                    StartGameAnimation(d2, e3, f2);
                }
            } //Reverse W Line

            if ((u2 == v2) && (u2 == x1) || (v2 == x1) && (v2 == y2) || (x1 == y2) && (x1 == z2))
            {
                if ((u2 == v2) && (u2 == x1) && (u2 == y2) || (v2 == x1) && (v2 == y2) && (v2 == z2))
                {
                    if ((u2 == v2) && (u2 == x1) && (u2 == y2) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(16);
                        StartGameAnimation(b2, c2, d1, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x1) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(16, 4);
                        StartGameAnimation(b2, c2, d1, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(16, 4, 2);
                        StartGameAnimation(c2, d1, e2, f2);
                    }
                }
                else if ((u2 == v2) && (u2 == x1))
                {
                    PayCalculator.GeneratePayoutLine(16, 3);
                    StartGameAnimation(b2, c2, d1);
                }
                else if ((v2 == x1) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(16, 3, 0, 2);
                    StartGameAnimation(c2, d1, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(16, 3, 0, 3);
                    StartGameAnimation(d1, e2, f2);
                }
            } //Reverse Small T Line

            if ((u2 == v2) && (u2 == x3) || (v2 == x3) && (v2 == y2) || (x3 == y2) && (x3 == z2))
            {
                if ((u2 == v2) && (u2 == x3) && (u2 == y2) || (v2 == x3) && (v2 == y2) && (v2 == z2))
                {
                    if ((u2 == v2) && (u2 == x3) && (u2 == y2) && (u2 == z2))
                    {
                        PayCalculator.GeneratePayoutLine(17);
                        StartGameAnimation(b2, c2, d3, e2, f2);
                    }
                    else if ((u2 == v2) && (u2 == x3) && (u2 == y2))
                    {
                        PayCalculator.GeneratePayoutLine(17, 4);
                        StartGameAnimation(b2, c2, d3, e2);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(17, 4, 2);
                        StartGameAnimation(c2, d3, e2, f2);
                    }
                }
                else if ((u2 == v2) && (u2 == x3))
                {
                    PayCalculator.GeneratePayoutLine(17, 3);
                    StartGameAnimation(b2, c2, d3);
                }
                else if ((v2 == x3) && (v2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(17, 3, 0, 2);
                    StartGameAnimation(c2, d3, e2);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(17, 3, 0, 3);
                    StartGameAnimation(d3, e2, f2);
                }
            } //Small T Line

            if ((u1 == v1) && (u1 == x3) || (v1 == x3) && (v1 == y1) || (x3 == y1) && (x3 == z1))
            {
                if ((u1 == v1) && (u1 == x3) && (u1 == y1) || (v1 == x3) && (v1 == y1) && (v1 == z1))
                {
                    if ((u1 == v1) && (u1 == x3) && (u1 == y1) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(18);
                        StartGameAnimation(b1, c1, d3, e1, f1);
                    }
                    else if ((u1 == v1) && (u1 == x3) && (u1 == y1))
                    {
                        PayCalculator.GeneratePayoutLine(18, 4);
                        StartGameAnimation(b1, c1, d3, e1);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(18, 4, 2);
                        StartGameAnimation(c1, d3, e1, f1);
                    }
                }
                else if ((u1 == v1) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(18, 3);
                    StartGameAnimation(b1, c1, d3);
                }
                else if ((v1 == x3) && (v1 == y1))
                {
                    PayCalculator.GeneratePayoutLine(18, 3, 0, 2);
                    StartGameAnimation(c1, d3, e1);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(18, 3, 0, 3);
                    StartGameAnimation(d3, e1, f1);
                }
            } //T Line

            if ((u3 == v3) && (u3 == x1) || (v3 == x1) && (v3 == y3) || (x1 == y3) && (x1 == z3))
            {
                if ((u3 == v3) && (u3 == x1) && (u3 == y3) || (v3 == x1) && (v3 == y3) && (v3 == z3))
                {
                    if ((u3 == v3) && (u3 == x1) && (u3 == y3) && (u3 == z3))
                    {
                        PayCalculator.GeneratePayoutLine(19);
                        StartGameAnimation(b3, c3, d1, e3, f3);
                    }
                    else if ((u3 == v3) && (u3 == x1) && (u3 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(19, 4);
                        StartGameAnimation(b3, c3, d1, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(19, 4, 2);
                        StartGameAnimation(c3, d1, e3, f3);
                    }
                }
                else if ((u3 == v3) && (u3 == x1))
                {
                    PayCalculator.GeneratePayoutLine(19, 3);
                    StartGameAnimation(b3, c3, d1);
                }
                else if ((v3 == x1) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(19, 3, 0, 2);
                    StartGameAnimation(c3, d1, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(19, 3, 0, 3);
                    StartGameAnimation(d1, e3, f3);
                }
            } //Reverse T Line

            if ((u1 == v3) && (u1 == x3) || (v3 == x3) && (v3 == y3) || (x3 == y3) && (x3 == z1))
            {
                if ((u1 == v3) && (u1 == x3) && (u1 == y3) || (v3 == x3) && (v3 == y3) && (v3 == z1))
                {
                    if ((u1 == v3) && (u1 == x3) && (u1 == y3) && (u1 == z1))
                    {
                        PayCalculator.GeneratePayoutLine(20);
                        StartGameAnimation(b1, c3, d3, e3, f1);
                    }
                    else if ((u1 == v3) && (u1 == x3) && (u1 == y3))
                    {
                        PayCalculator.GeneratePayoutLine(20, 4);
                        StartGameAnimation(b1, c3, d3, e3);
                    }
                    else
                    {
                        PayCalculator.GeneratePayoutLine(20, 4, 2);
                        StartGameAnimation(c3, d3, e3, f1);
                    }
                }
                else if ((u1 == v3) && (u1 == x3))
                {
                    PayCalculator.GeneratePayoutLine(20, 3);
                    StartGameAnimation(b1, c3, d3);
                }
                else if ((v3 == x3) && (v3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(20, 3, 0, 2);
                    StartGameAnimation(c3, d3, e3);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(20, 3, 0, 3);
                    StartGameAnimation(d3, e3, f1);
                }
            } //Smiley Line
        }
    }
    #endregion

    #region TweeningCode
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
    #endregion

}
