using System;
using Java.Interop;

namespace HM
{
    public class Category: Java.Lang.Object, Java.IO.ISerializable
    {
        public String title;
        public int imgResId;
        public int key;
    }
}
