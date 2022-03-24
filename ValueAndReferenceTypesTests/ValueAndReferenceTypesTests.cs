using System;
using ValueAndReferenceTypes;
using Xunit;

namespace ValueAndReferenceTypesTests
{
    public class ValueAndReferenceTypesTests
    {
        [Fact]
        public void ReferenceTypeTest()
        {
            // Arrange(Düzenleme)
            var p1 = new ReferenceType()
            {
                X = 10,
                Y = 20
            };
            var p2 = p1;

            //Act(Eylem)
            p1.X = 30;

            //Assert
            Assert.Equal(p1.X, p2.X);
        }
        [Fact]
        public void ValueTypeTest()
        {
            // Arrange(Düzenleme)
            var p1 = new ValueAndReferenceTypes.ValueType
            {
                X = 10,
                Y = 20
            };
            var p2 = p1;

            //Act(Eylem)
            p1.X = 30;

            //Assert
            Assert.NotEqual(p1.X, p2.X);
        }
        [Fact]
        public void RecordTypeTest()
        {
            // Arrange(Düzenleme)
            var p1 = new RecordType(3, 5);

            //Act(Eylem)
            var p2 = new RecordType(3, 5);

            //Assert
            Assert.Equal(p1, p2);
        }
        
        [Fact]
        public void SwapByReference()
        {
            //Arrange
            int a = 23, b = 55;
            //Act
            var p1 = new ReferenceType();
            p1.Swap(ref a, ref b);
            //Assert
            Assert.Equal(55, a);
            Assert.Equal(23, b);
        }
        [Fact]
        public void CheckOutKeyword()
        {  
            //Arrange
            var referenceType = new ReferenceType();
            int b = 50;
            //Act
            referenceType.CheckOut(out b);
            //Assert
            Assert.Equal(100, b);
        }
    }
}
