using System;
using UnityEngine;

namespace Teenpatti.Data.Socket
{
    [Serializable]
    public class Player
    {
        public string id;
        public string name;
        public double balance;
        public string avatar;
    }
}