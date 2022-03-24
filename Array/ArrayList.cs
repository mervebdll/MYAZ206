using System;
using System.Collections;
using System.Linq;

namespace DataStructures.Array
{
    public class ArrayList : DataStructures.Array.Array, IEnumerable
    {
        private int position;//pozisyon bilgisi
        public int Count => position;//Length ifadesi yerine Count ifadesini kullanıyoruz.
        public ArrayList(int defaultSize = 2) : base(defaultSize)//base classa götürür.
        //ArrayList yapısı Array den devr alındığı için constructorda InnerArray başlatılmıştı dolayısıyla burada da başlatılmalı.
        {
            position = 0;
        }
        public ArrayList(IEnumerable collection) : this()//Kopyalama işlemi yapılır. Herhangi bir veri yapısı(Collection) kullanılabilir.
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Add(Object value)
        {
            if (position == Length)
            {
                DoubleArray();
            }

            if (position < Length)
            {
                InnerArray[position] = value;
                //SetValue(value, position);
                position++;
                return;
            }
            throw new Exception();
        }

        private void DoubleArray()//Bellekte yeteri kadar yer olmaması durumunda oluşacak hata düzenlemesi.
        {
            try//Dizi boyutu 2 katına çıkarılır
            {
                var temp = new Object[InnerArray.Length * 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length);
                InnerArray = temp;
            }
            catch (Exception ex)//hata durumunda hata mesajı veririr.
            {
                throw new Exception(ex.Message);
            }
        }
        public Object Remove()//Silme işlemi yapılmıyor, kaydırma işlemi yapılıyor.
        {
            if (position >= 0)
            {
                var temp = InnerArray[position - 1];
                position--;
                if (position == InnerArray.Length / 4)
                    HalfArray();
                return temp;
            }
            throw new Exception();
        }
        private void HalfArray()
        {
            try
            {
                var temp = new Object[InnerArray.Length / 2];//Boyut bilgisi yarıya indirilir.
                System.Array.Copy(InnerArray, temp, InnerArray.Length / 2);
                InnerArray = temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        new public IEnumerator GetEnumerator()//new ifadesini yazmamızın sebebi Array'den devraldığınız metodu gizliyoruz.
        {
            return InnerArray.Take(position).GetEnumerator();
        }
    }
}
