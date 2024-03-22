using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

public class SlotBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform mainContainer_RT;

    [Header("Sprites")]
    [SerializeField]
    private Sprite[] myImages;
    [SerializeField]
    private Sprite WildSprite;

    [Header("Slot Images")]
    [SerializeField]
    private List<SlotImage> images;
    [SerializeField]
    private List<SlotImage> Tempimages;

    [Header("Slots Objects")]
    [SerializeField]
    private GameObject[] Slot_Objects;
    [Header("Slots Elements")]
    [SerializeField]
    private LayoutElement[] Slot_Elements;

    [Header("Slots Transforms")]
    [SerializeField]
    private Transform[] Slot_Transform;

    [Header("Line Button Objects")]
    [SerializeField]
    private List<GameObject> StaticLine_Objects;

    [Header("Line Button Texts")]
    [SerializeField]
    private List<TMP_Text> StaticLine_Texts;

    private Dictionary<int, string> x_string = new Dictionary<int, string>();
    private Dictionary<int, string> y_string = new Dictionary<int, string>();

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

    [Header("Hold Buttons")]
    [SerializeField]
    private List<Button> Hold_Buttons;

    [Header("Hold Images")]
    [SerializeField]
    private List<Image> Hold_Images;

    [Header("Header Sprites")]
    [SerializeField]
    private Sprite HoldEnable_Sprite;
    [SerializeField]
    private Sprite HoldDisable_Sprite;

    [Header("Miscellaneous UI")]
    [SerializeField]
    private TMP_Text Balance_text;
    [SerializeField]
    private TMP_Text TotalBet_text;
    [SerializeField]
    private TMP_Text Lines_text;
    [SerializeField]
    private TMP_Text TotalWin_text;
    [SerializeField]
    private Button AutoSpin_Button;
    [SerializeField]
    private Button MaxBet_Button;
    [SerializeField]
    private Button BetPlus_Button;
    [SerializeField]
    private Button BetMinus_Button;
    [SerializeField]
    private Button LinePlus_Button;
    [SerializeField]
    private Button LineMinus_Button;

    [Header("Dummy Values")]
    [SerializeField]
    private List<int> Row_1_value;
    [SerializeField]
    private List<string> x_values;
    [SerializeField]
    private List<string> y_values;
    [SerializeField]
    private List<int> LineIds;

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

    [SerializeField]
    private int IconSizeFactor = 100;

    private int numberOfSlots = 5;


    [SerializeField]
    bool isWildObj = true;

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

    [SerializeField]
    int verticalVisibility = 3;

    Coroutine AutoSpinRoutine = null;
    private int[,] mainArr;

    private void Start()
    {
        if (SlotStart_Button) SlotStart_Button.interactable = false;

        if (SlotStart_Button) SlotStart_Button.onClick.RemoveAllListeners();
        if (SlotStart_Button) SlotStart_Button.onClick.AddListener(StartSlots);

        for (int i = 0; i < Hold_Buttons.Count; i++)
        {
            int j = i;
            if (Hold_Buttons[i]) Hold_Buttons[i].onClick.RemoveAllListeners();
            if (Hold_Buttons[i]) Hold_Buttons[i].onClick.AddListener(delegate { HoldSlot(j); });
        }

        if (BetPlus_Button) BetPlus_Button.onClick.RemoveAllListeners();
        if (BetPlus_Button) BetPlus_Button.onClick.AddListener(delegate { ChangeBet(true); });
        if (BetMinus_Button) BetMinus_Button.onClick.RemoveAllListeners();
        if (BetMinus_Button) BetMinus_Button.onClick.AddListener(delegate { ChangeBet(false); });

        if (LinePlus_Button) LinePlus_Button.onClick.RemoveAllListeners();
        if (LinePlus_Button) LinePlus_Button.onClick.AddListener(delegate { ChangeLine(true); });
        if (LineMinus_Button) LineMinus_Button.onClick.RemoveAllListeners();
        if (LineMinus_Button) LineMinus_Button.onClick.AddListener(delegate { ChangeLine(false); });

        if (MaxBet_Button) MaxBet_Button.onClick.RemoveAllListeners();
        if (MaxBet_Button) MaxBet_Button.onClick.AddListener(MaxBet);

        //if (AutoSpin_Button) AutoSpin_Button.onClick.RemoveAllListeners();
        //if (AutoSpin_Button) AutoSpin_Button.onClick.AddListener(AutoSpin);
        numberOfSlots = 5;
        PopulateInitalSlots(numberOfSlots);
        FetchLines();
    }

    private void FetchLines()
    {
        for (int i = 0; i < LineIds.Count; i++)
        {
            x_string.Add(LineIds[i], x_values[i]);
            y_string.Add(LineIds[i], y_values[i]);
            StaticLine_Texts[i].text = LineIds[i].ToString();
            StaticLine_Objects[i].SetActive(true);
        }
    }

    internal void GenerateStaticLine(TMP_Text LineID_Text)
    {
        DestroyStaticLine();
        int LineID = 1;
        try
        {
            LineID = int.Parse(LineID_Text.text);
        }
        catch(Exception e)
        {
            Debug.Log("Exception while parsing " + e.Message);
        }
        List<int> x_points = null;
        List<int> y_points = null;
        x_points = x_string[LineID]?.Split(',')?.Select(Int32.Parse)?.ToList();
        y_points = y_string[LineID]?.Split(',')?.Select(Int32.Parse)?.ToList();
        PayCalculator.GeneratePayoutLinesBackend(x_points, y_points, x_points.Count, true);
    }

    internal void DestroyStaticLine()
    {
        PayCalculator.ResetStaticLine();
    }

    bool IsAutoSpin = false;

    bool SlotRunning = false;
   
    //private void AutoSpin()
    //{
    //    if(IsAutoSpin)
    //    {
    //        if(AutoSpinRoutine != null)
    //        {
    //            StopCoroutine(AutoSpinRoutine);
    //            AutoSpinRoutine = null;
    //        }
    //    }
    //    else
    //    {
    //        if (AutoSpinRoutine != null)
    //        {
    //            StopCoroutine(AutoSpinRoutine);
    //            AutoSpinRoutine = null;
    //        }

    //        AutoSpinRoutine = StartCoroutine(SpinRoutine());
    //    }
    //}

    //private IEnumerator SpinRoutine()
    //{
    //    StartSlots();
    //}

    private void MaxBet()
    {
        if (TotalBet_text) TotalBet_text.text = "99999";
    }

    private void ChangeLine(bool IncDec)
    {
        double currentline = 1;
        try
        {
            currentline = double.Parse(Lines_text.text);
        }
        catch (Exception e)
        {
            Debug.Log("parse error " + e);
        }
        if (IncDec)
        {
            if (currentline < 20)
            {
                currentline += 1;
            }
            else
            {
                currentline = 20;
            }

            if (currentline > 20)
            {
                currentline = 20;
            }
        }
        else
        {
            if (currentline > 1)
            {
                currentline -= 1;
            }
            else
            {
                currentline = 1;
            }

            if (currentline < 1)
            {
                currentline = 1;
            }
        }

        if (Lines_text) Lines_text.text = currentline.ToString();

    }

    private void ChangeBet(bool IncDec)
    {
        double currentbet = 0;
        try
        {
            currentbet = double.Parse(TotalBet_text.text);
        }
        catch(Exception e)
        {
            Debug.Log("parse error " + e);
        }
        if(IncDec)
        {
            if(currentbet < 99999)
            {
                currentbet += 100;
            }
            else
            {
                currentbet = 99999;
            }

            if(currentbet > 99999)
            {
                currentbet = 99999;
            }
        }
        else
        {
            if (currentbet > 0)
            {
                currentbet -= 100;
            }
            else
            {
                currentbet = 0;
            }

            if (currentbet < 0)
            {
                currentbet = 0;
            }
        }

        if (TotalBet_text) TotalBet_text.text = currentbet.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && SlotStart_Button.interactable)
        {
            StartSlots();
        }
    }

    private void PopulateInitalSlots(int number)
    {
        for (int i = 0; i < number; i++)
        {
            PopulateSlot(Row_1_value, i);
        }

        for (int i = 0; i < number; i++) 
        {
            if (Slot_Elements[i]) Slot_Elements[i].ignoreLayout = true;
        }
        if (SlotStart_Button) SlotStart_Button.interactable = true;
    }

    private void PopulateSlot(List<int> values , int number)
    {
        if (Slot_Objects[number]) Slot_Objects[number].SetActive(true);
        for(int i = 0; i<values.Count; i++)
        {
            GameObject myImg = Instantiate(Image_Prefab, Slot_Transform[number]);
            images[number].slotImages.Add(myImg.GetComponent<Image>());
            images[number].slotImages[i].sprite = myImages[values[i]];
            PopulateAnimationSprites(images[number].slotImages[i].gameObject.GetComponent<ImageAnimation>(), values[i]);
        }
        for (int k = 0; k < 2; k++)
        {
            GameObject mylastImg = Instantiate(Image_Prefab, Slot_Transform[number]);
            images[number].slotImages.Add(mylastImg.GetComponent<Image>());
            images[number].slotImages[images[number].slotImages.Count - 1].sprite = myImages[values[k]];
            PopulateAnimationSprites(images[number].slotImages[images[number].slotImages.Count - 1].gameObject.GetComponent<ImageAnimation>(), values[k]);
        }
        if (mainContainer_RT) LayoutRebuilder.ForceRebuildLayoutImmediate(mainContainer_RT);
        tweenHeight = (values.Count * IconSizeFactor) - 280;
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

    private void HoldSlot(int holdImg)
    {
        if (Hold_Images[holdImg].sprite == HoldEnable_Sprite) 
        {
            Hold_Images[holdImg].sprite = HoldDisable_Sprite;
        }
        else
        {
            Hold_Images[holdImg].sprite = HoldEnable_Sprite;
        }
    }

    private void StartSlots()
    {
        if (SlotStart_Button) SlotStart_Button.interactable = false;
        //if (Hold_Images[0].sprite == HoldDisable_Sprite)
        //{
        //    dummynum1 = UnityEngine.Random.Range(3, 17);
        //}
        //if (Hold_Images[1].sprite == HoldDisable_Sprite)
        //{
        //    dummynum2 = UnityEngine.Random.Range(3, 17);
        //}
        //if (Hold_Images[2].sprite == HoldDisable_Sprite)
        //{
        //    dummynum3 = UnityEngine.Random.Range(3, 17);
        //}
        //if (Hold_Images[3].sprite == HoldDisable_Sprite)
        //{
        //    dummynum4 = UnityEngine.Random.Range(3, 17);
        //}
        //if (Hold_Images[4].sprite == HoldDisable_Sprite)
        //{
        //    dummynum5 = UnityEngine.Random.Range(3, 17);
        //}
        if (TempList.Count > 0) 
        {
            StopGameAnimation();
        }
        PayCalculator.ResetLines();
        StartCoroutine(TweenRoutine());
    }

    [SerializeField]
    private List<int> TempLineIds;
    [SerializeField]
    private List<string> x_animationString;
    [SerializeField]
    private List<string> y_animationString;

    private IEnumerator TweenRoutine()
    {
        if (numberOfSlots >= 1 && Hold_Images[0].sprite == HoldDisable_Sprite)
        {
            InitializeTweening1(Slot_Transform[0]);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 2 && Hold_Images[1].sprite == HoldDisable_Sprite)
        {
            InitializeTweening2(Slot_Transform[1]);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 3 && Hold_Images[2].sprite == HoldDisable_Sprite)
        {
            InitializeTweening3(Slot_Transform[2]);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 4 && Hold_Images[3].sprite == HoldDisable_Sprite)
        {
            InitializeTweening4(Slot_Transform[3]);
        }
        yield return new WaitForSeconds(0.1f);

        if (numberOfSlots >= 5 && Hold_Images[4].sprite == HoldDisable_Sprite)
        {
            InitializeTweening5(Slot_Transform[4]);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 1 && Hold_Images[0].sprite == HoldDisable_Sprite)
        {
            yield return StopTweening1(dummynum1, Slot_Transform[0]);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 2 && Hold_Images[1].sprite == HoldDisable_Sprite)
        {
            yield return StopTweening2(dummynum2, Slot_Transform[1]);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 3 && Hold_Images[2].sprite == HoldDisable_Sprite)
        {
            yield return StopTweening3(dummynum3, Slot_Transform[2]);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 4 && Hold_Images[3].sprite == HoldDisable_Sprite)
        {
            yield return StopTweening4(dummynum4, Slot_Transform[3]);
        }
        yield return new WaitForSeconds(1);
        if (numberOfSlots >= 5 && Hold_Images[4].sprite == HoldDisable_Sprite)
        {
            yield return StopTweening5(dummynum5, Slot_Transform[4]);
        }
        string dummynum = dummynum1 + "," + dummynum2 + "," + dummynum3 + "," + dummynum4 + "," + dummynum5;
        yield return new WaitForSeconds(0.3f);
        GenerateMatrix(dummynum);
        CheckPayoutLineBackend(TempLineIds, x_animationString, y_animationString);
        //CalculatePayoutLines(17 - dummynum1, 17 - dummynum2, 17 - dummynum3, 17 - dummynum4, 17 - dummynum5);
        KillAllTweens();
        if (SlotStart_Button) SlotStart_Button.interactable = true;
        ResetHold();
    }

    private void ResetHold()
    {
        for(int i = 0; i< Hold_Images.Count;i++)
        {
            Hold_Images[i].sprite = HoldDisable_Sprite;
        }
    }

    private void StartGameAnimation(GameObject animObjects) 
    {
        ImageAnimation temp = animObjects.GetComponent<ImageAnimation>();
        temp.StartAnimation();
        TempList.Add(temp);
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

    private void CheckPayoutLineBackend(List<int> LineId, List<string> x_AnimString, List<string> y_AnimString)
    {
        List<int> x_points = null;
        List<int> y_points = null;
        List<int> x_anim = null;
        List<int> y_anim = null;

        for (int i = 0; i < LineId.Count; i++)
        {
            x_points = x_string[LineId[i]]?.Split(',')?.Select(Int32.Parse)?.ToList();
            y_points = y_string[LineId[i]]?.Split(',')?.Select(Int32.Parse)?.ToList();
            PayCalculator.GeneratePayoutLinesBackend(x_points, y_points, x_points.Count);
        }

        for (int i = 0; i < x_AnimString.Count; i++)
        {
            x_anim = x_AnimString[i]?.Split(',')?.Select(Int32.Parse)?.ToList();
        }
        for (int i = 0; i < x_AnimString.Count; i++)
        {
            y_anim = y_AnimString[i]?.Split(',')?.Select(Int32.Parse)?.ToList();
        }

        for (int i = 0; i < x_anim.Count; i++) 
        {
            StartGameAnimation(Tempimages[x_anim[i]].slotImages[y_anim[i]].gameObject);
        }
    }

    private void GenerateMatrix(string stopList)
    {
        List<int> numbers = stopList?.Split(',')?.Select(Int32.Parse)?.ToList();

        for (int i = 0; i < numbers.Count; i++)
        {
            for (int s = 0; s < verticalVisibility; s++)
            {
                Tempimages[i].slotImages.Add(images[i].slotImages[(images[i].slotImages.Count - numbers[i]) + s]);
            }
        }
    }

    //private void CheckPayoutLine(Sprite u = null, Sprite v = null, Sprite x = null, Sprite y = null, Sprite z = null, GameObject b = null, GameObject c = null, GameObject d = null, GameObject e = null, GameObject f = null, int LineNum = -1, Sprite w = null, bool debugval = false)
    //{
    //    int nval = 0;
    //    List<Sprite> temp_arr = new List<Sprite> { u, v, x, y, z };
    //    nval = temp_arr.Count - temp_arr.Distinct().Count() + 1;
    //    temp_arr.Clear();
    //    if (w == null) // disabled wild card
    //    {
    //        if ((u == v) && (u == x) || (v == x) && (v == y) || (x == y) && (x == z))
    //        {
    //            if ((u == v) && (u == x) && (u == y) || (v == x) && (v == y) && (v == z))
    //            {
    //                if ((u == v) && (u == x) && (u == y) && (u == z))
    //                {
    //                    PayCalculator.GeneratePayoutLine(LineNum);
    //                    StartGameAnimation(b, c, d, e, f);
    //                }
    //                else if ((u == v) && (u == x) && (u == y))
    //                {
    //                    PayCalculator.GeneratePayoutLine(LineNum, 4);
    //                    StartGameAnimation(b, c, d, e);
    //                }
    //                else
    //                {
    //                    PayCalculator.GeneratePayoutLine(LineNum, 4, 2);
    //                    StartGameAnimation(c, d, e, f);
    //                }
    //            }
    //            else if ((u == v) && (u == x))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3);
    //                StartGameAnimation(b, c, d);
    //            }
    //            else if ((v == x) && (v == y))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 2);
    //                StartGameAnimation(c, d, e);
    //            }
    //            else
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 3);
    //                StartGameAnimation(d, e, f);
    //            }
    //        }
    //    }
    //    else //enabled wild card
    //    {
    //        if (nval == 2)
    //        {
    //            if (u == w && v == w && x == y || x == w && y == w && u == v || u == w && x == w && y == v || u == w && y == w && v == x || v == w && x == w && u == y || v == w && y == w && u == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4);
    //                StartGameAnimation(b, c, d, e);
    //            }
    //            else if (z == w && v == w && x == y || x == w && y == w && z == v || z == w && x == w && y == v || z == w && y == w && v == x || v == w && x == w && z == y || v == w && y == w && z == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4, 2);
    //                StartGameAnimation(c, d, e, f);
    //            }
    //            else if (u == v && x == w || u == w && v == x || v == w && u == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3);
    //                StartGameAnimation(b, c, d);
    //            }
    //            else if (v == x && y == w || v == w && x == y || x == w && v == y)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 2);
    //                StartGameAnimation(c, d, e);
    //            }
    //            else if (x == y && z == w || x == w && y == z || y == w && z == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 3);
    //                StartGameAnimation(d, e, f);
    //            }
    //        }
    //        else if (nval == 3)
    //        {
    //            if (u == w && v == w && x == y && y == z || u == w && z == w && x == y && x == v || y == w && z == w && x == u && x == v || x == w && z == w && u == y && u == v || x == w && y == w && u == v && u == z || v == w && z == w && u == y && u == x || v == w && y == w && u == x && u == z || v == w && x == w && u == y && u == z || u == w && y == w && v == x && v == z || u == w && x == w && v == y && v == z)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum);
    //                StartGameAnimation(b, c, d, e, f);
    //            }
    //            else if (u == w && v == x && v == y || v == w && u == x && u == y || x == w && u == v && u == y || y == w && u == v && u == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4);
    //                StartGameAnimation(b, c, d, e);
    //            }
    //            else if (z == w && v == x && v == y || v == w && z == x && z == y || x == w && z == v && z == y || y == w && z == v && z == x)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4, 2);
    //                StartGameAnimation(c, d, e, f);
    //            }
    //            else if ((u == v) && (u == x))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3);
    //                StartGameAnimation(b, c, d);
    //            }
    //            else if ((v == x) && (v == y))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 2);
    //                StartGameAnimation(c, d, e);
    //            }
    //            else if (x == y && x == z)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 3);
    //                StartGameAnimation(d, e, f);
    //            }
    //        }
    //        else if (nval == 4)
    //        {
    //            if (u == w || z == w || v == w || x == w || y == w)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum);
    //                StartGameAnimation(b, c, d, e, f);
    //            }
    //            else if ((u == v) && (u == x) && (u == y))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4);
    //                StartGameAnimation(b, c, d, e);
    //            }
    //            else if ((z == v) && (z == x) && (z == y))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 4, 2);
    //                StartGameAnimation(c, d, e, f);
    //            }
    //            else if ((u == v) && (u == x))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3);
    //                StartGameAnimation(b, c, d);
    //            }
    //            else if ((v == x) && (v == y))
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 2);
    //                StartGameAnimation(c, d, e);
    //            }
    //            else if (x == y && x == z)
    //            {
    //                PayCalculator.GeneratePayoutLine(LineNum, 3, 0, 3);
    //                StartGameAnimation(d, e, f);
    //            }
    //        }
    //        else if (nval == 5)
    //        {
    //            PayCalculator.GeneratePayoutLine(LineNum);
    //            StartGameAnimation(b, c, d, e, f);
    //        }
    //    }
    //}

    #region PayoutLineCalculation
    //private void CalculatePayoutLines(int a1, int a2, int a3, int a4, int a5)
    //{
    //    #region Initializations
    //    Sprite u1 = images[0].slotImages[a1].sprite;
    //    Sprite u2 = images[0].slotImages[a1 + 1].sprite;
    //    Sprite u3 = images[0].slotImages[a1 + 2].sprite;

    //    Sprite v1 = images[1].slotImages[a2].sprite;
    //    Sprite v2 = images[1].slotImages[a2 + 1].sprite;
    //    Sprite v3 = images[1].slotImages[a2 + 2].sprite;

    //    Sprite x1 = images[2].slotImages[a3].sprite;
    //    Sprite x2 = images[2].slotImages[a3 + 1].sprite;
    //    Sprite x3 = images[2].slotImages[a3 + 2].sprite;

    //    Sprite y1 = images[3].slotImages[a4].sprite;
    //    Sprite y2 = images[3].slotImages[a4 + 1].sprite;
    //    Sprite y3 = images[3].slotImages[a4 + 2].sprite;

    //    Sprite z1 = images[4].slotImages[a5].sprite;
    //    Sprite z2 = images[4].slotImages[a5 + 1].sprite;
    //    Sprite z3 = images[4].slotImages[a5 + 2].sprite;

    //    Sprite w = null;

    //    if (isWildObj)
    //    {
    //        if (WildSprite)
    //        {
    //            w = WildSprite;
    //        }
    //    }

    //    GameObject b1 = images[0].slotImages[a1].gameObject;
    //    GameObject b2 = images[0].slotImages[a1 + 1].gameObject;
    //    GameObject b3 = images[0].slotImages[a1 + 2].gameObject;

    //    GameObject c1 = images[1].slotImages[a2].gameObject;
    //    GameObject c2 = images[1].slotImages[a2 + 1].gameObject;
    //    GameObject c3 = images[1].slotImages[a2 + 2].gameObject;

    //    GameObject d1 = images[2].slotImages[a3].gameObject;
    //    GameObject d2 = images[2].slotImages[a3 + 1].gameObject;
    //    GameObject d3 = images[2].slotImages[a3 + 2].gameObject;

    //    GameObject e1 = images[3].slotImages[a4].gameObject;
    //    GameObject e2 = images[3].slotImages[a4 + 1].gameObject;
    //    GameObject e3 = images[3].slotImages[a4 + 2].gameObject;

    //    GameObject f1 = images[4].slotImages[a5].gameObject;
    //    GameObject f2 = images[4].slotImages[a5 + 1].gameObject;
    //    GameObject f3 = images[4].slotImages[a5 + 2].gameObject;
    //    #endregion

    //    int LineNumber = 1;
    //    CheckPayoutLine(u2, v2, x2, y2, z2, b2, c2, d2, e2, f2, LineNumber, w);//Middle Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v1, x1, y1, z1, b1, c1, d1, e1, f1, LineNumber, w);//Top Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v3, x3, y3, z3, b3, c3, d3, e3, f3, LineNumber, w); //Bottom Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v2, x3, y2, z1, b1, c2, d3, e2, f1, LineNumber, w); //V Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v2, x1, y2, z3, b3, c2, d1, e2, f3, LineNumber, w); //Reverse V Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v1, x2, y1, z2, b2, c1, d2, e1, f2, LineNumber, w); //ZigZag Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v3, x2, y3, z2, b2, c3, d2, e3, f2, LineNumber, w); //Reverse ZigZag Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v1, x2, y3, z3, b1, c1, d2, e3, f3, LineNumber, w); //Z Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v3, x2, y1, z1, b3, c3, d2, e1, f1, LineNumber, w); //Reverse Z Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v3, x2, y1, z2, b2, c3, d2, e1, f2, LineNumber, w); //Uneven Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v1, x2, y3, z2, b2, c1, d2, e3, f2, LineNumber, w); //Reverse Uneven Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v2, x2, y2, z1, b1, c2, d2, e2, f1, LineNumber, w); //U Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v2, x2, y2, z3, b3, c2, d2, e2, f3, LineNumber, w); //Reverse U Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v2, x1, y2, z1, b1, c2, d1, e2, f1, LineNumber, w); //W Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v2, x3, y2, z3, b3, c2, d3, e2, f3, LineNumber, w); //Reverse W Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v2, x1, y2, z2, b2, c2, d1, e2, f2, LineNumber, w); //Reverse Small T Line
    //    LineNumber++;

    //    CheckPayoutLine(u2, v2, x3, y2, z2, b2, c2, d3, e2, f2, LineNumber, w); //Small T Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v1, x3, y1, z1, b1, c1, d3, e1, f1, LineNumber, w); //T Line
    //    LineNumber++;

    //    CheckPayoutLine(u3, v3, x1, y3, z3, b3, c3, d1, e3, f3, LineNumber, w); //Reverse T Line
    //    LineNumber++;

    //    CheckPayoutLine(u1, v3, x3, y3, z1, b1, c3, d3, e3, f1, LineNumber, w); //Smiley Line
    //}
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

    private IEnumerator StopTweening1(int reqpos, Transform slotTransform)
    {
        tweener1.Pause();
        int tweenpos = (reqpos * IconSizeFactor) - IconSizeFactor;
        tweener1 = slotTransform.DOLocalMoveY(-tweenpos , 0.2f);
        yield return new WaitForSeconds(0.2f);
        tweener1 = slotTransform.DOLocalMoveY(-tweenpos + 100, 0.2f);
    }
    private IEnumerator StopTweening2(int reqpos, Transform slotTransform)
    {
        tweener2.Pause();
        int tweenpos = (reqpos * IconSizeFactor) - IconSizeFactor;
        tweener2 = slotTransform.DOLocalMoveY(-tweenpos, 0.2f);
        yield return new WaitForSeconds(0.2f);
        tweener2 = slotTransform.DOLocalMoveY(-tweenpos + 100, 0.2f);
    }
    private IEnumerator StopTweening3(int reqpos, Transform slotTransform)
    {
        tweener3.Pause();
        int tweenpos = (reqpos * IconSizeFactor) - IconSizeFactor;
        tweener3 = slotTransform.DOLocalMoveY(-tweenpos, 0.2f);
        yield return new WaitForSeconds(0.2f);
        tweener3 = slotTransform.DOLocalMoveY(-tweenpos + 100, 0.2f);
    }
    private IEnumerator StopTweening4(int reqpos, Transform slotTransform)
    {
        tweener4.Pause();
        int tweenpos = (reqpos * IconSizeFactor) - IconSizeFactor;
        tweener4 = slotTransform.DOLocalMoveY(-tweenpos, 0.2f);
        yield return new WaitForSeconds(0.2f);
        tweener4 = slotTransform.DOLocalMoveY(-tweenpos + 100, 0.2f);
    }
    private IEnumerator StopTweening5(int reqpos, Transform slotTransform)
    {
        tweener5.Pause();
        int tweenpos = (reqpos * IconSizeFactor) - IconSizeFactor;
        tweener5 = slotTransform.DOLocalMoveY(-tweenpos, 0.2f);
        yield return new WaitForSeconds(0.2f);
        tweener5 = slotTransform.DOLocalMoveY(-tweenpos + 100, 0.2f);
    }

    private void KillAllTweens()
    {
        tweener1.Kill();
        tweener2.Kill();
        tweener3.Kill();
        tweener4.Kill();
        tweener5.Kill();
    }
    #endregion

}

[Serializable]
public class SlotImage
{
    public List<Image> slotImages = new List<Image>(10);
}

