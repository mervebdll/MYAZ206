using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Array//Array'di, DataStructeres yaptık. Nedeni Array System.Array'de de var kafa karışıklığını önlemek.
{
    public class Array : ICloneable, IEnumerable
    {
        protected Object[] InnerArray { get; set; }//Referans tipli bir ifadeyi(Object) kullanabilmek için mutlaka başlatmak gerekir. Başlatmaktan kasıt newlenmelidir.
        //public IEnumerable<object> Length { get; set; }

        public int Length => InnerArray.Length;
        public Array(int defaultSize = 16)
        {
            InnerArray = new Object[defaultSize];//Diziler fixed size(Sabit boyut)'dır.
        }
        public Array(params Object[] sourceArray) : this(sourceArray.Length)//newleyip yeni bir Obje oluşturulur.
        {
            //for (int i = 0; i < sourceArray.Length; i++)
            //{
            //    InnerArray[i] = sourceArray[i];
            //}
            System.Array.Copy(sourceArray, InnerArray, sourceArray.Length);
        }
        public Object GetValue(int index)//GetValue geriye değer döndüğü için türü Object yapılır.
        {
            //Tanımlanan indexler dışındaki bir index çağırılması durumunda hata mesajı yazmalıyız.
            if (!(index >= 0 && index < InnerArray.Length))
            {
                throw new ArgumentOutOfRangeException();//ilgili değer aralığında yer almadığını döndürür.
            }
            return InnerArray[index];
        }
        public void SetValue(Object value, int index)
        {
            if (!(index >= 0 && index < InnerArray.Length))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            InnerArray[index] = value;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public IEnumerator GetEnumerator() //foreach üzerinde dönmemizi sağlar.
        {
            //return InnerArray.GetEnumerator();
            return new CustomArrayEnumerator(InnerArray);
        }
        //GetEnumerator yapısında 3 tane metod vardır. Current; mevcut öğeyi döndürür. MoveNext(bool); Collection içerisinde sırada öğe var mı kontrol eder.
        //Reset; Collection bittiği zaman resetler.
        public int IndexOf(Object value)
        {
            for (int i = 0; i < InnerArray.Length; i++)
            {
                if (GetValue(i).Equals(value))
                    return i;
            }
            return -1; // O(n) doğrusal bir maliyet var.
        }
    }
}
