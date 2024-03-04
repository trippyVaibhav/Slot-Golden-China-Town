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
    private UILineRenderer MyLine;
    [SerializeField]
    private UILineRenderer MyLine2;
    [SerializeField]
    private UILineRenderer MyLine3;


    private void Start()
    {

    }

    internal void GeneratePayoutLine(int possibilities)
    {
        switch (possibilities)
        {
            case 1:
                MiddleLine();
                break;
            case 2:
                TopLine();
                break;
            case 3:
                BottomLine();
                break;
            case 4:
                VLine();
                break;
            case 5:
                ReverseVLine();
                break;
            case 6:
                UpperZigZagLine();
                break;
            case 7:
                LowerZigZagLine();
                break;
            case 8:
                ZLine();
                break;
            case 9:
                ReverseZLine();
                break;
            case 10:
                UnevenLine();
                break;
            case 11:
                ReverseUnevenLine();
                break;
            case 12:
                ULine();
                break;
            case 13:
                ReverseULine();
                break;
            case 14:
                WLine();
                break;
            case 15:
                ReverseWLine();
                break;
            case 16:
                ReverseSmallTLine();
                break;
            case 17:
                SmallTLine();
                break;
            case 18:
                TLine();
                break;
            case 19:
                ReverseTLine();
                break;
            case 20:
                SmileyLine();
                break;
        }
    }

    private void MiddleLine()
    {
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine2.Points);
            pointlist.Add(points);
            MyLine2.Points = pointlist.ToArray();
        }
    }

    private void TopLine()
    {
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine.Points);
            pointlist.Add(points);
            MyLine.Points = pointlist.ToArray();
        }
    }

    private void BottomLine()
    {
        for (int i = 0; i < 5; i++)
        {
            var points = new Vector2() { x = x_Points[i], y = y_Points[0] };
            var pointlist = new List<Vector2>(MyLine3.Points);
            pointlist.Add(points);
            MyLine3.Points = pointlist.ToArray();
        }
    }

    private void VLine()
    {
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
    }

    private void ReverseVLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[2] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
    }

    private void UpperZigZagLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void LowerZigZagLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void ZLine()
    {
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
    }

    private void ReverseZLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
    }

    private void UnevenLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void ReverseUnevenLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void ULine()
    {
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
    }

    private void ReverseULine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
    }

    private void WLine()
    {
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
    }

    private void ReverseWLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
    }

    private void ReverseSmallTLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void SmallTLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[1] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine2.Points);
        pointlist.Add(points);
        MyLine2.Points = pointlist.ToArray();
    }

    private void TLine()
    {
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
    }
    private void ReverseTLine()
    {
        var points = new Vector2() { x = x_Points[0], y = y_Points[0] };
        var pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[1], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[2], y = -y_Points[2] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[3], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
        points = new Vector2() { x = x_Points[4], y = y_Points[0] };
        pointlist = new List<Vector2>(MyLine3.Points);
        pointlist.Add(points);
        MyLine3.Points = pointlist.ToArray();
    }
    private void SmileyLine()
    {
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
    }
}
