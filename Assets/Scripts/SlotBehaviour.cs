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

    [SerializeField]
    private PayoutCalculation PayCalculator;

    private Tweener tweener1;
    private Tweener tweener2;
    private Tweener tweener3;
    private Tweener tweener4;
    private Tweener tweener5;

    int numberOfSlots = 0;

    int dummynum1 = 3;
    int dummynum2 = 3;
    int dummynum3 = 3;
    int dummynum4 = 5;
    int dummynum5 = 5;

    private void Start()
    {
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
        for(int k = 0; k<2; k++)
        {
            GameObject mylastImg = Instantiate(Image_Prefab, SlotTransform);
            slot_Images.Add(mylastImg.GetComponent<Image>());
            slot_Images[slot_Images.Count - 1].sprite = myImages[values[k]];
        }
        if (mainContainer_RT) LayoutRebuilder.ForceRebuildLayoutImmediate(mainContainer_RT);
        tweenHeight = (values.Count * 100)-150;
    }

    private void StartSlots()
    {
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
        CalculatePayoutLines(12 - dummynum1, 12 - dummynum2, 12 - dummynum3, 12 - dummynum4, 12 - dummynum5);
    }

    #region PayoutLineCalculation
    private void CalculatePayoutLines(int a1, int a2, int a3, int a4, int a5)
    {
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

        if ((u2 == v2) && (u2 == x2) || (u2 == x2) && (u2 == y2) || (u2 == y2) && (u2 == z2))
        {
            if ((u2 == v2) && (u2 == x2) && (u2 == y2) || (u2 == x2) && (u2 == y2) && (u2 == z2))
            {
                if ((u2 == v2) && (u2 == x2) && (u2 == y2) && (u2 == z2))
                {
                    PayCalculator.GeneratePayoutLine(1);
                }
                else if((u2 == v2) && (u2 == x2) && (u2 == y2))
                {
                    PayCalculator.GeneratePayoutLine(1, 4);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(1, 4, 2);
                }
            }
            else if((u2 == v2) && (u2 == x2))
            {
                PayCalculator.GeneratePayoutLine(1, 3);
            }
            else if ((u2 == x2) && (u2 == y2))
            {
                PayCalculator.GeneratePayoutLine(1, 3, 0, 2);
            }
            else
            {
                PayCalculator.GeneratePayoutLine(1, 3, 0, 3);
            }
        }

        if ((u1 == v1) && (u1 == x1) || (u3 == x3) && (u3 == y3) || (u1 == y1) && (u1 == z1))
        {
            if ((u1 == v1) && (u1 == x1) && (u1 == y1) || (u1 == x1) && (u1 == y1) && (u1 == z1))
            {
                if ((u1 == v1) && (u1 == x1) && (u1 == y1) && (u1 == z1))
                {
                    PayCalculator.GeneratePayoutLine(2);
                }
                else if((u1 == v1) && (u1 == x1) && (u1 == y1))
                {
                    PayCalculator.GeneratePayoutLine(2, 4);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(2, 4, 2);
                }
            }
            else if((u1 == v1) && (u1 == x1))
            {
                PayCalculator.GeneratePayoutLine(2, 3);
            }
            else if((u3 == x3) && (u3 == y3))
            {
                PayCalculator.GeneratePayoutLine(2, 3, 0, 2);
            }
            else
            {
                PayCalculator.GeneratePayoutLine(2, 3, 0, 3);
            }
        }

        if ((u3 == v3) && (u3 == x3) || (u3 == x3) && (u3 == y3) || (u3 == y3) && (u3 == z3))
        {
            if ((u3 == v3) && (u3 == x3) && (u3 == y3) || (u3 == x3) && (u3 == y3) && (u3 == z3))
            {
                if ((u3 == v3) && (u3 == x3) && (u3 == y3) && (u3 == z3))
                {
                    PayCalculator.GeneratePayoutLine(3);
                }
                else if ((u3 == v3) && (u3 == x3) && (u3 == y3))
                {
                    PayCalculator.GeneratePayoutLine(3, 4);
                }
                else
                {
                    PayCalculator.GeneratePayoutLine(3, 4, 2);
                }
            }
            else if ((u3 == v3) && (u3 == x3)) 
            {
                PayCalculator.GeneratePayoutLine(3, 3);
            }
            else if ((u2 == x2) && (u2 == y2))
            {
                PayCalculator.GeneratePayoutLine(3, 3, 0, 2);
            }
            else if ((u3 == y3) && (u3 == z3))
            {
                PayCalculator.GeneratePayoutLine(3, 3, 0, 3);
            }
        }

        if ((u1 == v2) && (u1 == x3) && (u1 == y2) && (u1 == z1)) 
        {
            PayCalculator.GeneratePayoutLine(4);
        }

        if ((u3 == v2) && (u3 == x1) && (u3 == y2) && (u3 == z3)) 
        {
            PayCalculator.GeneratePayoutLine(5);
        }

        if ((u2 == v1) && (u2 == x2) && (u2 == y1) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(6);
        }

        if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(7);
        }

        if ((u1 == v1) && (u1 == x2) && (u1 == y3) && (u1 == z3)) 
        {
            PayCalculator.GeneratePayoutLine(8);
        }

        if ((u3 == v3) && (u3 == x2) && (u3 == y1) && (u3 == z1)) 
        {
            PayCalculator.GeneratePayoutLine(9);
        }

        if ((u2 == v3) && (u2 == x2) && (u2 == y1) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(10);
        }

        if ((u2 == v1) && (u2 == x2) && (u2 == y3) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(11);
        }

        if ((u1 == v2) && (u1 == x2) && (u1 == y2) && (u1 == z1)) 
        {
            PayCalculator.GeneratePayoutLine(12);
        }

        if ((u3 == v2) && (u3 == x2) && (u3 == y2) && (u3 == z3)) 
        {
            PayCalculator.GeneratePayoutLine(13);
        }

        if ((u1 == v2) && (u1 == x1) && (u1 == y2) && (u1 == z1)) 
        {
            PayCalculator.GeneratePayoutLine(14);
        }

        if ((u2 == v3) && (u2 == x2) && (u2 == y3) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(15);
        }

        if ((u2 == v2) && (u2 == x1) && (u2 == y2) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(16);
        }

        if ((u2 == v2) && (u2 == x3) && (u2 == y2) && (u2 == z2)) 
        {
            PayCalculator.GeneratePayoutLine(17);
        }

        if ((u1 == v1) && (u1 == x3) && (u1 == y1) && (u1 == z1))
        {
            PayCalculator.GeneratePayoutLine(18);
        }

        if ((u3 == v3) && (u3 == x1) && (u3 == y3) && (u3 == z3)) 
        {
            PayCalculator.GeneratePayoutLine(19);
        }

        if ((u1 == v3) && (u1 == x3) && (u1 == y3) && (u1 == z1)) 
        {
            PayCalculator.GeneratePayoutLine(20);
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
