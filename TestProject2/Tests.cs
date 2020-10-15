using System;
using Xunit;
using Collection;
using Xunit.Sdk;

namespace TestProject2
{
    public class Tests
    {
        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingAnItem()
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act
            var receivedEvent = Assert.Raises<AddToCollection<string>>(
                a => circularList.Added += a,
                a => circularList.Added -= a,
                () => { circularList.Add("0"); });
            //assert
            Assert.NotNull(receivedEvent);
            Assert.Equal("0", receivedEvent.Arguments.AddItem);
            Assert.Equal("0 was added", receivedEvent.Arguments.Message);
        }
        
     
        [Fact]
        public void Remove_CheckThatEventRaisedWhenRemovingAnItem()
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "5", "8", "1", "6"};
            var itemToRemove = "2";
            //act
            var receivedEvent = Assert.Raises<RemFromCollection<string>>(
                a => circularList.Removed += a,
                a => circularList.Removed -= a,
                () => { circularList.Remove(itemToRemove); });
            //assert
            Assert.NotNull(receivedEvent);
            Assert.Equal("2", receivedEvent.Arguments.RemItem);
            Assert.Equal("2 was removed", receivedEvent.Arguments.Message);
        }
        [Fact]
        public void Add_AddNullElement_ThrowsArgumentNullException()
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act & assert
            Assert.Throws<ArgumentNullException>(() => circularList.Add((string)null));
        }
        
        [Theory,
         InlineData("2"), InlineData("5"), InlineData("6")]
        public void Contains_CheckContainsOfElementsThatAreInCollection_ReturnTrue(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act
            var contains = circularList.Contains(value);
            //assert
            Assert.True(contains);
        }
        [Theory,
         InlineData("0"), InlineData("-18"), InlineData("60")]
        public void Contains_CheckContainsOfElementsThatAreNotInCollection_ReturnFalse(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act
            var contains = circularList.Contains(value);
            //assert
            Assert.False(contains);
        }
        [Theory,
         InlineData("0"), InlineData("-18"), InlineData("60")]
        public void Contains_CheckContainsWhenCollectionIsEmpty_ReturnFalse(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>();
            //act
            var contains = circularList.Contains(value);
            //assert
            Assert.False(contains);
        }
        [Theory,
         InlineData("1"), InlineData("5"), InlineData("8")]
        public void Remove_CheckRemoveOfElementsThatAreInCollection_ReturnTrue(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act & assert
            Assert.True(circularList.Remove(value));
        }
        [Theory,
         InlineData("20"), InlineData("30"), InlineData("40")]
        public void Remove_CheckRemoveOfElementsThatAreNotInCollection_ReturnFalse(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act & assert
            Assert.False(circularList.Remove(value));
        }
        [Theory,
         InlineData("20"), InlineData("30"), InlineData("40")]
        public void Remove_CheckRemoveOfElementsIfCollectionIsEmpty_ReturnFalse(string value)
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>();
            //act & assert
            Assert.False(circularList.Remove(value));
        }
        [Fact]
        public void Remove_RemoveNullElement_ThrowsArgumentNullException()
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "2", "5", "8", "1", "6"};
            //act & assert
            Assert.Throws<ArgumentNullException>(() => circularList.Remove((string)null));
        }
        [Fact]
        public void Clear_ClearCollection_ReturnTrue()
        {
            //arrange
            CircularLinkedList<string> circularList = new CircularLinkedList<string>(){"2", "5", "8", "1", "6"};
            //act
            circularList.Clear();
            //assert
            Assert.True(circularList.Count == 0);
        }
    }
}