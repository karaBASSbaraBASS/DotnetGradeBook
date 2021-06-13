using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMesage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("book 1");
            SetName(book1, "NewName");

            Assert.Equal("NewName", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("book 1");
            var book2 = GetBook("book 2");

            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();  
            SetInt(ref x);

            Assert.Equal(5, x);
        }

        private void SetInt(ref int x)
        {
            x = x + 2;
     
        }

        private int GetInt()
        {
            return 3;
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void CannotAddGradeBiggerThan100()
        {
            var book1 = GetBook("book 1");           
            var caughtException = Assert.Throws<ArgumentException>(() => book1.AddGrade(105.0));
            Assert.Equal("Invalid grade", caughtException.Message);
        }


    }
}
