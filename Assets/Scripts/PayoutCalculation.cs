using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class PayoutCalculation : MonoBehaviour
{
    [SerializeField]
    private int[] x_Points;
    [SerializeField]
    private int[] y_Points;

    [SerializeField]
    private Transform LineContainer;
    [SerializeField]
    private GameObject Line_Prefab;

    private Vector2 line1Position = new Vector2(-315, 100);
    private Vector2 line2Position = new Vector2(-315, 0);
    private Vector2 line3Position = new Vector2(-315, -100);


    private void Start()
    {

    }

    internal void GeneratePayoutLine(int possibilities,int min = 5, int sub4 = 1, int sub3 = 1)
    {
        switch (possibilities)
        {
            case 1:
                MiddleLine(min, sub4, sub3);
                break;
            case 2:
                TopLine(min, sub4, sub3);
                break;
            case 3:
                BottomLine(min, sub4, sub3);
                break;
            case 4:
                VLine(min, sub4, sub3);
                break;
            case 5:
                ReverseVLine(min, sub4, sub3);
                break;
            case 6:
                UpperZigZagLine(min, sub4, sub3);
                break;
            case 7:
                LowerZigZagLine(min, sub4, sub3);
                break;
            case 8:
                ZLine(min, sub4, sub3);
                break;
            case 9:
                ReverseZLine(min, sub4, sub3);
                break;
            case 10:
                UnevenLine(min, sub4, sub3);
                break;
            case 11:
                ReverseUnevenLine(min, sub4, sub3);
                break;
            case 12:
                ULine(min, sub4, sub3);
                break;
            case 13:
                ReverseULine(min, sub4, sub3);
                break;
            case 14:
                WLine(min, sub4, sub3);
                break;
            case 15:
                ReverseWLine(min, sub4, sub3);
                break;
            case 16:
                ReverseSmallTLine(min, sub4, sub3);
                break;
            case 17:
                SmallTLine(min, sub4, sub3);
                break;
            case 18:
                TLine(min, sub4, sub3);
                break;
            case 19:
                ReverseTLine(min, sub4, sub3);
                break;
            case 20:
                SmileyLine(min, sub4, sub3);
                break;
        }
    }

    private void sub4Calculation(UILineRenderer MyLine, int sub4)
    {
        if (sub4 == 1)
        {
            var newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(5);
            MyLine.Points = newpointlist.ToArray();
        }
        else
        {
            var newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
        }
    }

    private void sub3Calculation(UILineRenderer MyLine, int sub3)
    {
        if (sub3 == 1)
        {
            var newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(4);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(4);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
        }
        else if (sub3 == 2)
        {
            var newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(3);
            MyLine.Points = newpointlist.ToArray();
        }
        else
        {
            var newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
            newpointlist = new List<Vector2>(MyLine.Points);
            newpointlist.RemoveAt(0);
            MyLine.Points = newpointlist.ToArray();
        }
    }

    private void MiddleLine(int min = 5,int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine.Points);
            pointlist.Add(points);
            MyLine.Points = pointlist.ToArray();
        }
        if(min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if(min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void TopLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine.Points);
            pointlist.Add(points);
            MyLine.Points = pointlist.ToArray();
        }
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void BottomLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine.Points);
            pointlist.Add(points);
            MyLine.Points = pointlist.ToArray();
        }
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void VLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = -y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseVLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void UpperZigZagLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void LowerZigZagLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ZLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseZLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void UnevenLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseUnevenLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ULine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseULine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void WLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseWLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void ReverseSmallTLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void SmallTLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line2Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }

    private void TLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }
    private void ReverseTLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line3Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }
    private void SmileyLine(int min = 5, int sub4 = 1, int sub3 = 1)
    {
        GameObject MyLineObj = Instantiate(Line_Prefab, LineContainer);
        MyLineObj.transform.localPosition = line1Position;
        UILineRenderer MyLine = MyLineObj.GetComponent<UILineRenderer>();
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine.Points);
        pointlist.Add(points);
        MyLine.Points = pointlist.ToArray();
        if (min == 4)
        {
            sub4Calculation(MyLine, sub4);
        }
        else if (min == 3)
        {
            sub3Calculation(MyLine, sub3);
        }
    }
}
