using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotificationSystem
{
    private static List<Iobserver> observers = new List<Iobserver>();

    public static void addObserver(Iobserver observer) 
    {
        observers.Add(observer);
    }
    public static void Notify() 
    {
        foreach (Iobserver obs in observers) 
        {
            obs.Notify();
        } 
    }
}
