using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassCheckImageLibrary
{
   public  class ImageComparision
    {
        public byte[] check(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();
            return b;
        }
        
        public  bool  checkcompare(string fname,byte[] b1)
        {
            bool bo = false;
           byte[] b= check(fname);
           if (b.Length == b1.Length)
           {
               for (int i = 0; i < b.Length; i++)
               {
                   if (b[i] == b1[i])
                       bo = true;

                   else
                   {
                       bo = false;
                       break;
                   }
               }
           }
           else
           {
              // Response.Write("not equal");
              // return;
               return false;
           }
           if (bo == true)
               return true;
           else
               return false;

        }


    }
}
