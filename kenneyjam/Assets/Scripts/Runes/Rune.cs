using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Rune : MonoBehaviour
    {
        public Sprite Sprite;
        public abstract string Description { get; }
    }
}
