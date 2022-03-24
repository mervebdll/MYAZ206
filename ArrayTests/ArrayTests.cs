using DataStructures.Array;
using Xunit;

namespace ArrayTests
{
    public class ArrayTests
    {
        [Theory]//Parametre testi için kullanýlýr.
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void Check_Array_Constractor(int defaultSize)//Array klasörünü refere ettik.
        {
            //Arrange, Act(defaultSize parametresini verdiðimiz için)
            var arr = new DataStructures.Array.Array(defaultSize);//namespace(Baðýmlýlýklarý ekle)

            //Assert
            Assert.Equal(defaultSize, arr.Length);//Length ifadesi olmadýðý için oluþturuyoruz.ctrl+. ile Generic property seçilir. 
        }
        [Fact]
        public void Check_Array_Constructor_with_params()
        {
            //Arrange, Act
            var array = new DataStructures.Array.Array(1, 2, 3);
            //Assert
            Assert.Equal(3, array.Length);
        }
        [Fact]
        public void Get_and_Set_Values_in_Array()
        {
            //Arrange
            var array = new DataStructures.Array.Array();
            //Act
            array.SetValue(10, 0);
            array.SetValue(20, 1);
            //Assert
            Assert.Equal(10, array.GetValue(0));
            Assert.Equal(20, array.GetValue(1));
            Assert.Null(array.GetValue(2));

        }
        [Fact]
        public void Array_Clone_Test()
        {
            //Arrange
            var array = new DataStructures.Array.Array(1, 2, 3);

            //Act
            var clonedArray = array.Clone() as DataStructures.Array.Array;//clonedArray ifadesi bir obje döndüðü için uzunluðu alýnamýyor. Bu yapý clonedArray.Length ifadesindeki Length ifadesinin tanýnmasý için yazýldý.

            //Assert 
            Assert.NotNull(clonedArray);//refereans aldýðýný(newlendiðini) kontrol ediyoruz.
            Assert.Equal(array.Length, clonedArray.Length);
            Assert.NotEqual(array.GetHashCode(), clonedArray.GetHashCode());//Ayný yere iþaret edip etmediðini kontrol eder.
            //Bu yapýlar newlendiði için farklý referanslara sahiplerdir.
        }
        [Fact]
        public void Array_GetEnumerator_Test()
        {
            //Arrange
            var array = new DataStructures.Array.Array(10, 20, 30);
            //Act
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }
            //Assert
            Assert.Equal("102030", s);

        }
        //gezinti ifadesini Costum hale getirmemizin sebebi diziyi tersten dolaþmak gerekebilir veya baðlý liste yapýsý olabilir.
        [Fact]
        public void Array_Custom_GetEnumerator_Test()
        {
            //Arrange
            var array = new DataStructures.Array.Array(10, 20, 30);
            //Act
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }
            //Assert
            Assert.Equal("102030", s);

        }
    }
}
