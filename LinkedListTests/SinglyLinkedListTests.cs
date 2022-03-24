using DataStructures.LinkedList.SinglyLinkedList;
using System;
using Xunit;

namespace LinkedListTests
{
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _list;

        public SinglyLinkedListTests()
        {//AddFirst çalýþtýðý için ilk baþta 6 eklenecek sonra onun baþýna 8 eklenecek. 8-6
            _list = new SinglyLinkedList<int>(new int[] { 6, 8 });//Field'ý baþalt
        }

        [Fact]
        public void Count_Test()
        {
            //act
            int count = _list.Count;

            //Assert
            Assert.Equal(2, count);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddFirst_Test(int value)
        {
            //act
            _list.AddFirst(value);

            //Assert
            Assert.Equal(value, _list.Head.Value);
            Assert.Collection(_list,
                item => Assert.Equal(value, value),
                item => Assert.Equal(item, _list.Head.Next.Value),//8
                item => Assert.Equal(item, _list.Head.Next.Next.Value));//6
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            //Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6));
        }

        [Theory]
        [InlineData(6)]
        public void AddLast_Test(int value)
        {
            //Act
            _list.AddLast(value);

            //Assert
            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(value, item));//8, 6, value
        }

        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddBefore_Test(int value)
        {
            // Act
            _list.AddBefore(_list.Head.Next, value);

            //Assert
            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item));//8, value, 6
        }

        [Fact]
        public void AddBefore_ArgumentException()
        {
            // act
            var node = new SinglyLinkedListNode<int>(55);

            // Assert
            Assert.Throws<ArgumentException>(() => _list.AddBefore(node, 45));// 8 [value] 6
        }

        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddAfter_Test(int value)
        {
            // act
            _list.AddAfter(_list.Head, value);

            // assert
            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item));// 8 [value] 6 
        }

        [Fact]
        public void AddAfter_ArgumentException()
        {
            // 8 [value] 6
            // act
            var node = new SinglyLinkedListNode<int>(55);
            

            // Assert
            Assert.Throws<ArgumentException>(() => _list.AddAfter(node, 45));
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            // Act
            _list.RemoveFirst();

            // Assert
            Assert.Collection(_list, item => Assert.Equal(6, item));// 8, 6
        }

        [Fact]
        public void RemoveFirst_Exception_Test()
        {
            // Act
            _list.RemoveFirst();
            _list.RemoveFirst();

            // Assert
            Assert.Throws<Exception>(() => _list.RemoveFirst());// 8 6
        }

        [Fact]
        public void RemoveLast_Test()
        {
            // act
            var result = _list.RemoveLast();

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(8, item));// 8 6 

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(8)]
        public void Remove_Test(int value)
        {
            _list.AddFirst(10);// 10 8 6

            // act
            _list.Remove(value);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(10, item),
                item => Assert.Equal(6, item));//10, 6
        }
    }
}