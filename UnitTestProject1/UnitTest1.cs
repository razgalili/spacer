using Microsoft.VisualStudio.TestTools.UnitTesting;

using addSpaces;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestInsertSpaces
    {
        [TestMethod]
        public void IndexesShouldNotBeNull()
        {
            Assert.IsTrue(ExtExcept.IsThrowsException<ArgumentNullException>(() => Spacefier.insertSpacesIntoString("", null, 15)));
        }
    }

    [TestClass]
    public class TestSpecifier
    {
        [TestMethod]
        public void SpacefierConstructorDosentThrow()
        {
            new Spacefier();
        }

 

        [TestMethod]
        public void SettingEmptyDictionaryThrows()
        {
            Assert.IsTrue(
            ExtExcept.IsThrowsException<ArgumentException>(
                () =>{
                    var s = new Spacefier();
                    s.SetDictonary(new string[] { });
                }));
        }

        string[] SingleWordDic = new string[] { "word" };
        string[] MultiWordDic = new string[] { "word1","word2","word3" };

        [TestMethod]
        public void SingleWordDictionaryWontThrow()
        {
            Assert.IsFalse(
                ExtExcept.IsThrowsException<ArgumentException>(
                () =>{
                    var s = new Spacefier();
                    s.SetDictonary(SingleWordDic);
                    new Spacefier(SingleWordDic);
                }));
        }

        [TestMethod]
        public void TryingToSpecifyWithoutAdictionaryThrows()
        {
            Assert.IsTrue(
                ExtExcept.IsThrowsException<InvalidOperationException>(
                    () => GenericSpacerTest(null, "word", "word")
                )
            );
        }
        void GenericSpacerTest(string[] dictionary, string src, string results) =>
            Assert.AreEqual(new Spacefier(dictionary).Specify(src), results);

        [TestMethod]
        public void EmptyStringSpecifyToSame() => GenericSpacerTest(SingleWordDic, "", "");

        [TestMethod]
        public void SingleWordSpacing2zeroFound() => GenericSpacerTest(SingleWordDic, "tree", "tree");

        [TestMethod]
        public void SingleWordSpacing2itself() => GenericSpacerTest(SingleWordDic, "word", "word");

        [TestMethod]
        public void SingleWordTwiceSpacedCorrectly() => GenericSpacerTest(SingleWordDic, "wordword", "word word");

    }

    static class ExtExcept
    {
        public static bool IsThrowsException<ExceptionType>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(ExceptionType))
                    return true;
            }

            return false;
        }
    }
}
