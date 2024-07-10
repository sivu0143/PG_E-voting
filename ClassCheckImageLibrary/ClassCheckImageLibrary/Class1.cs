using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassCheckImageLibrary
{
    public class ClassImage//voter register before insert
    {
        public byte[] CheckImage(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();
            return b;

      

        }
        //public long ImageLength(string fname)
        //{
        //    FileInfo fi = new FileInfo(fname);
        //    return fi.Length;

            
        //}
    }
}
